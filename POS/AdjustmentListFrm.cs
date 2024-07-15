//New


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;
using System.Data.Objects;

namespace POS
{
    public partial class AdjustmentListFrm : Form
    {
        public AdjustmentListFrm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        #region Variable

        POSEntities entity = new POSEntities();
        ToolTip tp = new ToolTip();
        Boolean Approve = false;
        List<Adjustment> _dmglist = new List<Adjustment>();

        int Qty = 0;

        List<Stock_Transaction> productList = new List<Stock_Transaction>();

        bool IsStart = false;
        #endregion

        #region Function


        #region for saving Adjustment Qty in Stock Transaction table
        private void Save_AdjustmentQty_ToStockTransaction(List<Stock_Transaction> productList, DateTime _tranDate)
        {
            int _year, _month;

            _year = _tranDate.Year;
            _month = _tranDate.Month;
            Utility.Adjustment_Run_Process(_year, _month, productList,true);
        }
        #endregion

        private void Bind_Brand()
        {
            List<APP_Data.Brand> BrandList = new List<APP_Data.Brand>();
            entity = new POSEntities();
            APP_Data.Brand brandObj1 = new APP_Data.Brand();
            brandObj1.Id = 0;
            brandObj1.Name = "Select";
       
            BrandList.Add(brandObj1);
       
            BrandList.AddRange((from bList in entity.Brands select bList).ToList());
            cboBrand.DataSource = BrandList;
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";
            cboBrand.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBrand.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void BindDgv()
        {
            loadData();
        }

        private DateTime TruncateTime(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        private Char Radio_Status()
        {
            Char _St = '\0';
            if(rdoAll.Checked)
            {
                _St='A';
            }
            else if (rdConsignment.Checked)
            {
                _St='C';
            }
            else
            {
                _St = 'N';
            }
            return _St;
        }

        public void loadData()
        {
            if (IsStart)
            {

                if (Approve == true)
                {
                    dgvAdjustmentList.Columns[12].Visible = false;
                    dgvAdjustmentList.Columns[13].Visible = false;
               
                }
                else
                {
                    dgvAdjustmentList.Columns[12].Visible = true;
                    dgvAdjustmentList.Columns[13].Visible = true;
                   
                }

                dgvAdjustmentList.Columns["AdjustmentDateTime"].DefaultCellStyle.Format = "dd-MMM-yyyy";
                int _braindId = 0;
                if (cboBrand.SelectedIndex > 0)
                {
                    _braindId = Convert.ToInt32(cboBrand.SelectedValue);
                }

                Char _status = Radio_Status();

                dgvAdjustmentList.DataSource = null;
                DateTime fromDate = dtpk_fromDate.Value.Date;
                DateTime toDate = dtpk_toDate.Value.Date;
                int typeId = Convert.ToInt32(cboAdjType.SelectedValue);
                entity = new POSEntities();

                IQueryable<object> q = from d in entity.Adjustments
                                       join p in entity.Products on d.ProductId equals p.Id
                                       join adj in entity.AdjustmentTypes on d.AdjustmentTypeId equals adj.Id
                                       where d.IsDeleted == false && d.IsApproved==Approve
                                       && (EntityFunctions.TruncateTime((DateTime)d.AdjustmentDateTime) >= fromDate
                                       && EntityFunctions.TruncateTime((DateTime)d.AdjustmentDateTime) <= toDate)
                                       && ((_status == 'A' && 1 == 1) || (_status == 'C' && p.IsConsignment == true) || (_status == 'N' && p.IsConsignment == false))
                                       && ((_braindId == 0 && 1 == 1) || (_braindId != 0 && p.BrandId == _braindId)) && ((typeId == 0 && 1== 1) || (typeId != 0 && d.AdjustmentTypeId == typeId))
                                       select new
                                       {
                                           Id = d.Id,
                                           ProductId = d.ProductId,
                                           ProductCode = p.ProductCode,
                                           Name = p.Name,
                                           Price = p.Price,
                                           StockOut = d.AdjustmentQty < 0 ? d.AdjustmentQty * -1 : 0,
                                           StockIn = d.AdjustmentQty > 0 ? d.AdjustmentQty : 0,
                                           TotalCost = d.AdjustmentQty < 0 ? (d.AdjustmentQty * -1) * p.Price : d.AdjustmentQty * p.Price,
                                           AdjustmentDateTime = d.AdjustmentDateTime,
                                           Type=adj.Name,
                                           ResponsibleName = d.ResponsibleName,
                                           Reason = d.Reason
                                       };
                List<object> _adjustment = new List<object>(q);
                dgvAdjustmentList.AutoGenerateColumns = false;
                dgvAdjustmentList.DataSource = _adjustment;
                lblStockIn.Text = (dgvAdjustmentList.Rows.Cast<DataGridViewRow>()
                                                                           .Sum(t => Convert.ToInt32(t.Cells[5].Value))).ToString();

                lblStockOut.Text = (dgvAdjustmentList.Rows.Cast<DataGridViewRow>()
                                                               .Sum(t => Convert.ToInt32(t.Cells[6].Value))).ToString();
            }
        }
        #endregion

        #region Events
        private void rdConsignment_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void cboAdjType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void AdjustmentListFrm_Load(object sender, EventArgs e)
        {
            dtpk_fromDate.Value = DateTime.Now.Date;
            dtpk_toDate.Value = DateTime.Now.Date;
            Bind_Brand();
            Utility.Bind_AdjustmentType(cboAdjType);
            IsStart = true;
            loadData();
        }

        private void dgvAdjustmentlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Role Management
                RoleManagementController controller = new RoleManagementController();
                controller.Load(MemberShip.UserRoleId);
                int dmgID = Convert.ToInt32(dgvAdjustmentList.CurrentRow.Cells["Id"].Value);

                //Delete
                if (e.ColumnIndex == 13)
                {
                    if (controller.Adjustment.EditOrDelete || MemberShip.isAdmin)
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.OK))
                        {
                            int _adjustmentId = Convert.ToInt32(dgvAdjustmentList.Rows[e.RowIndex].Cells[0].Value);
                            APP_Data.Adjustment _adjustment = entity.Adjustments.Where(x => x.Id == _adjustmentId).FirstOrDefault();
                            _adjustment.IsDeleted = true;
                            _adjustment.DeletedDate = DateTime.Now;
                            _adjustment.DeletedUserId = MemberShip.UserId;
                            entity.Entry(_adjustment).State = EntityState.Modified;
                            entity.SaveChanges();

                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete damage permission.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (e.ColumnIndex == 12)
                {
                   
                   
                    if (MemberShip.isAdmin)
                    {
                        DialogResult result1 = MessageBox.Show("Please note that you cannot edit  adjustment quantity  anymore after you clicked Approved. ", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.OK))
                        {
                            int _productid = Convert.ToInt32(dgvAdjustmentList.Rows[e.RowIndex].Cells[1].Value);
                            int _adjustmentId = Convert.ToInt32(dgvAdjustmentList.Rows[e.RowIndex].Cells[0].Value);
                            APP_Data.Adjustment _adjustment = entity.Adjustments.Where(x => x.Id == _adjustmentId).FirstOrDefault();
                            _adjustment.IsApproved = true;
                            entity.Entry(_adjustment).State = EntityState.Modified;
                            entity.SaveChanges();


                            APP_Data.Product pdObj = entity.Products.Where(x => x.Id == _productid).FirstOrDefault();
                            if (pdObj != null)
                            {
                                pdObj.Qty = pdObj.Qty + _adjustment.AdjustmentQty;
                                entity.Entry(pdObj).State = EntityState.Modified;
                                entity.SaveChanges();
                            }

                            Stock_Transaction st = new Stock_Transaction();
                            st.ProductId = pdObj.Id;

                            st.AdjustmentQty = Convert.ToInt32(_adjustment.AdjustmentQty);

                            productList.Add(st);
                            Qty = 0;

                            Save_AdjustmentQty_ToStockTransaction(productList, Convert.ToDateTime(_adjustment.AdjustmentDateTime));
                            productList.Clear();
                        }
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to approve adjustment .", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
    }

        private void dtpk_fromDate_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dtpk_toDate_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
        #endregion

        private void rdoPending_CheckedChanged(object sender, EventArgs e)
        {
            
            loadData();
            if (rdoPending.Checked == true)
            {
                Approve = false;
            }
            else
            {
                Approve = true;
            }
        }

        private void rdoApprovedChanged(object sender, EventArgs e)
        {
          
            loadData();
            if (rdoPending.Checked == true)
            {
                Approve = false;
            }
            else
            {
                Approve = true;
            }
        }

    
    }

}