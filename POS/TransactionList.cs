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
using POS.APP_Data;

namespace POS
{
    public partial class TransactionList : Form
    {
        #region Variables

        private POSEntities entity = new POSEntities();
        int Qty = 0;

        List<Stock_Transaction> productList = new List<Stock_Transaction>();

        public int index = 0;
        #endregion

        #region Event

        public TransactionList()
        {
            InitializeComponent();
        }

        private void TransactionList_Load(object sender, EventArgs e)
        {
            dgvTransactionList.AutoGenerateColumns = false;
            LoadData();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rdbDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDate.Checked)
            {
                gbDate.Enabled = true;
                gbId.Enabled = false;
                txtId.Clear();
            }
            else
            {
                gbDate.Enabled = false;
                gbId.Enabled = true;
            }
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
            
        }

        private void dgvTransactionList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                string currentTransactionId = dgvTransactionList.Rows[e.RowIndex].Cells[0].Value.ToString();

                List<int> type =new List<int> { 3, 4, 5, 6 };
                List<APP_Data.TransactionDetail> _isConsignmentPaidTranList = entity.TransactionDetails.Where(x => x.TransactionId == currentTransactionId && x.IsDeleted == false && x.IsConsignmentPaid == true).ToList();
                //Refund
                if (e.ColumnIndex == 8)
                {
                    Transaction tObj = (Transaction)dgvTransactionList.Rows[e.RowIndex].DataBoundItem;
                    if (type.Contains(Convert.ToInt32(tObj.PaymentTypeId)))
                    {
                        MessageBox.Show("Non Refundable!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (tObj.Type != "Settlement")
                        {
                            if (_isConsignmentPaidTranList.Count > 0)
                            {
                                MessageBox.Show("This transaction already  made  Consignment Settlement. It cannot be deleted!");
                            }
                            else
                            {
                                RefundTransaction newForm = new RefundTransaction();
                                newForm.transactionId = currentTransactionId;
                                newForm.IsCash = true;
                                newForm.ShowDialog();
                            }
                   
                        }
                        else
                        {
                            colRefund.ReadOnly = true;


                        }
                    }
                }
       
                //View Detail
                else if (e.ColumnIndex == 9)
                {
                    var tranType = (from t in entity.Transactions where t.Id == currentTransactionId select t.Type).FirstOrDefault();
                    if (tranType == "Settlement")
                    {
                        colViewDetail.ReadOnly = true;
                    }
                    else
                    {
                        TransactionDetailForm newForm = new TransactionDetailForm();
                        newForm.transactionId = currentTransactionId;
                        newForm.ShowDialog();
                    }
                }
                //Delete the record and add delete log
                else if (e.ColumnIndex == 10)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Transaction.EditOrDelete || MemberShip.isAdmin)
                    {
                        #region Delete
                        Transaction ts = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();

                        if (ts.Type == "Settlement")
                        {
                            colDelete.ReadOnly = true;
                        }
                        else
                        {
                            APP_Data.Transaction ts2 = entity.Transactions.Where(x => x.ParentId == currentTransactionId && x.IsDeleted == false).FirstOrDefault();
                       
                            if (ts2 != null)
                            {
                                MessageBox.Show("This transaction already made  refund. It cannot be deleted!");

                            }
                            else if (_isConsignmentPaidTranList.Count > 0)
                            {
                                MessageBox.Show("This transaction already made  Consignment Settlement. It cannot be deleted!");
                            }
                            else
                            {

                                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (result.Equals(DialogResult.OK))
                                {

                                    ts.IsDeleted = true;
                                    // add gift card amount
                                    if (ts.GiftCardId != null && ts.GiftCard != null)
                                    {
                                        ts.GiftCard.Amount = ts.GiftCard.Amount + Convert.ToInt32(ts.GiftCardAmount);
                                    }
                                    foreach (TransactionDetail detail in ts.TransactionDetails)
                                    {
                                        //detail.IsDeleted = false;
                                        detail.IsDeleted = true;
                                        detail.Product.Qty = detail.Product.Qty + detail.Qty;


                                        //save in stocktransaction

                                        Stock_Transaction st = new Stock_Transaction();
                                        st.ProductId = detail.Product.Id;
                                        Qty -= Convert.ToInt32(detail.Qty);
                                        st.Sale = Qty;
                                        productList.Add(st);
                                        Qty = 0;

                                        if (detail.Product.IsWrapper == true)
                                        {
                                            List<WrapperItem> wList = detail.Product.WrapperItems.ToList();
                                            if (wList.Count > 0)
                                            {
                                                foreach (WrapperItem w in wList)
                                                {
                                                    Product wpObj = (from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault();
                                                    wpObj.Qty = wpObj.Qty + detail.Qty;
                                                }
                                            }
                                        }

                                        //For Purchase 
                                        #region Purchase Delete

                                        List<APP_Data.PurchaseDetailInTransaction> puInTranDetail = entity.PurchaseDetailInTransactions.Where(x => x.TransactionDetailId == detail.Id && x.ProductId == detail.ProductId).ToList();
                                        if (puInTranDetail.Count > 0)
                                        {
                                            foreach (PurchaseDetailInTransaction p in puInTranDetail)
                                            {
                                                PurchaseDetail pud = entity.PurchaseDetails.Where(x => x.Id == p.PurchaseDetailId).FirstOrDefault();
                                                if (pud != null)
                                                {
                                                    pud.CurrentQy = pud.CurrentQy + p.Qty;
                                                }
                                                entity.Entry(pud).State = EntityState.Modified;
                                                entity.SaveChanges();

                                                //entity.PurchaseDetailInTransactions.Remove(p);
                                                //entity.SaveChanges();

                                                p.Qty = 0;
                                                entity.Entry(p).State = EntityState.Modified;

                                                entity.PurchaseDetailInTransactions.Remove(p);
                                                entity.SaveChanges();
                                            }
                                        }
                                        #endregion
                                    }

                                    string date = dgvTransactionList.Rows[e.RowIndex].Cells[3].Value.ToString();
                                    DateTime _Trandate = Utility.Convert_Date(date);
                                    //save in stock transaction
                                    Save_SaleQty_ToStockTransaction(productList, _Trandate);
                                    productList.Clear();
                                    DeleteLog dl = new DeleteLog();
                                    dl.DeletedDate = DateTime.Now;
                                    dl.CounterId = MemberShip.CounterId;
                                    dl.UserId = MemberShip.UserId;
                                    dl.IsParent = true;
                                    dl.TransactionId = ts.Id;

                                    entity.DeleteLogs.Add(dl);

                                    entity.SaveChanges();

                                    LoadData();
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete transaction information", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.ColumnIndex == 11)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Transaction.DeleteAndCopy || MemberShip.isAdmin)
                    {
                        #region Delete And Copy
                        Transaction ts = entity.Transactions.Where(x => x.Id == currentTransactionId).FirstOrDefault();
                  
                        if (ts.Type == "Settlement")
                        {

                            colDeleteAndCopy.ReadOnly = true;

                        }
                        else
                        {
                            List<Transaction> rlist = new List<Transaction>();

                            if (ts.Transaction1.Count > 0)
                            {
                                rlist = ts.Transaction1.Where(x => x.IsDeleted == false).ToList();
                            }
                            if (rlist.Count > 0)
                            {
                                MessageBox.Show("This transaction already make refund. So it can't be delete!");
                            }
                            else if (_isConsignmentPaidTranList.Count > 0)
                            {
                                MessageBox.Show("This transaction already made  Consignment Settlement. It cannot be deleted!");
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (result.Equals(DialogResult.OK))
                                {
                                    if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                                    {
                                        Sales openedForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                                        openedForm.DeleteCopy(currentTransactionId);
                                        this.Dispose();
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete transaction information", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void dgvTransactionList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransactionList.Rows)
            {
                Transaction currentt = (Transaction)row.DataBoundItem;
                row.Cells[0].Value = currentt.Id;
                row.Cells[1].Value = currentt.Type;
                row.Cells[2].Value = currentt.PaymentType.Name;
                row.Cells[3].Value = currentt.DateTime.Value.ToString("dd-MM-yyyy");
                row.Cells[4].Value = currentt.DateTime.Value.ToString("hh:mm");
                row.Cells[5].Value = currentt.User.Name;



                var refundList = (from t in entity.Transactions where t.Type == TransactionType.Refund && t.ParentId == currentt.Id && t.IsDeleted == false select t).ToList();
                int refundAmt = Convert.ToInt32(refundList.Sum(x => x.TotalAmount));
                var DiscountAmt = Convert.ToInt32(refundList.Sum(x => x.DiscountAmount));
                int currentRefundAmt = refundAmt - DiscountAmt;
                if (currentt.PaymentType.Name != "FOC")
                {
                    row.Cells[6].Value = currentt.TotalAmount - currentRefundAmt;
                }
                else
                {
                    row.Cells[6].Value = 0;
                }
                
                row.Cells[7].Value = currentRefundAmt;
            }
        }

        #endregion

        #region Function
        #region for saving Sale Qty in Stock Transaction table
        private void Save_SaleQty_ToStockTransaction(List<Stock_Transaction> productList, DateTime _tranDate)
        {
            int _year, _month;

            _year = _tranDate.Year;
            _month = _tranDate.Month;
            Utility.Sale_Run_Process(_year, _month, productList);
        }
        #endregion

        public void LoadData()
        {
            entity = new POSEntities();
            dgvTransactionList_CustomCellFormatting();

            List<string> type = new List<string>();
            type.Add(TransactionType.Sale);

            if (rdbDate.Checked)
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;
              
                // type.Add(TransactionType.Settlement);
                // type.Add(TransactionType.Prepaid);


                //List<Transaction> transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && t.Type == TransactionType.Sale && t.IsDeleted==false select t).ToList<Transaction>();
                List<Transaction> transList = (from t in entity.Transactions where EntityFunctions.TruncateTime((DateTime)t.DateTime) >= fromDate && EntityFunctions.TruncateTime((DateTime)t.DateTime) <= toDate && t.IsComplete == true && t.IsActive == true && type.Contains(t.Type) && (t.IsDeleted == false || t.IsDeleted == null) select t).ToList<Transaction>();
                dgvTransactionList.DataSource = transList.Where(x => x.IsDeleted != true).ToList();
            }
            else
            {
                string Id = txtId.Text;
                if (Id.Trim() != string.Empty)
                {
                    List<Transaction> transList = (from t in entity.Transactions where t.Id == Id && type.Contains(t.Type) select t).ToList().Where(x => x.IsDeleted != true).ToList();
                    if (transList.Count > 0)
                    {
                        dgvTransactionList.DataSource = transList;
                    }
                    else
                    {
                        dgvTransactionList.DataSource = "";
                        MessageBox.Show("Item not found!", "Cannot find");
                    }
                }
                else
                {
                    dgvTransactionList.DataSource = "";
                }
            }
        }

        #endregion


        private void dgvTransactionList_CustomCellFormatting()
        {
            //Role Management
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            // Transaction Delete
            if (!MemberShip.isAdmin && !controller.Transaction.EditOrDelete)
            {
                dgvTransactionList.Columns["colDelete"].Visible = false;
            }
            // Transaction Delete And Copy
            if (!MemberShip.isAdmin && !controller.Transaction.DeleteAndCopy)
            {
                dgvTransactionList.Columns["colDeleteAndCopy"].Visible = false;
            }
        }
    }
}

