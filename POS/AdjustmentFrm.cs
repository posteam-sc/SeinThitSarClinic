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
    public partial class AdjustmentFrm : Form
    {
        public AdjustmentFrm()
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
        private void AdjustmentFrm_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(cboProduct);
            tp.Hide(txtAdjustmentQty);
            tp.Hide(txtResponsiblePerson);
        }

        private void AdjustmentFrm_Load(object sender, EventArgs e)
        {
            Bind_Product();
            Utility.Bind_AdjustmentType(cboAdjType);
            dtpAdjustmentDate.Value = System.DateTime.Now;
            cboSign.SelectedIndex = 0;
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

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            Boolean HaveError = false;
            int adjustQty = 0;

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
            else if (cboAdjType.SelectedIndex == 0)
            {
                tp.SetToolTip(cboAdjType, "Error");
                tp.Show("Please fill Type", cboAdjType);
                HaveError = true;
            }
            else if (txtAdjustmentQty.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtAdjustmentQty, "Error");
                tp.Show("Please fill Adjustment Qty", txtAdjustmentQty);
                HaveError = true;

            }
         
            else if (txtAdjustmentQty.Text.Trim() != string.Empty)
            {
                int curQty = Convert.ToInt32(txtAdjustmentQty.Text);
                if (curQty < 1)
                {
                    tp.SetToolTip(txtAdjustmentQty, "Error");
                    tp.Show("Please fill Adjustment Quantity more than zero", txtAdjustmentQty);
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
                adjustQty = Convert.ToInt32(txtAdjustmentQty.Text);

                APP_Data.Adjustment adjustmentObj = new Adjustment();
              
                adjustmentObj.ResponsibleName = txtResponsiblePerson.Text;
                adjustmentObj.Reason = txtReason.Text;
                adjustmentObj.UserId = MemberShip.UserId;
                adjustmentObj.AdjustmentDateTime = dtpAdjustmentDate.Value;
                adjustmentObj.ProductId = Convert.ToInt32(cboProduct.SelectedValue);
                adjustmentObj.AdjustmentTypeId = Convert.ToInt32(cboAdjType.SelectedValue);

                int adjustQty1 = Convert.ToInt32(txtAdjustmentQty.Text);
                int AdjustmentQty1 = 0;

                

                Int32.TryParse(txtAdjustmentQty.Text, out AdjustmentQty1);
                string _qty = cboSign.Text + AdjustmentQty1;
                adjustmentObj.AdjustmentQty = Convert.ToInt32(_qty);
                adjustmentObj.IsDeleted = false;
                adjustmentObj.IsApproved = false;
                ProductID = Convert.ToInt32(cboProduct.SelectedValue);
                entity.Adjustments.Add(adjustmentObj);
                entity.SaveChanges();

                // increase qty inproduct  after save
                //APP_Data.Product pdObj = entity.Products.Where(x => x.Id == ProductID).FirstOrDefault();
                //if (pdObj != null)
                //{
                //    switch (cboSign.Text)
                //    {
                //        case "+":
                //            pdObj.Qty = pdObj.Qty + AdjustmentQty1;
                //            break;
                //        case "-":
                //            pdObj.Qty = pdObj.Qty - AdjustmentQty1;
                //            break;
                //    }
                
                //    entity.Entry(pdObj).State = EntityState.Modified;
                //    entity.SaveChanges();


                    //save in stocktransaction
                  
                //    Stock_Transaction st = new Stock_Transaction();
                //    st.ProductId = pdObj.Id;
          
                //    st.AdjustmentQty = Convert.ToInt32(_qty);
                    
                //    productList.Add(st);
                //    Qty = 0;

                //    Save_AdjustmentQty_ToStockTransaction(productList,Convert.ToDateTime(dtpAdjustmentDate.Value));
                //    productList.Clear();
                //}

                MessageBox.Show("Successfully Saved!", "Save");
                CancelAdjustment();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelAdjustment();
        }

        private void btnNewBrand_Click(object sender, EventArgs e)
        {
            AdjustmentTypefrm form = new AdjustmentTypefrm();
            form.ShowDialog();
        }
        #endregion

        #region Method

        #region for saving Adjustment Qty in Stock Transaction table
        private void Save_AdjustmentQty_ToStockTransaction(List<Stock_Transaction> productList, DateTime _tranDate)
        {
            int _year, _month;

            _year = _tranDate.Year;
            _month = _tranDate.Month;
            Utility.Adjustment_Run_Process(_year, _month, productList);
        }
        #endregion

        public  void Bind_AdjustmentType()
        {
            entity = new POSEntities();
            List<AdjustmentType> adjList = new List<AdjustmentType>();

            AdjustmentType adjusObj = new AdjustmentType();
            adjusObj.Id = 0;
            adjusObj.Name = "Select";
            adjList.Add(adjusObj);

            var _adjList = (from p in entity.AdjustmentTypes select p).ToList();
            adjList.AddRange(_adjList);
            cboAdjType.DataSource = adjList;
            cboAdjType.DisplayMember = "Name";
            cboAdjType.ValueMember = "Id";
            cboAdjType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAdjType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

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

        private void CancelAdjustment()
        {
            cboProduct.SelectedIndex = 0;
            txtUnitPrice.Text = "0";
            txtAdjustmentQty.Clear();
            dtpAdjustmentDate.Value = DateTime.Now.Date;
            ProductID = 0;
            txtResponsiblePerson.Clear();
            txtReason.Clear();
        }

        public void SetCurrentAdjustmentType(int Id)
        {
            APP_Data.AdjustmentType currentAdj = entity.AdjustmentTypes.Where(x => x.Id == Id).FirstOrDefault();
            if (currentAdj != null)
            {
                cboAdjType.SelectedValue = currentAdj.Id;
            }
        }
        #endregion

     

    }
}
