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
    public partial class DamageFrm : Form
    {
        public DamageFrm()
        {
            InitializeComponent();
            CenterToScreen();
        }

        #region Variable
        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        public int ProductID = 0;
        int Qty = 0;

        List<Stock_Transaction> productList = new List<Stock_Transaction>();

        #endregion

        #region Event
        private void DamageFrm_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(cboProduct);
            tp.Hide(txtDamageQty);
            tp.Hide(txtResponsiblePerson);
        }

        private void DamageFrm_Load(object sender, EventArgs e)
        {
            Bind_Product();
            dtpDamageDate.Value = System.DateTime.Now;
        }

        private void cboProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            Product_Value_Changed();
        }

        private void cboProduct_Leave(object sender, EventArgs e)
        {
            Product_Value_Changed();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnDamage_Click(object sender, EventArgs e)
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            Boolean HaveError = false;
            int dmgQty = 0;

            if (Utility.Product_Combo_Control(cboProduct))
            {
                return ;
            }

            if (cboProduct.SelectedIndex == 0)
            {
                tp.SetToolTip(cboProduct, "Error");
                tp.Show("Please choose Product Name", cboProduct);
                HaveError = true;

            }
            else if (txtDamageQty.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtDamageQty, "Error");
                tp.Show("Please fill Damage Qty", txtDamageQty);
                HaveError = true;

            }
            else if (txtDamageQty.Text != string.Empty)
            {
                int curQty = Convert.ToInt32(txtDamageQty.Text);
                if (curQty < 1)
                {
                    tp.SetToolTip(txtDamageQty, "Error");
                    tp.Show("Please fill Damage Quantity more than zero", txtDamageQty);
                    HaveError = true;
                }
                else if (txtResponsiblePerson.Text.Trim() == string.Empty)
                {
                    tp.SetToolTip(txtResponsiblePerson, "Error");
                    tp.Show("Please fill Responsible Person Name", txtResponsiblePerson);
                    HaveError = true;
                }
            }



            if (!HaveError)
            {
                dmgQty = Convert.ToInt32(txtDamageQty.Text);

                APP_Data.Damage dmgObj = new Damage();

                dmgObj.ResponsibleName = txtResponsiblePerson.Text;
                dmgObj.Reason = txtReason.Text;
                dmgObj.UserId = MemberShip.UserId;
                dmgObj.DamageDateTime = dtpDamageDate.Value;
                dmgObj.ProductId = Convert.ToInt32(cboProduct.SelectedValue);

                int dmgQty1 = Convert.ToInt32(txtDamageQty.Text);
                int DamageQty1 = 0;

                Int32.TryParse(txtDamageQty.Text, out DamageQty1);
                dmgObj.DamageQty = DamageQty1;
                dmgObj.IsDeleted = false;

                ProductID = Convert.ToInt32(cboProduct.SelectedValue);
                entity.Damages.Add(dmgObj);
                entity.SaveChanges();

                // increase qty inproduct  after save
                APP_Data.Product pdObj = entity.Products.Where(x => x.Id == ProductID).FirstOrDefault();
                if (pdObj != null)
                {
                    pdObj.Qty = pdObj.Qty - DamageQty1;
                    entity.Entry(pdObj).State = EntityState.Modified;
                    entity.SaveChanges();


                    //save in stocktransaction
                  
                    Stock_Transaction st = new Stock_Transaction();
                    st.ProductId = pdObj.Id;
                    Qty = DamageQty1;

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

                    Save_DamageQty_ToStockTransaction(productList,Convert.ToDateTime(dtpDamageDate.Value));
                    productList.Clear();
                }

                MessageBox.Show("Successfully Saved!", "Save");
                CancelDamage();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelDamage();
        }


        #endregion

        #region Method

        #region for saving Damage Qty in Stock Transaction table
        private void Save_DamageQty_ToStockTransaction(List<Stock_Transaction> productList, DateTime _tranDate)
        {
            int _year, _month;

            _year = _tranDate.Year;
            _month = _tranDate.Month;
            Utility.Adjustment_Run_Process(_year, _month, productList);
        }
        #endregion

        private void Bind_Product()
        {
            List<Product> productList = new List<Product>();
            Product productObj1 = new Product();
            productObj1.Id = 0;
            productObj1.Name = "Select";
            productList.Add(productObj1);

            var _productList = (from p in entity.Products select p).ToList();
            productList.AddRange(_productList);
            cboProduct.DataSource = productList;
            cboProduct.DisplayMember = "Name";
            cboProduct.ValueMember = "Id";
            cboProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void Product_Value_Changed()
        {
            if (cboProduct.SelectedIndex > 0)
            {
                int productId = Convert.ToInt32(cboProduct.SelectedValue.ToString());

                APP_Data.Product pdObj = (from pd in entity.Products where pd.Id == productId select pd).FirstOrDefault();
                if (pdObj != null)
                {
                    txtUnitPrice.Text = pdObj.Price.ToString();
                    ProductID = Convert.ToInt32(cboProduct.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Your product SKU has no in this warehouse", "Product SKU");
                    return;
                }
            }
            else
            {
                txtUnitPrice.Text = "0";
            }
        }

        private void CancelDamage()
        {
            cboProduct.SelectedIndex = 0;
            txtUnitPrice.Text = "0";
            txtDamageQty.Clear();
            dtpDamageDate.Value = DateTime.Now.Date;
            ProductID = 0;
            txtResponsiblePerson.Clear();
            txtReason.Clear();
        }
        #endregion

    }
}
