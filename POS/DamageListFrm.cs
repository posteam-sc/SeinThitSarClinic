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
    public partial class DamageListFrm : Form
    {
        public DamageListFrm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        #region Variable

        POSEntities entity = new POSEntities();
        ToolTip tp = new ToolTip();

        List<Damage> _dmglist = new List<Damage>();

        int Qty = 0;

        List<Stock_Transaction> productList = new List<Stock_Transaction>();
        #endregion

        #region Function


        #region for saving Damage Qty in Stock Transaction table
        private void Save_DamageQty_ToStockTransaction(List<Stock_Transaction> productList, DateTime _tranDate)
        {
            int _year, _month;

            _year = _tranDate.Year;
            _month = _tranDate.Month;
            Utility.Adjustment_Run_Process(_year, _month, productList);
        }
        #endregion

        private void Bind_Brand()
        {
            List<APP_Data.Brand> BrandList = new List<APP_Data.Brand>();
            APP_Data.Brand brandObj1 = new APP_Data.Brand();
            brandObj1.Id = 0;
            brandObj1.Name = "Select";
            //APP_Data.Brand brandObj2 = new APP_Data.Brand();
            //brandObj2.Id = 1;
            //brandObj2.Name = "None";
            BrandList.Add(brandObj1);
            //BrandList.Add(brandObj2);
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
            dgvDamagelist.Columns["DamageDateTime"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            int _braindId = 0;
            if (cboBrand.SelectedIndex > 0)
            {
                _braindId = Convert.ToInt32(cboBrand.SelectedValue);
            }

          Char _status = Radio_Status();

            dgvDamagelist.DataSource = null;
            DateTime fromDate = dtpk_fromDate.Value.Date;
            DateTime toDate = dtpk_toDate.Value.Date;

            entity = new POSEntities();

            IQueryable<object> q = from d in entity.Damages
                                   join p in entity.Products on d.ProductId equals p.Id
                                   where d.IsDeleted == false
                                   && (EntityFunctions.TruncateTime((DateTime)d.DamageDateTime) >= fromDate
                                   && EntityFunctions.TruncateTime((DateTime)d.DamageDateTime) <= toDate)
                                   &&   ((_status=='A'  && 1==1) || (_status=='C' && p.IsConsignment==true) ||(_status=='N' && p.IsConsignment==false))
                                   && ((_braindId == 0 && 1 == 1) || (_braindId != 0 && p.BrandId == _braindId))
                                   select new
                                   {
                                       Id = d.Id,
                                       ProductId = d.ProductId,
                                       ProductCode = p.ProductCode,
                                       Name = p.Name,
                                       Price = p.Price,
                                       DamageQty = d.DamageQty,
                                       TotalCost = d.DamageQty * p.Price,
                                       DamageDateTime = d.DamageDateTime,
                                       ResponsibleName = d.ResponsibleName,
                                       Reason = d.Reason
                                   };
            List<object> _damage = new List<object>(q);
            dgvDamagelist.AutoGenerateColumns = false;
            dgvDamagelist.DataSource = _damage;
        }
        #endregion

        #region Events
        private void rdConsignment_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void DamageListFrm_Load(object sender, EventArgs e)
        {
            dtpk_fromDate.Value = DateTime.Now.Date;
            dtpk_toDate.Value = DateTime.Now.Date;
            Bind_Brand();
            loadData();
        }

        private void dgvDamagelist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Role Management
                RoleManagementController controller = new RoleManagementController();
                controller.Load(MemberShip.UserRoleId);
                int dmgID = Convert.ToInt32(dgvDamagelist.CurrentRow.Cells["Id"].Value);

                if (e.ColumnIndex == 10)
                {
                    if (controller.Damage.EditOrDelete || MemberShip.isAdmin)
                    {
                        DialogResult result1 = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result1.Equals(DialogResult.OK))
                        {

                            int _productid = Convert.ToInt32(dgvDamagelist.Rows[e.RowIndex].Cells[1].Value);
                            int DamageQty1 = Convert.ToInt32(dgvDamagelist.Rows[e.RowIndex].Cells[5].Value);
                            //increate qty inproduct  after approve
                            APP_Data.Product pdObj = entity.Products.Where(x => x.Id == _productid).FirstOrDefault();
                            if (pdObj != null)
                            {
                                pdObj.Qty = pdObj.Qty + DamageQty1;
                                //entity.Entry(pdObj).State = EntityState.Modified;
                                entity.SaveChanges();

                                //save in stocktransaction
                              
                                Stock_Transaction st = new Stock_Transaction();
                                st.ProductId = pdObj.Id;
                                Qty -= DamageQty1;
                                if (Qty > 0)
                                {
                                    st.AdjustmentStockIn = Qty;
                                }
                                else
                                {
                                    st.AdjustmentStockOut = Qty;
                                }
                                
                                productList.Add(st);
                                Qty = 0;

                                Save_DamageQty_ToStockTransaction(productList,Convert.ToDateTime(dgvDamagelist.Rows[e.RowIndex].Cells[7].Value));
                                productList.Clear();
                            }

                            int _damageId = Convert.ToInt32(dgvDamagelist.Rows[e.RowIndex].Cells[0].Value);
                            APP_Data.Damage _damage = entity.Damages.Where(x => x.Id == _damageId).FirstOrDefault();
                            _damage.IsDeleted = true;
                            _damage.DeletedDate = DateTime.Now;
                            _damage.DeletedUserId = MemberShip.UserId;
                            entity.Entry(_damage).State = EntityState.Modified;
                            entity.SaveChanges();

                            loadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete damage permission.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


    }
}
