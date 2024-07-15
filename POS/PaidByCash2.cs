using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using POS.APP_Data;

namespace POS
{
    public partial class PaidByCash2 : Form
    {
        #region Variables

        public List<TransactionDetail> DetailList = new List<TransactionDetail>();

        public int Discount { get; set; }

        public int Tax { get; set; }

        public int ExtraDiscount { get; set; }

        public int ExtraTax { get; set; }

        public Boolean isDraft { get; set; }

        public Boolean isDebt { get; set; }

        public string DraftId { get; set; }

        public string DebtId { get; set; }

        public long DebtAmount { get; set; }

        public Boolean IsWholeSale { get; set; }



        public long PrePaidAmount { get; set; }

        public List<Transaction> CreditTransaction { get; set; }

        public List<Transaction> PrePaidTransaction { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        private long totalAmount = 0, prePaidAmount = 0;

        public decimal BDDiscount { get; set; }

        public decimal MCDiscount { get; set; }

        public int CustomerId { get; set; }

        public int CustomerTypeId { get; set; }

        public int? RoomId { get; set; }

        public int? MemberTypeId { get; set; }

        public decimal? MCDiscountPercent { get; set; }

        public DialogResult _result;

        public decimal TotalAmt = 0;

        private decimal AmountWithExchange = 0;

        string CurrencySymbol = string.Empty;

        long total;

        string resultId = "-";

        int Qty = 0;

        List<Stock_Transaction> productList = new List<Stock_Transaction>();

        public List<string> TranIdList = new List<string>();

        Transaction CreditT = new Transaction();

        public Boolean IsPrint = true;

        #endregion

        public PaidByCash2()
        {
            InitializeComponent();
        }

        #region Hot keys handler
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U)      //  Ctrl + U => Focus Currency
            {
                cboCurrency.DroppedDown = true;
                if (cboCurrency.Focused != true)
                {
                    cboCurrency.Focus();
                }
            }
            else if (e.Control && e.KeyCode == Keys.R)      // Ctrl + R => Focus Receive Amt
            {
                cboCurrency.DroppedDown = false;
                txtReceiveAmount.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.S)      // Ctrl + S => Click Save
            {
                cboCurrency.DroppedDown = false;
                btnSubmit.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.C)      // Ctrl + C => Focus DropDown Customer
            {
                cboCurrency.DroppedDown = false;
                btnCancel.PerformClick();
            }
        }
        #endregion

        private void PaidByCash2_Load(object sender, EventArgs e)
        {
            #region Setting Hot Kyes For the Controls
            SendKeys.Send("%"); SendKeys.Send("%"); // Clicking "Alt" on page load to show underline of Hot Keys
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            #endregion

            #region currency
            Currency curreObj = new Currency();
            List<Currency> currencyList = new List<Currency>();
            currencyList = entity.Currencies.ToList();
            foreach (Currency c in currencyList)
            {
                cboCurrency.Items.Add(c.CurrencyCode);
            }
            int id = 0;
            if (SettingController.DefaultCurrency != 0)
            {
                id = Convert.ToInt32(SettingController.DefaultCurrency);
                curreObj = entity.Currencies.FirstOrDefault(x => x.Id == id);
                cboCurrency.Text = curreObj.CurrencyCode;
            }
            //txtExchangeRate.Text = SettingController.DefaultExchangeRate.ToString();
            #endregion

            if (!isDebt)
            {
                total = (long)(DetailList.Sum(x => x.TotalAmount) - ExtraDiscount - BDDiscount - MCDiscount);
                lblTotalCost.Text = Utility.CalculateExchangeRate(id, total).ToString();
                TotalAmt = Convert.ToDecimal(lblTotalCost.Text);
                AmountWithExchange = Convert.ToDecimal(lblTotalCost.Text);
            }
            else
            {
                foreach (Transaction tObj in CreditTransaction)
                {
                    if (tObj.Transaction1.Count <= 0)
                    {
                        totalAmount += (long)tObj.TotalAmount - (long)tObj.RecieveAmount;
                    }
                    //Has refund
                    else
                    {
                        totalAmount += (long)tObj.TotalAmount - (long)tObj.RecieveAmount;
                        foreach (Transaction Refund in tObj.Transaction1.Where(x=>x.IsDeleted != true))
                        {
                            totalAmount -= (long)Refund.RecieveAmount;
                        }
                    }
                    if (tObj.UsePrePaidDebts != null)
                    {
                        long prepaid = (long)tObj.UsePrePaidDebts.Sum(x => x.UseAmount);
                        totalAmount -= prepaid;
                    }
                }
                foreach (Transaction tObj in PrePaidTransaction)
                {
                    prePaidAmount += (long)tObj.TotalAmount;
                    long useAmount = (tObj.UsePrePaidDebts1 == null) ? 0 : (int)tObj.UsePrePaidDebts1.Sum(x => x.UseAmount);
                    prePaidAmount -= useAmount;
                }
                DebtAmount = (totalAmount - prePaidAmount);
                lblTotalCost.Text = Utility.CalculateExchangeRate(id, DebtAmount).ToString();
             
            }
            txtReceiveAmount.Text = lblTotalCost.Text;
           // txtReceiveAmount.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           // string _defaultPrinter = Utility.GetDefaultPrinter();
            Boolean hasError = false;
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            long receiveAmount = 0;
            long totalCost = (long)DetailList.Sum(x => x.TotalAmount) - ExtraDiscount - (long)BDDiscount - (long)MCDiscount;
            //total cost wint unit price
            long unitpriceTotalCost = (long)DetailList.Sum(x => x.UnitPrice * x.Qty);
            Int64.TryParse(txtReceiveAmount.Text, out receiveAmount);
            decimal totalCashSaleAmount = Convert.ToDecimal(lblTotalCost.Text);

            if (cboCurrency.SelectedIndex == -1)
            {
                tp.SetToolTip(cboCurrency, "Error");
                tp.Show("Please select currency!", cboCurrency);
                return;
            }
            string currVal = cboCurrency.Text;
            int currencyId = (from c in entity.Currencies where c.CurrencyCode == currVal select c.Id).SingleOrDefault();
            Currency cu = entity.Currencies.FirstOrDefault(x => x.Id == currencyId);

            //Validation
            if (receiveAmount == 0)
            {
                tp.SetToolTip(txtReceiveAmount, "Error");
                tp.Show("Please fill up receive amount!", txtReceiveAmount);
                hasError = true;
            }
            else if (receiveAmount < AmountWithExchange)
            {
                tp.SetToolTip(txtReceiveAmount, "Error");
                tp.Show("Receive amount must be greater than total cost!", txtReceiveAmount);
                hasError = true;
            }

            if (!hasError)
            {

                System.Data.Objects.ObjectResult<String> Id;
                CurrencySymbol = string.Empty;
                Transaction insertedTransaction = new Transaction();
                List<Transaction> RefundList = new List<Transaction>();
                decimal change = 0;
                if (cu.CurrencyCode == "USD")
                {
                    totalCashSaleAmount = (decimal)totalCashSaleAmount * (decimal)cu.LatestExchangeRate;
                    receiveAmount = receiveAmount * (long)cu.LatestExchangeRate;
                    CurrencySymbol = "$";
                    change = Convert.ToDecimal(lblChanges.Text) * (decimal)cu.LatestExchangeRate;
                }
                else
                {
                    CurrencySymbol = "Ks";
                    change = Convert.ToDecimal(lblChanges.Text);
                }
                if (!isDebt)
                {
                    Id = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, ExtraTax + Tax, ExtraDiscount + Discount, totalCost, receiveAmount, null, CustomerId, MCDiscount, BDDiscount, MemberTypeId, MCDiscountPercent, false, "", IsWholeSale,CustomerTypeId,RoomId==0 ? null : RoomId, 0);
                    entity = new POSEntities();
                    resultId = Id.FirstOrDefault().ToString();
                    insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                    string TId = insertedTransaction.Id;
                    insertedTransaction.IsDeleted = false;
                    insertedTransaction.ReceivedCurrencyId = currencyId;
                    foreach (TransactionDetail detail in DetailList)
                    {
                        detail.IsDeleted = false;//Update IsDelete (Null to 0)
                        if (detail.ConsignmentPrice == null)
                        {
                            detail.ConsignmentPrice = 0;
                        }

                        detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();

                        Boolean? IsConsignmentPaid = Utility.IsConsignmentPaid(detail.Product);
                    //    var detailID = entity.InsertTransactionDetail(TId, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDouble(detail.DiscountRate), Convert.ToDouble(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted, detail.ConsignmentPrice, IsConsignmentPaid).SingleOrDefault();
                        var detailID = entity.InsertTransactionDetail(TId, Convert.ToInt32(detail.ProductId), Convert.ToInt32(detail.Qty), Convert.ToInt32(detail.UnitPrice), Convert.ToDouble(detail.DiscountRate), Convert.ToDouble(detail.TaxRate), Convert.ToInt32(detail.TotalAmount), detail.IsDeleted, detail.ConsignmentPrice, IsConsignmentPaid,detail.IsFOC,Convert.ToInt32(detail.SellingPrice)).SingleOrDefault();
                        

                        detail.Product.Qty = detail.Product.Qty - detail.Qty;


                        //save in stocktransaction

                        Stock_Transaction st = new Stock_Transaction();
                        st.ProductId = detail.Product.Id;
                        Qty = Convert.ToInt32(detail.Qty);
                        st.Sale = Qty;
                        productList.Add(st);
                        Qty = 0;


                        if (detail.Product.Brand.Name == "Special Promotion")
                        {
                            List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                            if (wList.Count > 0)
                            {
                                foreach (WrapperItem w in wList)
                                {
                                    Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                    wpObj.Qty = wpObj.Qty - detail.Qty;

                                    SPDetail spDetail = new SPDetail();
                                    spDetail.TransactionDetailID = Convert.ToInt32(detailID);
                                    spDetail.DiscountRate = detail.DiscountRate;
                                    spDetail.ParentProductID = w.ParentProductId;
                                    spDetail.ChildProductID = w.ChildProductId;
                                    spDetail.Price = wpObj.Price;
                                    entity.insertSPDetail(spDetail.TransactionDetailID, spDetail.ParentProductID, spDetail.ChildProductID, spDetail.Price, spDetail.DiscountRate, "PC");
                                    //entity.SPDetails.Add(spDetail);
                                }
                            }
                        }

                        entity.SaveChanges();
                    }
                    //save in stocktransaction
                    Save_SaleQty_ToStockTransaction(productList);
                    productList.Clear();

                    ExchangeRateForTransaction ex = new ExchangeRateForTransaction();
                    ex.TransactionId = TId;
                    ex.CurrencyId = cu.Id;
                    ex.ExchangeRate = Convert.ToInt32(cu.LatestExchangeRate);
                    entity.ExchangeRateForTransactions.Add(ex);
                    entity.SaveChanges();


                    #region purchase
                    // for Purchase Detail and PurchaseDetailInTransacton.

                    foreach (TransactionDetail detail in insertedTransaction.TransactionDetails)
                    {

                        int Qty = Convert.ToInt32(detail.Qty);
                        int pId = Convert.ToInt32(detail.ProductId);


                        // Get purchase detail with same product Id and order by purchase date ascending
                        List<APP_Data.PurchaseDetail> pulist = (from p in entity.PurchaseDetails
                                                                join m in entity.MainPurchases on p.MainPurchaseId equals m.Id
                                                                where p.ProductId == pId && p.IsDeleted == false && m.IsCompletedInvoice == true && p.CurrentQy > 0
                                                                orderby p.Date ascending
                                                                select p).ToList();

                        if (pulist.Count > 0)
                        {
                            int TotalQty = Convert.ToInt32(pulist.Sum(x => x.CurrentQy));

                            if (TotalQty >= Qty)
                            {
                                foreach (PurchaseDetail p in pulist)
                                {
                                    if (Qty > 0)
                                    {
                                        if (p.CurrentQy >= Qty)
                                        {
                                            PurchaseDetailInTransaction pdObjInTran = new PurchaseDetailInTransaction();
                                            pdObjInTran.ProductId = pId;
                                            pdObjInTran.TransactionDetailId = detail.Id;
                                            pdObjInTran.PurchaseDetailId = p.Id;
                                            pdObjInTran.Date = detail.Transaction.DateTime;
                                            pdObjInTran.Qty = Qty;
                                            p.CurrentQy = p.CurrentQy - Qty;
                                            Qty = 0;

                                            entity.PurchaseDetailInTransactions.Add(pdObjInTran);
                                            entity.Entry(p).State = EntityState.Modified;
                                            entity.SaveChanges();
                                            break;
                                        }
                                        else if (p.CurrentQy <= Qty)
                                        {
                                            PurchaseDetailInTransaction pdObjInTran = new PurchaseDetailInTransaction();
                                            pdObjInTran.ProductId = pId;
                                            pdObjInTran.TransactionDetailId = detail.Id;
                                            pdObjInTran.PurchaseDetailId = p.Id;
                                            pdObjInTran.Date = detail.Transaction.DateTime;
                                            pdObjInTran.Qty = p.CurrentQy;

                                            Qty = Convert.ToInt32(Qty - p.CurrentQy);
                                            p.CurrentQy = 0;
                                            entity.PurchaseDetailInTransactions.Add(pdObjInTran);
                                            entity.Entry(p).State = EntityState.Modified;
                                            entity.SaveChanges();

                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                   
                    //Print Invoice
                    #region [ Print ]
                    if (IsPrint)
                    {
                    
                    dsReportTemp dsReport = new dsReportTemp();
                    dsReportTemp.ItemListDataTable dtReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["ItemList"];
                    int _tAmt = 0;

                    foreach (TransactionDetail transaction in DetailList)
                    {
                        dsReportTemp.ItemListRow newRow = dtReport.NewItemListRow();
                        newRow.ItemId = transaction.Product.ProductCode;
                        newRow.Name = transaction.Product.Name;
                        newRow.Qty = transaction.Qty.ToString();
                        newRow.DiscountPercent = transaction.DiscountRate.ToString();
                        newRow.TotalAmount = (int)transaction.UnitPrice * (int)transaction.Qty;
                        switch (Utility.GetDefaultPrinter())
                        {
                            case "A4 Printer":
                                newRow.UnitPrice = transaction.UnitPrice.ToString();
                                break;
                            case "Slip Printer":
                                newRow.UnitPrice = "1@" + transaction.UnitPrice.ToString();
                                break;
                        }
              
                        _tAmt += newRow.TotalAmount;
                        dtReport.AddItemListRow(newRow);
                    }
                    
                    string reportPath = "";
                    ReportViewer rv = new ReportViewer();
                    ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
                
                     reportPath = Application.StartupPath + Utility.GetReportPath("Cash");
                    
                 
                    rv.Reset();
                    rv.LocalReport.ReportPath = reportPath;
                    rv.LocalReport.DataSources.Add(rds);

                    Utility.Slip_Log(rv);
                    //switch (Utility.GetDefaultPrinter())
                    //{

                    //    case "Slip Printer":
                    //        Utility.Slip_Footer(rv);
                    //        break;
                    //}
                    Utility.Slip_A4_Footer(rv);
                    APP_Data.Customer cus = entity.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

                    ReportParameter CustomerName = new ReportParameter("CustomerName", cus.Name);
                    rv.LocalReport.SetParameters(CustomerName);

                    if (Convert.ToInt32(insertedTransaction.MCDiscountAmt) != 0)
                    {
                        Int64 _mcDiscountAmt = Convert.ToInt64(insertedTransaction.MCDiscountAmt);
                        ReportParameter MCDiscountAmt = new ReportParameter("MCDiscount", "-" + _mcDiscountAmt.ToString());
                        rv.LocalReport.SetParameters(MCDiscountAmt);
                    }

                    else if (Convert.ToInt32(insertedTransaction.BDDiscountAmt) != 0)
                    {
                        Int64 _bcDiscountAmt = Convert.ToInt64(insertedTransaction.BDDiscountAmt);
                        ReportParameter BCDiscountAmt = new ReportParameter("MCDiscount", "-" + _bcDiscountAmt.ToString());
                        rv.LocalReport.SetParameters(BCDiscountAmt);
                    }
                    else
                    {
                        ReportParameter BCDiscountAmt = new ReportParameter("MCDiscount", "0");
                        rv.LocalReport.SetParameters(BCDiscountAmt);
                    }

                    ReportParameter TAmt = new ReportParameter("TAmt", _tAmt.ToString());
                    rv.LocalReport.SetParameters(TAmt);

                    ReportParameter ShopName = new ReportParameter("ShopName", SettingController.ShopName);
                    rv.LocalReport.SetParameters(ShopName);

                    ReportParameter BranchName = new ReportParameter("BranchName", SettingController.BranchName);
                    rv.LocalReport.SetParameters(BranchName);

                    ReportParameter Phone = new ReportParameter("Phone", SettingController.PhoneNo);
                    rv.LocalReport.SetParameters(Phone);

                    ReportParameter OpeningHours = new ReportParameter("OpeningHours", SettingController.OpeningHours);
                    rv.LocalReport.SetParameters(OpeningHours);

                    ReportParameter TransactionId = new ReportParameter("TransactionId", resultId.ToString());
                    rv.LocalReport.SetParameters(TransactionId);

                    APP_Data.Counter c = entity.Counters.Where(x => x.Id == MemberShip.CounterId).FirstOrDefault();

                    ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                    rv.LocalReport.SetParameters(CounterName);

                    ReportParameter PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                    rv.LocalReport.SetParameters(PrintDateTime);

                    ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                    rv.LocalReport.SetParameters(CasherName);

                    Int64 totalAmountRep = insertedTransaction.TotalAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TotalAmount);
                    ReportParameter TotalAmount = new ReportParameter("TotalAmount", totalAmountRep.ToString());
                    rv.LocalReport.SetParameters(TotalAmount);

                    Int64 taxAmountRep = insertedTransaction.TaxAmount == null ? 0 : Convert.ToInt64(insertedTransaction.TaxAmount);
                    ReportParameter TaxAmount = new ReportParameter("TaxAmount", taxAmountRep.ToString());
                    rv.LocalReport.SetParameters(TaxAmount);

                    ReportParameter CurrencyCode = new ReportParameter("CurrencyCode", CurrencySymbol);
                    rv.LocalReport.SetParameters(CurrencyCode);

                    Int64 disAmountRep = insertedTransaction.DiscountAmount == null ? 0 : Convert.ToInt64(insertedTransaction.DiscountAmount);

                    if (disAmountRep == 0)
                    {
                        ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", disAmountRep.ToString());
                        rv.LocalReport.SetParameters(DiscountAmount);
                    }
                    else
                    {
                        ReportParameter DiscountAmount = new ReportParameter("DiscountAmount", "-" + disAmountRep.ToString());
                        rv.LocalReport.SetParameters(DiscountAmount);
                    }

                    ReportParameter PaidAmount = new ReportParameter("PaidAmount", txtReceiveAmount.Text);
                    rv.LocalReport.SetParameters(PaidAmount);

                    ReportParameter Change = new ReportParameter("Change", lblChanges.Text);
                    rv.LocalReport.SetParameters(Change);


                    ReportParameter RoomNo = new ReportParameter("RoomNo", Utility.GetRoomNo(RoomId));
                    rv.LocalReport.SetParameters(RoomNo);

                    if (Utility.GetDefaultPrinter() == "A4 Printer")
                    {
                        ReportParameter CusAddress = new ReportParameter("CusAddress", cus.Address);
                        rv.LocalReport.SetParameters(CusAddress);
                    }


                    //for (int i = 0; i <= 1; i++) //Edit By ZMH
                    //{
                    //    PrintDoc.PrintReport(rv, "Slip");
                    //}

                  
                    //PrintDoc.PrintReport(rv, "Slip");
                    //////int copy=SettingController.DefaultNoOfCopies;
                    //////for (int i = 0; i < copy; i++)
                    //////{
                    //////    PrintDoc.PrintReport(rv, Utility.GetDefaultPrinter());
                    //////}
                    Utility.Get_Print(rv);

                    #endregion
                    }

                    _result = MessageShow();
                }
                else
                {
                    if (lblChangesText.Text == "Changes")
                    {
                        receiveAmount -= Convert.ToInt64(lblChanges.Text);
                    }
                    long totalAmount = receiveAmount + prePaidAmount;
                    long totalCredit = 0;
                    Int64.TryParse(lblTotalCost.Text, out totalCredit);
                    long DebtAmount = 0;
                    if (totalAmount != 0)
                    {
                        if (CreditTransaction.Count > 0)
                        {
                            int index = CreditTransaction.Count;
                            for (int outer = index - 1; outer >= 1; outer--)
                            {
                                for (int inner = 0; inner < outer; inner++)
                                {
                                    if (CreditTransaction[inner].TotalAmount - CreditTransaction[inner].RecieveAmount < CreditTransaction[inner + 1].TotalAmount - CreditTransaction[inner + 1].RecieveAmount)
                                    {
                                        Transaction t = CreditTransaction[inner];
                                        CreditTransaction[inner] = CreditTransaction[inner + 1];
                                        CreditTransaction[inner + 1] = t;
                                    }
                                }
                            }
                            foreach (Transaction CT in CreditTransaction)
                            {
                                long CreditAmount = 0;
                                CreditAmount = (long)CT.TotalAmount - (long)CT.RecieveAmount;
                                RefundList = (from tr in entity.Transactions where tr.ParentId == CT.Id && tr.Type == TransactionType.CreditRefund select tr).ToList();
                                CustomerTypeId = Convert.ToInt32(CT.CustomerTypeId);
                                RoomId = CT.RoomId;
                                if (RefundList.Count > 0)
                                {
                                    foreach (Transaction TRefund in RefundList)
                                    {
                                        CreditAmount -= (long)TRefund.RecieveAmount;
                                    }
                                }
                                if (CT.UsePrePaidDebts != null)
                                {
                                    long prePaid = (long)CT.UsePrePaidDebts.Sum(x => x.UseAmount);
                                    CreditAmount -= prePaid;
                                }
                                if (CreditAmount <= totalAmount)
                                {
                                    //CT.IsPaid = true;
                                    //entity.SaveChanges();
                                     CreditT = (from t in entity.Transactions where t.Id == CT.Id select t).FirstOrDefault<Transaction>();
                                    CreditT.IsPaid = true;
                                   
                                    TranIdList.Add(CreditT.Id);
                                    entity.Entry(CreditT).State = EntityState.Modified;
                                    entity.SaveChanges();
                                    totalAmount -= CreditAmount;
                                    if (CreditAmount <= receiveAmount)
                                    {
                                        DebtAmount += CreditAmount;
                                        receiveAmount -= CreditAmount;
                                    }
                                    else
                                    {
                                        CreditAmount -= receiveAmount;
                                        DebtAmount += receiveAmount;
                                        receiveAmount = 0;
                                        foreach (Transaction PrePaidDebtTrans in PrePaidTransaction)
                                        {
                                            long PrePaidamount = 0;
                                            //int useAmount = 0;
                                            int useAmount = (PrePaidDebtTrans.UsePrePaidDebts1 == null) ? 0 : (int)PrePaidDebtTrans.UsePrePaidDebts1.Sum(x => x.UseAmount);
                                            PrePaidamount = (long)PrePaidDebtTrans.TotalAmount - useAmount;
                                            //if (CreditAmount >= PrePaidamount)
                                            //{
                                            //    PrePaidDebtTrans.IsActive = true;
                                            //    //entity.Entry(PrePaidDebtTrans).State = System.Data.EntityState.Modified;
                                            //}

                                            if (CreditAmount >= PrePaidamount)
                                            {
                                                //PrePaidDebtTrans.IsActive = true;
                                                //entity.SaveChanges();
                                                Transaction PD = (from PT in entity.Transactions where PT.Id == PrePaidDebtTrans.Id select PT).FirstOrDefault<Transaction>();
                                                PD.IsActive = true;
                                                entity.Entry(PD).State = EntityState.Modified;
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)PrePaidamount;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = CT.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CreditAmount -= PrePaidamount;
                                            }
                                            else
                                            {
                                                UsePrePaidDebt usePrePaidDObj = new UsePrePaidDebt();
                                                usePrePaidDObj.UseAmount = (int)CreditAmount;
                                                usePrePaidDObj.PrePaidDebtTransactionId = PrePaidDebtTrans.Id;
                                                usePrePaidDObj.CreditTransactionId = CT.Id;
                                                usePrePaidDObj.CashierId = MemberShip.UserId;
                                                usePrePaidDObj.CounterId = MemberShip.CounterId;
                                                entity.UsePrePaidDebts.Add(usePrePaidDObj);
                                                entity.SaveChanges();
                                                CreditAmount -= PrePaidamount;
                                            }
                                        }

                                        PrePaidTransaction = (from PDT in entity.Transactions where PDT.Type == TransactionType.Prepaid && PDT.IsActive == false select PDT).ToList();
                                    }
                                }
                            }
                            if (DebtAmount > 0)
                            {
                                string joinedTranIdList = string.Join(",", TranIdList);
                                System.Data.Objects.ObjectResult<string> DebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Settlement, true, true, 1, 0, 0, DebtAmount, DebtAmount, null, CustomerId, MCDiscount, BDDiscount, MemberTypeId, MCDiscountPercent, true, joinedTranIdList, IsWholeSale,CustomerTypeId,RoomId, 0);
                                string _Debt = DebtId.FirstOrDefault().ToString();

                                foreach (var t in TranIdList)
                                {
                                    var result = (from tr in entity.Transactions where tr.Id == t select tr).FirstOrDefault();

                                   // Transaction _tt = new Transaction();
                                    result.TranVouNos = _Debt;
                                    result.IsSettlement = true;
                                    entity.Entry(result).State = EntityState.Modified;
                                    entity.SaveChanges();
                                }
                                
                                

                                entity = new POSEntities();
                                resultId = _Debt;
                                insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                                insertedTransaction.ReceivedCurrencyId = cu.Id;
                                ExchangeRateForTransaction ex = new ExchangeRateForTransaction();
                                ex.TransactionId = resultId;
                                ex.CurrencyId = cu.Id;
                                ex.ExchangeRate = Convert.ToInt32(cu.LatestExchangeRate);
                                entity.ExchangeRateForTransactions.Add(ex);


                                 //  Transaction CreditT = (from t in entity.Transactions where t.Id == CT.Id select t).FirstOrDefault<Transaction>();
                                  
                                   // CreditT.TranVouNos = CreditT
                             
                                    entity.SaveChanges();
                                entity.SaveChanges();
                            }
                        }
                        else
                        {
                            totalAmount -= prePaidAmount;
                            receiveAmount -= prePaidAmount;
                            //System.Data.Objects.ObjectResult<string> PreDebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.PrepaidDebt, true, false, 1, 0, 0, totalAmount, totalAmount, null, customerId);
                            //entity.SaveChanges();
                        }
                    }
                    if (receiveAmount > 0)
                    {
                        System.Data.Objects.ObjectResult<string> PreDebtId = entity.InsertTransaction(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Prepaid, true, false, 1, 0, 0, receiveAmount, receiveAmount, null, CustomerId, MCDiscount, BDDiscount, MemberTypeId, MCDiscountPercent, false, "", IsWholeSale,CustomerTypeId,RoomId, 0);
                        entity.SaveChanges();
                        if (DebtAmount == 0)
                        {
                            entity = new POSEntities();
                            resultId = PreDebtId.FirstOrDefault().ToString();
                            insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                            insertedTransaction.ReceivedCurrencyId = cu.Id;
                            ExchangeRateForTransaction ex = new ExchangeRateForTransaction();
                            ex.TransactionId = resultId;
                            ex.CurrencyId = cu.Id;
                            ex.ExchangeRate = Convert.ToInt32(cu.LatestExchangeRate);
                            entity.ExchangeRateForTransactions.Add(ex);
                            entity.SaveChanges();
                        }

                    }
                    if (isDraft)
                    {
                        Transaction draft = (from trans in entity.Transactions where trans.Id == DraftId select trans).FirstOrDefault<Transaction>();
                        if (draft != null)
                        {
                            draft.TransactionDetails.Clear();
                            var Detail = entity.TransactionDetails.Where(d => d.TransactionId == draft.Id);
                            foreach (var d in Detail)
                            {
                                entity.TransactionDetails.Remove(d);
                            }
                            entity.Transactions.Remove(draft);
                            entity.SaveChanges();
                        }
                    }


                    //Print Invoice
                    #region [ Print ]
                    if (IsPrint)
                    {
                    
                    string reportPath = "";
                    ReportViewer rv = new ReportViewer();
                    //ReportDataSource rds = new ReportDataSource("DataSet1", dsReport.Tables["ItemList"]);
                    reportPath = Application.StartupPath + Utility.GetReportPath("Settlement");
                    rv.Reset();
                    rv.LocalReport.ReportPath = reportPath;
                    // rv.LocalReport.DataSources.Add(rds);

                    Utility.Slip_Log(rv);
                    //switch (Utility.GetDefaultPrinter())
                    //{

                    //    case "Slip Printer":
                    //        Utility.Slip_Footer(rv);
                    //        break;
                    //}
                    Utility.Slip_A4_Footer(rv);
                    APP_Data.Customer cus = entity.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();

                    ReportParameter CustomerName = new ReportParameter("CustomerName", cus.Name);
                    rv.LocalReport.SetParameters(CustomerName);


                    ReportParameter ShopName = new ReportParameter("ShopName", SettingController.ShopName);
                    rv.LocalReport.SetParameters(ShopName);

                    ReportParameter BranchName = new ReportParameter("BranchName", SettingController.BranchName);
                    rv.LocalReport.SetParameters(BranchName);

                    ReportParameter Phone = new ReportParameter("Phone", SettingController.PhoneNo);
                    rv.LocalReport.SetParameters(Phone);

                    ReportParameter OpeningHours = new ReportParameter("OpeningHours", SettingController.OpeningHours);
                    rv.LocalReport.SetParameters(OpeningHours);

                    ReportParameter TransactionId = new ReportParameter("TransactionId", resultId.ToString());
                    rv.LocalReport.SetParameters(TransactionId);

                    APP_Data.Counter c = entity.Counters.Where(x => x.Id == MemberShip.CounterId).FirstOrDefault();

                    ReportParameter CounterName = new ReportParameter("CounterName", c.Name);
                    rv.LocalReport.SetParameters(CounterName);

                        ReportParameter PrintDateTime = new ReportParameter();
                        switch (Utility.GetDefaultPrinter())
                        {
                            case "A4 Printer":
                                            PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd-MMM-yyyy"));
                        rv.LocalReport.SetParameters(PrintDateTime);
                                break;
                            case "Slip Printer":
                                PrintDateTime = new ReportParameter("PrintDateTime", DateTime.Now.ToString("dd/MM/yyyy hh:mm"));
                        rv.LocalReport.SetParameters(PrintDateTime);
                                break;
                        }

                    ReportParameter CasherName = new ReportParameter("CasherName", MemberShip.UserName);
                    rv.LocalReport.SetParameters(CasherName);


                    ReportParameter TotalAmount = new ReportParameter("TotalAmount", lblTotalCost.Text.ToString());
                    rv.LocalReport.SetParameters(TotalAmount);



                    ReportParameter PaidAmount = new ReportParameter("PaidAmount", txtReceiveAmount.Text);
                    rv.LocalReport.SetParameters(PaidAmount);

                    int balance = Convert.ToInt32(lblTotalCost.Text) - Convert.ToInt32(txtReceiveAmount.Text);
                    balance = balance < 0 ? 0 : balance;
                    ReportParameter Balance = new ReportParameter("Balance", balance.ToString());
                    rv.LocalReport.SetParameters(Balance);
              
                    int _change = Convert.ToInt32(txtReceiveAmount.Text) - Convert.ToInt32(lblTotalCost.Text);

                    _change = _change < 0 ? 0 : _change;
                    ReportParameter Change = new ReportParameter("Change", _change.ToString());
                    rv.LocalReport.SetParameters(Change);

                    if (Utility.GetDefaultPrinter() == "A4 Printer")
                    {
                        ReportParameter CusAddress = new ReportParameter("CusAddress", cus.Address);
                        rv.LocalReport.SetParameters(CusAddress);
                    }

                    ReportParameter RoomNo = new ReportParameter("RoomNo", Utility.GetRoomNo(RoomId));
                    rv.LocalReport.SetParameters(RoomNo);

                 // //  PrintDoc.PrintReport(rv,Utility.GetDefaultPrinter());
                    Utility.Get_Print(rv);
                    #endregion
                    }
                    _result = MessageShow();
                }
                //entity = new POSEntities();
                //string resultId = Id.FirstOrDefault().ToString();
                //Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();


                //foreach (TransactionDetail detail in DetailList)
                //{
                //    detail.Product = (from prod in entity.Products where prod.Id == (long)detail.ProductId select prod).FirstOrDefault();
                //    detail.Product.Qty = detail.Product.Qty - detail.Qty;
                //    insertedTransaction.TransactionDetails.Add(detail);
                //}


                if (!isDebt)
                {
                    if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                    {
                        Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];

                        newForm.Clear();
                    }
                }
                else
                {
                    if (System.Windows.Forms.Application.OpenForms["CustomerDetail"] != null)
                    {
                        CustomerDetail newForm = (CustomerDetail)System.Windows.Forms.Application.OpenForms["CustomerDetail"];
                        newForm.Reload();
                    }
                }
                this.Dispose();
            }
            if (_result.Equals(DialogResult.OK))
            {
                Common cm = new Common();
                cm.MemberTypeId = MemberTypeId;
                cm.TotalAmt = TotalAmt;
                cm.CustomerId = CustomerId;
                cm.type = 'S';
                cm.TransactionId = resultId;
                cm.Get_MType();
                if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                {
                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];

                    newForm.Clear();
                }
            }
        }

        private DialogResult MessageShow()
        {
            DialogResult result = MessageBox.Show("Payment Completed", "mPOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return result;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PaidByCash_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtReceiveAmount);
            tp.Hide(cboCurrency);
        }

        private void txtReceiveAmount_KeyUp(object sender, KeyEventArgs e)
        {
            int amount = 0;
            Int32.TryParse(txtReceiveAmount.Text, out amount);
            int Cost = 0;
            Int32.TryParse(lblTotalCost.Text, out Cost);
            if (!isDebt)
            {
                lblChanges.Text = (amount - (DetailList.Sum(x => x.TotalAmount) - ExtraDiscount - MCDiscount - BDDiscount )).ToString();
            }
            else
            {
                string currVal = cboCurrency.Text;
                int cId = (from c in entity.Currencies where c.CurrencyCode == currVal select c.Id).SingleOrDefault();
                Currency currencyObj = entity.Currencies.FirstOrDefault(x => x.Id == cId);
                if (amount >= DebtAmount)
                {
                    lblChanges.Text = (amount - DebtAmount).ToString();
                    lblChangesText.Text = "Changes";
                }
                else
                {
                    lblChangesText.Text = "Net Payable";
                    lblChanges.Text = (DebtAmount - amount).ToString();
                }
            }
        }

        private void txtReceiveAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReceiveAmount_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && char.IsLetter('.'))
            {
                e.Handled = true;
            }
        }

        private void txtReceiveAmount_KeyUp_1(object sender, KeyEventArgs e)
        {
            decimal amount = 0;
            decimal.TryParse(txtReceiveAmount.Text, out amount);
            decimal Cost = 0;
            decimal.TryParse(lblTotalCost.Text, out Cost);

            if (txtReceiveAmount.Text != string.Empty)
            {


                if (!isDebt)
                {
                    //lblChanges.Text = (amount - (DetailList.Sum(x => x.TotalAmount) - ExtraDiscount - MCDiscount - BDDiscount + ExtraTax)).ToString();
                    lblChanges.Text = (amount - Cost).ToString();
                }
                else
                {
                    decimal DAmount = Convert.ToDecimal(lblTotalCost.Text);
                    string currVal = cboCurrency.Text;
                    int cId = (from c in entity.Currencies where c.CurrencyCode == currVal select c.Id).SingleOrDefault();
                    Currency currencyObj = entity.Currencies.FirstOrDefault(x => x.Id == cId);
                    if (amount >= DAmount)
                    {
                        lblChanges.Text = (amount - DAmount).ToString();
                        lblChangesText.Text = "Changes";
                    }
                    else
                    {
                        lblChangesText.Text = "Net Payable";
                        lblChanges.Text = (DAmount - amount).ToString();
                    }
                }
            }
           
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currencyId = 0;
            string currVal = cboCurrency.Text;
            currencyId = (from c in entity.Currencies where c.CurrencyCode == currVal select c.Id).SingleOrDefault();
            if (currencyId != 0)
            {
                Currency cu = entity.Currencies.FirstOrDefault(x => x.Id == currencyId);
                if (cu != null)
                {
                    if (!isDebt)
                    {

                        lblTotalCost.Text = Utility.CalculateExchangeRate(cu.Id, total).ToString();
                        AmountWithExchange = Convert.ToDecimal(lblTotalCost.Text);
                        //if (txtReceiveAmount.Text != null)
                        //{
                        //    receive = Convert.ToDecimal(txtReceiveAmount.Text);
                        //}
                        //lblChanges.Text = (AmountWithExchange - receive).ToString();
                        decimal receive = 0;

                        Decimal.TryParse(txtReceiveAmount.Text, out receive);
                        decimal changes = AmountWithExchange - receive;

                        lblChanges.Text = changes.ToString();
                    }
                    else
                    {

                        lblTotalCost.Text = Utility.CalculateExchangeRate(cu.Id, DebtAmount).ToString();
                        AmountWithExchange = Convert.ToDecimal(lblTotalCost.Text);
                        decimal receive = 0;

                        Decimal.TryParse(txtReceiveAmount.Text, out receive);
                        decimal changes = AmountWithExchange - receive;
                        lblChanges.Text = changes.ToString();
                    }

                }
            }
        }

        #region Function
        #region for saving Sale Qty in Stock Transaction table
        private void Save_SaleQty_ToStockTransaction(List<Stock_Transaction> productList)
        {
            int _year, _month;

            _year = System.DateTime.Now.Year;
            _month = System.DateTime.Now.Month;
            Utility.Sale_Run_Process(_year, _month, productList);
        }
        #endregion
        #endregion
    }
}
