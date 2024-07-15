using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using POS.APP_Data;

namespace POS
{
    public partial class Loc_ItemSummary : Form
    {
        #region Variable
        List<Transaction> DtransList = new List<Transaction>();
        POSEntities entity = new POSEntities();
        //List<Product> itemList = new List<Product>();
        List<ReportItemSummary> itemList = new List<ReportItemSummary>();
        List<ReportItemSummary> IList = new List<ReportItemSummary>();
        long CashTotal = 0, CreditTotal = 0, FOCAmount = 0, MPUAmount = 0, TesterAmount = 0, GiftCardAmount = 0, Total = 0, CreditReceive = 0, RefundAmt = 0; long UseGiftAmount = 0; long CashAmtFromGiftCard = 0;
        long totalSettlement = 0;
        List<Transaction> AllTranslist = new List<Transaction>();
         List<ReportItemSummary> FinalResultList = new List<ReportItemSummary>();
        #endregion        
        
        #region Event
        public Loc_ItemSummary()
        {
            InitializeComponent();
        }

        private void Loc_ItemSummary_Load(object sender, EventArgs e)
        {
            LoadData();
            this.reportViewer1.RefreshReport();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rdbSale_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

       
        private void chkCash_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkGiftCard_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkMPU_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkCredit_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkFOC_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chkTester_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        

        #region Function

        private void LoadData()
        {
            DateTime fromDate = dtFrom.Value.Date;
            DateTime toDate = dtTo.Value.Date;
           // bool IsSale = rdbSale.Checked;
            //bool IsCash = chkCash.Checked, IsCredit = chkCredit.Checked, IsFOC = chkFOC.Checked, IsMPU = chkMPU.Checked, IsGiftCard = chkGiftCard.Checked, IsTester = chkTester.Checked;
            bool IsCash = true, IsCredit = true, IsFOC = true, IsMPU = true, IsGiftCard = true, IsTester = true ,IsRefund = true;
            CashTotal = 0; CreditTotal = 0; FOCAmount = 0; MPUAmount = 0; TesterAmount = 0; GiftCardAmount = 0; RefundAmt = 0; Total = 0;
            IList.Clear();
            itemList.Clear();
            System.Data.Objects.ObjectResult<SelectItemListByDate_Result> resultList;
            //System.Data.Objects.ObjectResult<SelectItemListByDate_Result> FinalResultList ;
            //FinalResultList = null;
            List<Transaction> transList = new List<Transaction>();
            FinalResultList = new List<ReportItemSummary>();
            //if (IsSale)
            //{
                transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && (t.Type == TransactionType.Sale || t.Type == TransactionType.Credit || t.Type == TransactionType.Refund || t.Type == TransactionType.CreditRefund) && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            //}
            //else
            //{
            //    transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && (t.Type == TransactionType.Refund || t.Type == TransactionType.CreditRefund) && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
            //}
            DtransList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && (t.Type == TransactionType.Settlement || t.Type == TransactionType.Prepaid) && (t.IsDeleted == null || t.IsDeleted == false) select t).ToList<Transaction>();
           
            resultList = entity.SelectItemListByDate(fromDate, toDate);
            foreach (SelectItemListByDate_Result r in resultList)
            {
                ReportItemSummary p = new ReportItemSummary();
                p.Id = r.ItemId;
                p.Name = r.ItemName;
                p.Qty = (int)r.ItemQty;
                p.UnitPrice = Convert.ToInt32(r.UnitPrice);
                p.SellingPrice = Convert.ToInt32(r.SellingPrice);
                p.totalAmount = Convert.ToInt64(r.ItemTotalAmount);
                p.PaymentId = (int)r.PaymentTypeId;
                p.Size = r.Size;
                p.IsFOC = Convert.ToBoolean(r.IsFOC);

                //if (p.IsFOC == true)
                //{
                //    p.Remark = "FOC";
                //}
                //else
                //{
                //    p.Remark = "";
                //}
                p.Remark = r.Type;
                FinalResultList.Add(p);
            }
            AllTranslist.Clear();
            CreditReceive = 0;
            UseGiftAmount = 0;
            //if (IsSale == true)
            //{

            string[] type = {"Refund","CreditRefund"};
                if (IsCash)
                {
                    itemList.AddRange(FinalResultList.Where(x => x.PaymentId == 1 && !type.Contains(x.Remark)).ToList());
                    CashTotal += FinalResultList.Where(x => x.PaymentId == 1 && !type.Contains(x.Remark)).Sum(x => x.totalAmount);
                    AllTranslist.AddRange(transList.Where(x => x.PaymentTypeId == 1 && !type.Contains(x.Type)).ToList());
                }
                if (IsCredit)
                {
                    itemList.AddRange(FinalResultList.Where(x => x.PaymentId == 2 && !type.Contains(x.Remark)).ToList());
                    CreditTotal += FinalResultList.Where(x => x.PaymentId == 2 && !type.Contains(x.Remark)).Sum(x => x.totalAmount);
                    AllTranslist.AddRange(transList.Where(x => x.PaymentTypeId == 2 && !type.Contains(x.Type)).ToList());
                    CreditReceive += Convert.ToInt64(transList.Where(x => x.PaymentTypeId == 2 && !type.Contains(x.Type)).Sum(x => x.RecieveAmount));
                }
                if (IsGiftCard)
                {
                    itemList.AddRange(FinalResultList.Where(x => x.PaymentId == 3 && !type.Contains(x.Remark)).ToList());
                    GiftCardAmount += FinalResultList.Where(x => x.PaymentId == 3 && !type.Contains(x.Remark)).Sum(x => x.totalAmount);
                    AllTranslist.AddRange(transList.Where(x => x.PaymentTypeId == 3 && !type.Contains(x.Type)).ToList());
                    UseGiftAmount += Convert.ToInt64(transList.Where(x => x.PaymentTypeId == 3 && !type.Contains(x.Type)).Sum(x => x.GiftCardAmount));
                    CashAmtFromGiftCard += Convert.ToInt64(transList.Where(x => x.PaymentTypeId == 3 && !type.Contains(x.Type)).Sum(x => x.TotalAmount - x.GiftCardAmount));
                    //List<Transaction> GTransList = transList.Where(x => x.PaymentTypeId == 3).ToList();
                    //foreach (Transaction t in GTransList)
                    //{
                    //    List<GiftCardInTransaction> GList = t.GiftCardInTransactions.ToList();
                    //    foreach (GiftCardInTransaction g in GList)
                    //    {
                    //        UseGiftAmount += Convert.ToInt64(g.GiftCardAmount);
                    //    }
                    //}
                }
                 if (IsRefund)
                {

                    RefundAmt += FinalResultList.Where(x => type.Contains(x.Remark)).Sum(x => x.SellingPrice * x.Qty);
                    AllTranslist.AddRange(transList.Where(x => type.Contains(x.Type)).ToList());
                   // lblPeriod.Text = fromDate.ToString() + " to " + toDate.ToString();
                    // lblNumberofTransaction.Text = transList.Count.ToString();
              
                    //lblTotalAmount.Text = "";

                   // itemList.AddRange(FinalResultList.Where(x
                }
                if (IsFOC)
                {
                    itemList.AddRange(FinalResultList.Where(x => x.PaymentId == 4).ToList());
                  //  FOCAmount += FinalResultList.Where(x => x.PaymentId == 4).Sum(x => x.totalAmount);
                    FOCAmount += FinalResultList.Where(x => x.IsFOC == true).Sum(x => x.SellingPrice * x.Qty);
                    AllTranslist.AddRange(transList.Where(x => x.PaymentTypeId == 4).ToList());
                }
                if (IsMPU)
                {
                    itemList.AddRange(FinalResultList.Where(x => x.PaymentId == 5).ToList());
                    MPUAmount += FinalResultList.Where(x => x.PaymentId == 5).Sum(x => x.totalAmount);
                    AllTranslist.AddRange(transList.Where(x => x.PaymentTypeId == 5).ToList());
                }
                if (IsTester)
                {
                    itemList.AddRange(FinalResultList.Where(x => x.PaymentId == 6).ToList());
                    TesterAmount += FinalResultList.Where(x => x.PaymentId == 6).Sum(x => x.totalAmount);
                    AllTranslist.AddRange(transList.Where(x => x.PaymentTypeId == 6).ToList());
                }
                //var tmp = itemList.GroupBy(x => x.Id);
                //var result = tmp.Select(y => new
                //{
                //    Id = y.Key,
                //    Name = 
                //});
                //itemList = itemList.GroupBy(x => x.Id).SelectMany( x => x).ToList();
                //foreach (ReportItemSummary r in itemList)
                //{
                //    Boolean already = false;
                //    foreach (ReportItemSummary s in IList)
                //    {
                //        if (r.Id == s.Id && r.UnitPrice == s.UnitPrice  && r.IsFOC == s.IsFOC)
                //        {
                //            s.Qty += r.Qty;
                //            s.totalAmount += r.totalAmount;
                //            already = true;
                //        }                        
                //    }
                //    if (!already)
                //    {
                //        IList.Add(r);
                //    }
                //}
            //}
            //else
            //{
            //    //itemList = (List<ReportItemSummary>)itemList.GroupBy(x => x.Id);
            //    foreach (ReportItemSummary r in FinalResultList)
            //    {
            //        ReportItemSummary p = new ReportItemSummary();
            //        p.Id = r.Id;
            //        p.Name = r.Name;
            //        p.Qty = (int)r.Qty;
            //        p.UnitPrice = Convert.ToInt32(r.UnitPrice);
            //        p.totalAmount = Convert.ToInt64(r.totalAmount);
            //        p.PaymentId = (int)r.PaymentId;
            //        CashTotal += Convert.ToInt64(r.totalAmount);
            //        p.IsFOC = Convert.ToBoolean(r.IsFOC);
            //        p.SellingPrice = Convert.ToInt32(r.SellingPrice); 
            //        p.Remark = "";
            //        itemList.Add(p);
            //    }

            //    //Grop By Item
            //    foreach (ReportItemSummary r in itemList)
            //    {
            //        Boolean already = false;
            //        foreach (ReportItemSummary s in IList)
            //        {
            //            if (r.Id == s.Id && r.UnitPrice == s.UnitPrice)
            //            {
            //                s.Qty += r.Qty;
            //                s.totalAmount += r.totalAmount;
            //                already = true;
            //            }
            //        }
            //        if (!already)
            //        {
            //            IList.Add(r);
            //        }
            //    }
            //}
            
            //if (IsSale)
            //{
            //    gbList.Text = "Daily Sales Report";

            //}
            //else
            //{
            //    gbList.Text = "Daily Refunds Report";

            //}

                gbList.Text = "Daily Sales Report";
            ShowReportViewer();
        }

        private void ShowReportViewer()
        {

            dsReportTemp dsReport = new dsReportTemp();
            //dsReportTemp.ItemListDataTable dtItemReport = (dsReportTemp.ItemListDataTable)dsReport.Tables["LO'c_ItemSummary"];
            dsReportTemp._LO_c_ItemSummaryDataTable dtItemReport = (dsReportTemp._LO_c_ItemSummaryDataTable)dsReport.Tables["LO'c_ItemSummary"];


            FinalResultList = FinalResultList.OrderBy(x => x.Name).ToList();
            foreach (ReportItemSummary p in FinalResultList)
            {
                //dsReportTemp.ItemListRow newRow = dtItemReport.NewItemListRow();
                dsReportTemp._LO_c_ItemSummaryRow newRow = dtItemReport.New_LO_c_ItemSummaryRow();
                newRow.ItemCode = p.Id;
                newRow.Name = p.Name;
                newRow.Size = p.Size;
                newRow.Qty = p.Qty.ToString();
                newRow.UnitPrice = p.UnitPrice.ToString();                
                newRow.TotalAmount = Convert.ToInt64(p.totalAmount);
                newRow.SellingPrice = Convert.ToInt64(p.SellingPrice);
                newRow.Remark = p.Remark.ToString();
                dtItemReport.Add_LO_c_ItemSummaryRow(newRow);
            }
            Total = CashTotal + CreditTotal + FOCAmount + MPUAmount + GiftCardAmount + TesterAmount;

            //if (rdbSale.Checked)
            //{
                totalSettlement = DtransList.Sum(x => x.TotalAmount).Value;
            //}
            //else
            //{
            //    totalSettlement = 0;
            //}
            //CashTotal += GiftCardAmount;
            //To Find DiscountAmountOfAllTransactions
            decimal OverAllDis = 0;
            decimal OverAllMCDis = 0;
            decimal CreditMCDis = 0;
            
            foreach (Transaction t in AllTranslist)
            {
                List<TransactionDetail> tdList = new List<TransactionDetail>();
                tdList = t.TransactionDetails.ToList();
                decimal itemDis = 0;
                foreach (TransactionDetail td in tdList)
                {
                    itemDis += Convert.ToDecimal((td.UnitPrice * (td.DiscountRate / 100))*td.Qty);
                }
                OverAllDis += Convert.ToDecimal(t.DiscountAmount-itemDis);

                var creditData= (from a in AllTranslist where a.Type == "Credit" select a).ToList();
                Int64 _totalMCDisocunt = Convert.ToInt64(creditData.Sum(x => x.MCDiscountAmt));
                Int64 _totalBDDiscount = Convert.ToInt64(creditData.Sum(x => x.BDDiscountAmt));

                CreditMCDis = _totalMCDisocunt + _totalBDDiscount;
              

                if ((int)(t.MCDiscountAmt==null? 0 : t.MCDiscountAmt ) != 0)
                {
                    OverAllMCDis += Convert.ToDecimal(t.MCDiscountAmt);
                }
                else if ((int)(t.BDDiscountAmt == null ? 0 : t.BDDiscountAmt) != 0)
                {
                    OverAllMCDis += Convert.ToDecimal(t.BDDiscountAmt);
                }
            }
           // decimal actualAmount = (Convert.ToDecimal(CashTotal + CreditReceive) - (OverAllDis) - (OverAllMCDis)) + totalSettlement;
            decimal actualAmount = (Convert.ToDecimal(CashTotal + CreditReceive + CashAmtFromGiftCard) + (totalSettlement + CreditMCDis) - (OverAllDis) - (OverAllMCDis));

            ReportDataSource rds = new ReportDataSource("ItemSummary", dsReport.Tables["LO'c_ItemSummary"]);
            string reportPath = Application.StartupPath + "\\Reports\\LO'C_Daily_Summary.rdlc";
            reportViewer1.LocalReport.ReportPath = reportPath;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter ItemReportTitle = new ReportParameter("ItemReportTitle", gbList.Text + " for " + SettingController.ShopName);
            reportViewer1.LocalReport.SetParameters(ItemReportTitle);

            ReportParameter Date = new ReportParameter("Date", " from " + dtFrom.Value.Date.ToString("dd/MM/yyyy") + " To " + dtTo.Value.Date.ToString("dd/MM/yyyy"));
            reportViewer1.LocalReport.SetParameters(Date);

            ReportParameter TotalAmount = new ReportParameter("TotalAmount", (Total - FOCAmount).ToString());
            reportViewer1.LocalReport.SetParameters(TotalAmount);

            ReportParameter CreditAmount = new ReportParameter("CreditAmount", (CreditTotal- CreditReceive).ToString());
            reportViewer1.LocalReport.SetParameters(CreditAmount);

            ReportParameter CashAmount = new ReportParameter("CashAmount", (CashTotal + CreditReceive + CashAmtFromGiftCard).ToString());
            reportViewer1.LocalReport.SetParameters(CashAmount);

            ReportParameter DisAmount = new ReportParameter("DisAmount", OverAllDis.ToString());
            reportViewer1.LocalReport.SetParameters(DisAmount);


            ReportParameter MemberCardDiscount = new ReportParameter("MemberCardDiscount", OverAllMCDis.ToString());
            reportViewer1.LocalReport.SetParameters(MemberCardDiscount);

            ReportParameter UsedGiftAmount = new ReportParameter("UsedGiftAmount", UseGiftAmount.ToString());
            reportViewer1.LocalReport.SetParameters(UsedGiftAmount);

            ReportParameter FOC = new ReportParameter("FOC", FOCAmount.ToString());
            reportViewer1.LocalReport.SetParameters(FOC);

            ReportParameter MPU = new ReportParameter("MPU", MPUAmount.ToString());
            reportViewer1.LocalReport.SetParameters(MPU);

            ReportParameter Tester = new ReportParameter("Tester", TesterAmount.ToString());
            reportViewer1.LocalReport.SetParameters(Tester);

            ReportParameter TotalSettlement = new ReportParameter("TotalSettlement", totalSettlement.ToString());
            reportViewer1.LocalReport.SetParameters(TotalSettlement);

       

            ReportParameter ActualAmount = new ReportParameter("ActualAmount", actualAmount.ToString());
            reportViewer1.LocalReport.SetParameters(ActualAmount);

            ReportParameter TotalRefund = new ReportParameter("TotalRefund", RefundAmt.ToString());
            reportViewer1.LocalReport.SetParameters(TotalRefund);


            ReportParameter CashInHand = new ReportParameter("CashInHand", (actualAmount - RefundAmt).ToString());
            reportViewer1.LocalReport.SetParameters(CashInHand);
            reportViewer1.RefreshReport();
        }
        #endregion

    }
}
