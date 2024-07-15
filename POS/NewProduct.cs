﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.APP_Data;
using System.IO;

namespace POS
{
    public partial class NewProduct1 : Form
    {
        #region Variables
        string file;
        private String FilePath;
        public decimal _CosignmentPrice { get; set; }
        public Boolean isEdit { get; set; }
        public Boolean IsReference = false;
        public int ProductId { get; set; }

        private POSEntities entity = new POSEntities();

        private ToolTip tp = new ToolTip();

        List<Product> productList = new List<Product>();

        List<WrapperItem> wrapperList = new List<WrapperItem>();

        Product currentProduct;
        int Qty = 0;
        List<Stock_Transaction> product_List = new List<Stock_Transaction>();
        bool IsStockAutoGenerate = false;
        #endregion

        #region Event

        public NewProduct1()
        {
            InitializeComponent();
        }

        private void NewProduct_Load(object sender, EventArgs e)
        {
            Utility.Check_AddFOCInCag();

            IsStockAutoGenerate = SettingController.UseStockAutoGenerate;
            if (IsStockAutoGenerate == true)
            {
                this.ActiveControl = txtProductCode;
                txtBarcode.Enabled = false;
            }
            else
            {
                txtBarcode.Enabled = true;
                this.ActiveControl = txtBarcode;
            }
            //txtName.Focus();
            #region Setting Hot Kyes For the Controls
            SendKeys.Send("%"); SendKeys.Send("%"); // Clicking "Alt" on page load to show underline of Hot Keys
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            #endregion



            dgvChildItems.AutoGenerateColumns = false;
            cboUnitType.SelectedIndex = 1;
            // chkSpecialPromotion.Enabled = false;
            //   txtName.Focused = true;
            //txtBarcode.ReadOnly = true;
            //txtProductCode.ReadOnly = true;
            Utility.BindReferenceProduct(cboReferenceProductName);
            // IsReference = true;

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

            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            pSubCatList.Add(SubCategoryObj1);


            //APP_Data.ProductSubCategory SubCategoryObj2 = new APP_Data.ProductSubCategory();
            //SubCategoryObj2.Id = 1;
            //SubCategoryObj2.Name = "None";
            //pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == Convert.ToInt32(cboMainCategory.SelectedValue) select c).ToList());
            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";


            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";
            //APP_Data.ProductCategory MainCategoryObj2 = new APP_Data.ProductCategory();
            //MainCategoryObj2.Id = 1;
            //MainCategoryObj2.Name = "None";
            pMainCatList.Add(MainCategoryObj1);
            //pMainCatList.Add(MainCategoryObj2);
            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

            FillProductList();



            List<Unit> unitList = new List<Unit>();
            Unit unitObj = new Unit();
            //unitObj.Id = 0;
            //unitObj.UnitName = "Select";
            // unitList.Add(unitObj);
            unitList.AddRange((from u in entity.Units select u).ToList());
            cboUnit.DataSource = unitList;
            cboUnit.DisplayMember = "UnitName";
            cboUnit.ValueMember = "Id";
            cboUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUnit.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cboUnit.SelectedIndex = 1;

            ReloadConsignor();

            List<Tax> taxList = entity.Taxes.ToList();
            List<Tax> result = new List<Tax>();
            foreach (Tax r in taxList)
            {
                Tax t = new Tax();
                t.Id = r.Id;
                t.Name = r.Name + " and " + r.TaxPercent + "%";
                t.TaxPercent = r.TaxPercent;
                result.Add(t);
            }
            cboTaxList.DataSource = result;
            cboTaxList.DisplayMember = "Name";
            cboTaxList.ValueMember = "Id";
            if (SettingController.DefaultTaxRate != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultTaxRate);
                Tax defaultTax = (from t in entity.Taxes where t.Id == id select t).FirstOrDefault();
                cboTaxList.Text = defaultTax.Name + " and " + defaultTax.TaxPercent + "%";
            }

            wrapperList.Clear();
            productList.Clear();
            if (isEdit)
            {
                //chkIsConsignment.Enabled = false;
                //Editing here
                currentProduct = (from p in entity.Products where p.Id == ProductId select p).FirstOrDefault();
                txtBarcode.Text = currentProduct.Barcode;
                txtProductCode.Text = currentProduct.ProductCode;
                txtName.Text = currentProduct.Name;
                cboUnitType.Text = currentProduct.UnitType;
                txtUnitPrice.Text = currentProduct.Price.ToString();
                txtWholeSalePrice.Text = currentProduct.WholeSalePrice.ToString();
                if (currentProduct.Brand != null)
                {
                    cboBrand.Text = currentProduct.Brand.Name;
                }
                //else
                //{
                //    cboBrand.Text = "None";
                //}
                if (currentProduct.ProductCategory != null)
                {
                    cboMainCategory.Text = currentProduct.ProductCategory.Name;
                    if (currentProduct.ProductSubCategory != null)
                    {
                        cboSubCategory.Text = currentProduct.ProductSubCategory.Name;
                    }
                    //else
                    //{
                    //    cboSubCategory.Text = "None";
                    //}
                    cboSubCategory.Enabled = true;
                }
                else
                {
                    cboMainCategory.Text = "Select";
                    cboSubCategory.Enabled = false;
                }
                cboTaxList.Text = currentProduct.Tax.Name + " and " + currentProduct.Tax.TaxPercent + "%";
                txtDiscount.Text = currentProduct.DiscountRate.ToString();

                cboUnit.Text = currentProduct.Unit.UnitName;
                txtLocation.Text = currentProduct.ProductLocation;
                chkMinStock.Checked = currentProduct.IsNotifyMinStock.Value;
                if (chkMinStock.Checked)
                {
                    txtQty.Text = currentProduct.Qty.ToString();
                    txtMinStockQty.Text = currentProduct.MinStockQty.ToString();
                    txtMinStockQty.Enabled = true;
                }
                else
                {
                    txtQty.Text = currentProduct.Qty.ToString();
                    txtToalConQty.Text = currentProduct.Qty.ToString();
                }
                txtPurchasePrice.Text = currentProduct.PurchasePrice.ToString();
                txtSize.Text = currentProduct.Size;
                chkSpecialPromotion.Checked = currentProduct.IsWrapper.Value;
                if (chkSpecialPromotion.Checked)
                {
                    chkSpecialPromotion.Enabled = false;
                    if (currentProduct.Brand.Name == "Special Promotion")
                    {

                        txtUnitPrice.ReadOnly = true;
                        txtUnitPrice.Text = currentProduct.Price.ToString();
                        chkSpecialPromotion.Checked = true;
                    }

                    wrapperList.AddRange(currentProduct.WrapperItems.ToList());
                    foreach (WrapperItem w in wrapperList)
                    {
                        productList.Add((from p in entity.Products where p.Id == w.ChildProductId select p).FirstOrDefault());
                    }
                    cboProductList.Enabled = true;
                    btnAddItem.Enabled = true;
                    dgvChildItems.DataSource = productList;

                }


                //product image
                if (currentProduct.PhotoPath != null && currentProduct.PhotoPath != "")
                {
                    this.txtImagePath.Text = currentProduct.PhotoPath.ToString();
                    string FileNmae = txtImagePath.Text.Substring(9);
                    this.ptImage.ImageLocation = Application.StartupPath + "\\Images\\" + FileNmae;
                    this.ptImage.SizeMode = PictureBoxSizeMode.Zoom;
                }


                //Consignment
                chkIsConsignment.Checked = currentProduct.IsConsignment.Value;
                if (chkIsConsignment.Checked)
                {
                    lblQty.Text = "Previous Qty";
                    cboConsignmentCounter.Text = currentProduct.ConsignmentCounter.Name;

                    //  txtConsignmentPrice.Enabled = true;
                    btnQtyChangeHistory.Enabled = true;
                    btnConsignor.Enabled = true;
                    if (currentProduct.Amount != 0)
                    {
                        rdoAmount.Checked = true;
                        txtAmt.Text = currentProduct.Amount.ToString();
                    }
                    else if (currentProduct.Percent != 0)
                    {
                        rdoPercent.Checked = true;
                        txtAmt.Text = currentProduct.Percent.ToString();
                    }
                    txtConsignmentPrice.Text = currentProduct.ConsignmentPrice.ToString();
                    cboConsignmentCounter.Enabled = true;

                }
                else
                {
                    //cboConsignmentCounter.Enabled = false;
                    //txtConsignmentPrice.Enabled = false;

                    //rdoAmount.Enabled = false;
                    //rdoPercent.Enabled = false;

                    var prod = (from p in entity.PurchaseDetails join m in entity.MainPurchases on p.MainPurchaseId equals m.Id where m.IsCompletedInvoice == true && p.ProductId == ProductId && p.IsDeleted == false select p.ProductId).ToList();
                    var salePro = (from s in entity.TransactionDetails join t in entity.Transactions on s.TransactionId equals t.Id where s.ProductId == ProductId && s.IsDeleted == false select s).ToList();

                    if (prod.Count > 0)
                    {
                        //chkIsConsignment.Enabled = false;
                        tbConsignment.Enabled = false;
                    }
                    else if (salePro.Count > 0)
                    {
                        //chkIsConsignment.Enabled = false;
                        tbConsignment.Enabled = false;
                    }
                    else
                    {
                        tbConsignment.Enabled = true;
                    }
                }
                btnSubmit.Image = POS.Properties.Resources.update_big;

                // cboMainCategory.Enabled = false;
                // cboSubCategory.Enabled = false;
                // btnNewCategory.Enabled = false;
                // btnNewSubCategofry.Enabled = false;
            }
            else
            {
                btnQtyChangeHistory.Enabled = false;
                btnConsignor.Enabled = false;
                txtWholeSalePrice.Text = "0";
                txtUnitPrice.Text = "0";
            }
        }



        public void FillProductList()
        {
            List<Product> productList1 = new List<Product>();
            Product productObj = new Product();
            productObj.Name = "Select";
            productObj.Id = 0;
            productList1.Add(productObj);
            productList1.AddRange((from pList in entity.Products select pList).ToList());
            cboProductList.DataSource = productList1;
            cboProductList.DisplayMember = "Name";
            cboProductList.ValueMember = "Id";
            cboProductList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductList.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;
            POSEntities newEntitiy = new POSEntities();

            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";

            //Validation
            if (txtBarcode.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtBarcode, "Error");
                tp.Show("Please fill up barcode!", txtBarcode);
                txtBarcode.Focus();
                hasError = true;
            }
            else if (txtProductCode.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtProductCode, "Error");
                tp.Show("Please fill up product code!", txtProductCode);
                txtProductCode.Focus();
                hasError = true;
            }
            else if (txtName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtName, "Error");
                tp.Show("Please fill up product name!", txtName);
                txtName.Focus();
                hasError = true;
            }

            else if (Utility.Brand_Combo_Control(cboBrand))
            {
                cboBrand.Focus();
                return;
            }
            else if (Utility.MainCategory_Combo_Control(cboMainCategory))
            {
                cboMainCategory.Focus();
                return;
            }
            //else if (Utility.SubCategory_Combo_Control(cboSubCategory))
            //{
            //    cboSubCategory.Focus();
            //    return;
            //}
            else if (Utility.Unit_Combo_Control(cboUnit))
            {
                cboUnit.Focus();
                return;
            }

            else if (cboBrand.SelectedIndex == 0)
            {
                tp.SetToolTip(cboBrand, "Error");
                tp.Show("Please select brand name!", cboBrand);
                cboBrand.Focus();
                hasError = true;
            }
            else if (txtQty.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtQty, "Error");
                tp.Show("Please fill up product quantity!", txtQty);
                txtQty.Focus();
                hasError = true;
            }
            else if (cboMainCategory.SelectedIndex == 0)
            {
                tp.SetToolTip(cboMainCategory, "Error");
                tp.Show("Please select main category name!", cboMainCategory);
                cboMainCategory.Focus();
                hasError = true;
            }
            ////////else if (cboMainCategory.SelectedIndex > 0 && cboSubCategory.SelectedIndex == 0)
            ////////{
            ////////    tp.SetToolTip(cboSubCategory, "Error");
            ////////    tp.Show("Please select sub category name!", cboSubCategory);
            ////////    cboSubCategory.Focus();
            ////////    hasError = true;
            ////////}
            else if (txtDiscount.Text.Trim() != string.Empty && Convert.ToDouble(txtDiscount.Text) > 100.00)
            {
                tp.SetToolTip(txtDiscount, "Error");
                tp.Show("Discount percent must not over 100!", txtDiscount);
                txtDiscount.Focus();
                hasError = true;
            }

            else if (cboUnit.SelectedIndex == -1)
            {
                tp.SetToolTip(cboUnit, "Error");
                tp.Show("Please select unit!", cboUnit);
                cboUnit.Focus();
                hasError = true;
            }
            else if (chkSpecialPromotion.Checked == true && productList.Count == 0)
            {
                tp.SetToolTip(cboProductList, "Error");
                tp.Show("Please select wrapper product item!", cboProductList);
                cboProductList.Focus();
                hasError = true;
            }
            else if (cboMainCategory.Text != "FOC")
            {
               if (txtUnitPrice.Text.Trim() == string.Empty || txtUnitPrice.Text == "0")
               {
                   tp.SetToolTip(txtUnitPrice, "Error");
                   tp.Show("Please fill up product price!", txtUnitPrice);
                   txtUnitPrice.Focus();
                   hasError = true;
               }
            }
            //else if (txtWholeSalePrice.Text.Trim() == string.Empty || txtWholeSalePrice.Text == "0")
            //{
            //    tp.SetToolTip(txtWholeSalePrice, "Error");
            //    tp.Show("Please fill up whole sale price!", txtWholeSalePrice);
            //    txtWholeSalePrice.Focus();
            //    hasError = true;
            //}
      
             if (chkIsConsignment.Checked == true)
            {
                if (cboConsignmentCounter.SelectedIndex == 0)
                {
                    tp.SetToolTip(cboConsignmentCounter, "Error");
                    tp.Show("Please select consignment counter name!", cboConsignmentCounter);
                    cboConsignmentCounter.Focus();
                    hasError = true;
                }
                else if (txtAmt.Text.Trim() == "" || txtAmt.Text == "0")
                {
                    tp.SetToolTip(txtAmt, "Error");
                    if (rdoAmount.Checked == true)
                    {
                        tp.Show("Please fill Amount !", txtAmt);
                        txtAmt.Focus();
                    }
                    else if (rdoPercent.Checked == true)
                    {
                        tp.Show("Pleas fill Percentage(%) Amount !", txtAmt);
                        txtAmt.Focus();
                    }
                    hasError = true;
                }
                else if (txtAmt.Text.Trim() != "")
                {
                    if (rdoPercent.Checked)
                    {
                        if (Convert.ToInt32(txtAmt.Text) > 100)
                        {
                            tp.SetToolTip(txtAmt, "Error");
                            tp.Show("Percent Amount must not over 100!", txtAmt);
                            txtAmt.Focus();
                            hasError = true;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(txtAmt.Text) > Convert.ToInt32(txtUnitPrice.Text))
                        {
                            tp.SetToolTip(txtUnitPrice, "Error");
                            tp.Show(" Amount should not greater than Unit Price!", txtUnitPrice);
                            hasError = true;
                        }
                    }
                }
                else if (!Calculation_Con_Qty())
                {
                    txtConQty.Focus();
                    hasError = true;
                }

            }

            if (!hasError)
            {
                //Edit product
                if (isEdit)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {

                        APP_Data.Product editProductObj = (from p in newEntitiy.Products where p.Id == ProductId select p).FirstOrDefault();
                        int oldPrice = Convert.ToInt32(editProductObj.Price); int currentPrice = 0; int differentPrice = 0;
                        int ProductCodeCount = 0, ProductNameCount = 0, BarcodeCount = 0;
                        //count = (from p in newEntitiy.Products where p.Name == txtName.Text select p).ToList().Count;
                        if (txtProductCode.Text.Trim() != editProductObj.ProductCode.Trim())
                        {
                            ProductCodeCount = (from p in newEntitiy.Products where p.ProductCode.Trim() == txtProductCode.Text.Trim() select p).ToList().Count;
                        }
                        if (txtBarcode.Text.Trim() != editProductObj.Barcode.Trim())
                        {
                            BarcodeCount = (from p in newEntitiy.Products where p.Barcode.Trim() == txtBarcode.Text.Trim() select p).ToList().Count;
                        }
                        if (txtName.Text.Trim() != editProductObj.Name.Trim())
                        {
                            ProductNameCount = (from p in newEntitiy.Products where p.Name.Trim() == txtName.Text.Trim() select p).ToList().Count;
                        }

                        if (ProductNameCount > 0)
                        {
                            tp.SetToolTip(txtName, "Error");
                            tp.Show("Product Name is already exist!", txtName);
                            return;
                        }



                        if (ProductCodeCount == 0 && BarcodeCount == 0)
                        {

                            editProductObj.Barcode = txtBarcode.Text.Trim();
                            editProductObj.ProductCode = txtProductCode.Text.Trim();
                            editProductObj.Name = txtName.Text;

                            editProductObj.BrandId = Convert.ToInt32(cboBrand.SelectedValue.ToString());

                            txtUnitPrice.Text = txtUnitPrice.Text.Trim().Replace(",", "");
                            txtQty.Text = txtQty.Text.Trim().Replace(",", "");
                            txtMinStockQty.Text = txtMinStockQty.Text.Trim().Replace(",", "");

                            editProductObj.UpdatedBy = MemberShip.UserId;
                            editProductObj.UpdatedDate = DateTime.Now;
                            editProductObj.Price = Convert.ToInt32(txtUnitPrice.Text);

                            if (txtWholeSalePrice.Text.Trim() == string.Empty)
                            {
                                editProductObj.WholeSalePrice = 0;
                            }
                            else
                            {
                                editProductObj.WholeSalePrice = Convert.ToInt32(txtWholeSalePrice.Text);
                            }
                            editProductObj.UnitType = cboUnitType.Text;
                            //get price different
                            currentPrice = Convert.ToInt32(txtUnitPrice.Text);
                            differentPrice = currentPrice - oldPrice;
                            editProductObj.Size = txtSize.Text;
                            if (txtPurchasePrice.Text.Trim() != string.Empty)
                            {
                                editProductObj.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                            }

                            //if discount is null, add default value
                            editProductObj.TaxId = Convert.ToInt32(cboTaxList.SelectedValue);

                            //product image

                            if (!(string.IsNullOrEmpty(this.txtImagePath.Text.Trim())))
                            {
                                try
                                {
                                    File.Copy(txtImagePath.Text, Application.StartupPath + "\\Images\\" + FilePath);
                                    editProductObj.PhotoPath = "~\\Images\\" + FilePath;
                                }
                                catch
                                {
                                    editProductObj.PhotoPath = "~\\Images\\" + FilePath;
                                }
                            }
                            else
                            {

                                editProductObj.PhotoPath = string.Empty;
                            }


                            if (txtDiscount.Text.Trim() == string.Empty)
                            {
                                editProductObj.DiscountRate = 0;
                            }
                            else
                            {
                                editProductObj.DiscountRate = Convert.ToDecimal(txtDiscount.Text);
                            }
                            editProductObj.IsNotifyMinStock = chkMinStock.Checked;
                            editProductObj.Qty = Convert.ToInt32(txtQty.Text);
                            //if minstock qty is null, add default value
                            if (txtMinStockQty.Text.Trim() == string.Empty)
                            {
                                editProductObj.MinStockQty = 0;
                            }
                            else
                            {
                                editProductObj.MinStockQty = Convert.ToInt32(txtMinStockQty.Text);
                            }
                            editProductObj.UnitId = Convert.ToInt32(cboUnit.SelectedValue);

                            editProductObj.ProductCategoryId = Convert.ToInt32(cboMainCategory.SelectedValue);

                            if (cboSubCategory.SelectedIndex > 0)
                            {
                                editProductObj.ProductSubCategoryId = Convert.ToInt32(cboSubCategory.SelectedValue);
                            }

                            if (txtLocation.Text.Trim() == string.Empty)
                            {
                                editProductObj.ProductLocation = string.Empty;
                            }
                            else
                            {
                                editProductObj.ProductLocation = txtLocation.Text;
                            }
                            editProductObj.WrapperItems.Clear();
                            editProductObj.IsWrapper = chkSpecialPromotion.Checked;
                            if (editProductObj.IsWrapper.Value)
                            {
                                foreach (WrapperItem wrapperObj in wrapperList)
                                {
                                    editProductObj.WrapperItems.Add(wrapperObj);
                                }
                            }
                            editProductObj.IsConsignment = chkIsConsignment.Checked;
                            if (editProductObj.IsConsignment.Value)
                            {
                                if (rdoAmount.Checked)
                                {
                                    editProductObj.Amount = Convert.ToInt32(txtAmt.Text);
                                    editProductObj.Percent = 0;
                                }
                                else
                                {
                                    editProductObj.Percent = Convert.ToInt32(txtAmt.Text);
                                    editProductObj.Amount = 0;
                                }
                                editProductObj.Qty = Convert.ToInt32(txtToalConQty.Text);
                                editProductObj.ConsignmentCounterId = Convert.ToInt32(cboConsignmentCounter.SelectedValue);
                                editProductObj.ConsignmentPrice = Convert.ToInt32(txtConsignmentPrice.Text);
                            }
                            else
                            {
                                editProductObj.ConsignmentCounterId = null;
                                editProductObj.ConsignmentPrice = null;
                            }
                            if (editProductObj.MinStockQty != null)
                            {
                                //if (editProductObj.Qty >= editProductObj.MinStockQty || chkMinStock.Checked != false)
                                //{
                                newEntitiy.Entry(editProductObj).State = System.Data.EntityState.Modified;
                                if (differentPrice != 0)
                                {
                                    ProductPriceChange pc = new ProductPriceChange();
                                    pc.ProductId = editProductObj.Id;
                                    pc.OldPrice = oldPrice;
                                    pc.Price = editProductObj.Price;
                                    pc.UserID = MemberShip.UserId;
                                    pc.UpdateDate = DateTime.Now;
                                    newEntitiy.ProductPriceChanges.Add(pc);
                                }

                                int _stockInQty = Convert.ToInt32(txtConQty.Text);

                                if (_stockInQty != 0)
                                {
                                    ProductQuantityChange pq = new ProductQuantityChange();
                                    pq.ProductId = editProductObj.Id;


                                    if (cboConQty.Text == "-")
                                    {
                                        pq.StockInQty = _stockInQty * -1;
                                    }
                                    else
                                    {
                                        pq.StockInQty = _stockInQty;
                                    }
                                    pq.UserID = MemberShip.UserId;
                                    pq.UpdateDate = DateTime.Now;
                                    newEntitiy.ProductQuantityChanges.Add(pq);

                                    //save in stocktransaction
                                    product_List = new List<Stock_Transaction>();
                                    Stock_Transaction st = new Stock_Transaction();
                                    st.ProductId = editProductObj.Id;
                                    Qty = Convert.ToInt32(pq.StockInQty);
                                    st.Consignment = Qty;
                                    product_List.Add(st);
                                    Qty = 0;

                                    //save in stocktransaction
                                    Save_ConsingQty_ToStockTransaction(product_List);
                                    product_List.Clear();
                                }


                                newEntitiy.SaveChanges();

                                MessageBox.Show("Successfully Updated!", "Update");

                                if (System.Windows.Forms.Application.OpenForms["ItemList"] != null)
                                {
                                    ItemList newForm = (ItemList)System.Windows.Forms.Application.OpenForms["ItemList"];
                                    newForm.DataBind();
                                }
                                if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                                {
                                    Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                                    newForm.Clear();
                                }

                                if (System.Windows.Forms.Application.OpenForms["PurchaseInput"] != null)
                                {
                                    PurchaseInput newForm = (PurchaseInput)System.Windows.Forms.Application.OpenForms["PurchaseInput"];
                                    // newForm.Clear();
                                    newForm.ReloadProduct();
                                    newForm.SetCurrentProduct(editProductObj.Id);
                                }
                                //Clear Data
                                ClearInputs();
                                this.Dispose();

                                //}
                                //else
                                //{
                                //    MessageBox.Show("Available quantity must be greater than minimum stock quantity!");
                                //    newEntitiy.Dispose();
                                //    return;
                                //}
                            }
                        }
                        else if (BarcodeCount > 0)
                        {
                            tp.SetToolTip(txtBarcode, "Error");
                            tp.Show("This barcode is already exist!", txtBarcode);

                        }
                        else if (ProductCodeCount > 0)
                        {
                            tp.SetToolTip(txtProductCode, "Error");
                            tp.Show("This product code is already exist!", txtProductCode);
                        }
                    }
                }
                //add new product
                else
                {
                    int ProductCodeCount = 0, BarcodeCount = 0, ProductNameCount=0;
                    //count = (from p in newEntitiy.Products where p.Name == txtName.Text select p).ToList().Count;
                    ProductCodeCount = (from p in newEntitiy.Products where p.ProductCode.Trim() == txtProductCode.Text.Trim() select p).ToList().Count;
                    BarcodeCount = (from p in newEntitiy.Products where p.Barcode.Trim() == txtBarcode.Text.Trim() select p).ToList().Count;
                    ProductNameCount = (from p in newEntitiy.Products where p.Name.Trim() == txtName.Text.Trim() select p).ToList().Count;

                    if (ProductNameCount > 0)
                    {
                        tp.SetToolTip(txtName, "Error");
                        tp.Show("Product Name is already exist!", txtName);
                        return;
                    }
                    if (ProductCodeCount == 0 && BarcodeCount == 0)
                    {
                        APP_Data.Product productObj = new APP_Data.Product();

                        productObj.Barcode = txtBarcode.Text;
                        productObj.ProductCode = txtProductCode.Text;

                        productObj.Name = txtName.Text;

                        productObj.BrandId = Convert.ToInt32(cboBrand.SelectedValue.ToString());

                        txtUnitPrice.Text = txtUnitPrice.Text.Trim().Replace(",", "");
                        txtQty.Text = txtQty.Text.Trim().Replace(",", "");
                        txtConQty.Text = txtConQty.Text.Trim().Replace(",", "");
                        txtMinStockQty.Text = txtMinStockQty.Text.Trim().Replace(",", "");
                        txtWholeSalePrice.Text = txtWholeSalePrice.Text.Trim().Replace(",", "");

                        productObj.CreatedBy = MemberShip.UserId;
                        productObj.CreatedDate = DateTime.Now;
                        productObj.Price = Convert.ToInt32(txtUnitPrice.Text);
                        if (txtWholeSalePrice.Text.Trim() == string.Empty)
                        {
                            productObj.WholeSalePrice = 0;
                        }
                        else
                        {
                            productObj.WholeSalePrice = Convert.ToInt32(txtWholeSalePrice.Text);
                        }
                        productObj.UnitType = cboUnitType.Text;

                        productObj.TaxId = Convert.ToInt32(cboTaxList.SelectedValue);
                        //if discount is null, add default value
                        if (txtDiscount.Text.Trim() == string.Empty)
                        {
                            productObj.DiscountRate = 0;
                        }
                        else
                        {
                            productObj.DiscountRate = Convert.ToDecimal(txtDiscount.Text);
                        }
                        productObj.Size = txtSize.Text;
                        if (txtPurchasePrice.Text.Trim() != string.Empty)
                        {
                            productObj.PurchasePrice = Convert.ToInt32(txtPurchasePrice.Text);
                        }

                        productObj.IsNotifyMinStock = chkMinStock.Checked;
                        productObj.Qty = Convert.ToInt32(txtQty.Text);

                        if (chkIsConsignment.Checked)
                        {
                            productObj.Qty = Convert.ToInt32(txtToalConQty.Text);
                        }
                        //if minstock qty is null, add default value
                        if (txtMinStockQty.Text.Trim() == string.Empty)
                        {
                            productObj.MinStockQty = 0;
                        }
                        else
                        {
                            productObj.MinStockQty = Convert.ToInt32(txtMinStockQty.Text);
                        }
                        productObj.UnitId = Convert.ToInt32(cboUnit.SelectedValue);

                        if (txtLocation.Text.Trim() == string.Empty)
                        {
                            productObj.ProductLocation = string.Empty;
                        }
                        else
                        {
                            productObj.ProductLocation = txtLocation.Text;
                        }


                        productObj.ProductCategoryId = Convert.ToInt32(cboMainCategory.SelectedValue);

                        if (cboSubCategory.SelectedIndex > 0)
                        {
                            productObj.ProductSubCategoryId = Convert.ToInt32(cboSubCategory.SelectedValue);
                        }

                        productObj.IsWrapper = chkSpecialPromotion.Checked;
                        if (productObj.IsWrapper.Value)
                        {
                            foreach (WrapperItem wrapperObj in wrapperList)
                            {
                                productObj.WrapperItems.Add(wrapperObj);
                            }
                        }

                        productObj.IsConsignment = chkIsConsignment.Checked;
                        if (productObj.IsConsignment.Value)
                        {
                            if (rdoAmount.Checked)
                            {
                                productObj.Amount = Convert.ToInt32(txtAmt.Text);
                                productObj.Percent = 0;
                            }
                            else
                            {
                                productObj.Percent = Convert.ToInt32(txtAmt.Text);
                                productObj.Amount = 0;
                            }

                            productObj.ConsignmentCounterId = Convert.ToInt32(cboConsignmentCounter.SelectedValue);
                            productObj.ConsignmentPrice = Convert.ToInt32(txtConsignmentPrice.Text);
                        }
                        else
                        {
                            productObj.ConsignmentCounterId = null;
                            productObj.ConsignmentPrice = 0;
                        }

                        //product photo
                        if (!(string.IsNullOrEmpty(this.txtImagePath.Text.Trim())))
                        {
                            try
                            {
                                File.Copy(txtImagePath.Text, Application.StartupPath + "\\Images\\" + FilePath);

                                productObj.PhotoPath = "~\\Images\\" + FilePath;
                            }
                            catch
                            {
                                productObj.PhotoPath = "~\\Images\\" + FilePath;
                            }
                        }
                        else
                        {
                            productObj.PhotoPath = string.Empty;
                        }


                        //if (productObj.MinStockQty != null)
                        //{
                        //if (productObj.Qty > productObj.MinStockQty || chkMinStock.Checked == false)
                        //{
                        newEntitiy.Products.Add(productObj);
                        newEntitiy.SaveChanges();


                        #region Update AutoGenerateNo. in brand table
                        int _brandId=Convert.ToInt32(cboBrand.SelectedValue);
                        var _brandData = (from b in entity.Brands where b.Id == _brandId select b).FirstOrDefault();
                        if (_brandData.AutoGenerateNo == null)
                        {
                            _brandData.AutoGenerateNo = 1;
                        }
                        else
                        {
                            _brandData.AutoGenerateNo += 1;
                        }
                        entity.Entry(_brandData).State = EntityState.Modified;
                        //newEntitiy.Entry(_brandData).State = System.Data.EntityState.Modified;
                        entity.SaveChanges();
                        #endregion

                        if (chkIsConsignment.Checked)
                        {
                            int _stockInQty = Convert.ToInt32(txtConQty.Text);


                            if (_stockInQty != 0)
                            {
                                ProductQuantityChange pq = new ProductQuantityChange();
                                pq.ProductId = productObj.Id;


                                if (cboConQty.Text == "-")
                                {
                                    pq.StockInQty = _stockInQty * -1;
                                }
                                else
                                {
                                    pq.StockInQty = _stockInQty;
                                }

                                pq.UserID = MemberShip.UserId;
                                pq.UpdateDate = DateTime.Now;
                                newEntitiy.ProductQuantityChanges.Add(pq);
                                newEntitiy.SaveChanges();

                                //save in stock Transaction

                                Stock_Transaction st = new Stock_Transaction();
                                st.ProductId = productObj.Id;
                                Qty = Convert.ToInt32(pq.StockInQty);
                                st.Consignment = Qty;
                                product_List.Add(st);
                                Qty = 0;

                                //save in stocktransaction
                                Save_ConsingQty_ToStockTransaction(product_List);
                                product_List.Clear();
                            }


                        }


                        MessageBox.Show("Successfully Saved!", "Save");

                        if (System.Windows.Forms.Application.OpenForms["ItemList"] != null)
                        {
                            ItemList newForm = (ItemList)System.Windows.Forms.Application.OpenForms["ItemList"];
                            newForm.DataBind();
                        }
                        if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                        {
                            Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                            newForm.Clear();
                        }
                        if (System.Windows.Forms.Application.OpenForms["PurchaseInput"] != null)
                        {
                            PurchaseInput newForm = (PurchaseInput)System.Windows.Forms.Application.OpenForms["PurchaseInput"];
                            //   newForm.Clear();
                            newForm.ReloadProduct();
                            newForm.SetCurrentProduct(productObj.Id);
                        }
                        //Clear Data
                        ClearInputs();
                        // }
                        //else
                        //{
                        //    MessageBox.Show("Available quantity must be greater than minimum stock quantity!");
                        //    newEntitiy.Dispose();
                        //    return;
                        //}
                        // }
                    }
                    else if (BarcodeCount > 0)
                    {
                        tp.SetToolTip(txtBarcode, "Error");
                        tp.Show("This barcode is already exist!", txtBarcode);
                    }
                    else if (ProductCodeCount > 0)
                    {
                        tp.SetToolTip(txtProductCode, "Error");
                        tp.Show("This product code is already exist!", txtProductCode);
                    }
                }
                lblQty.Text = "Qty";
                List<Product> productList1 = new List<Product>();

                Product productObj1 = new Product();
                productObj1.Name = "Select";
                productObj1.Id = 0;
                productList1.Add(productObj1);
                productList1.AddRange((from pList in entity.Products select pList).ToList());
                cboProductList.DataSource = productList1;
                cboProductList.DisplayMember = "Name";
                cboProductList.ValueMember = "Id";
                cboProductList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboProductList.AutoCompleteSource = AutoCompleteSource.ListItems;

                ////////Clear Data
                //////ClearInputs();
                Utility.BindReferenceProduct(cboReferenceProductName);
                chkUseReference.CheckedChanged += new EventHandler(chkUseReference_CheckedChanged);
            }
        }

        #region for saving Cosignment Qty in Stock Transaction table


        private void Save_ConsingQty_ToStockTransaction(List<Stock_Transaction> productList)
        {
            int _year, _month;

            _year = System.DateTime.Now.Year;
            _month = System.DateTime.Now.Month;
            Utility.Consignment_Run_Process(_year, _month, productList);
        }
        #endregion

        private Image bytearraytoimage(byte[] b)
        {
            MemoryStream ms = new MemoryStream(b);
            Image img = Image.FromStream(ms);
            return img;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Product pObj = new Product();
            bool isHave = false;
            int totalAmount = 0;

            int id = Convert.ToInt32(cboProductList.SelectedValue);
            if (id > 0)
            {
                foreach (Product p in productList)
                {
                    if (p.Id == id) isHave = true;//
                }
                if (!isHave)
                {
                    WrapperItem wrapperItemObj = new WrapperItem();
                    wrapperItemObj.ChildProductId = id;
                    wrapperList.Add(wrapperItemObj);
                    dgvChildItems.DataSource = "";
                    //dgvChildItems.DataSource = wrapperList;
                    pObj = (from p in entity.Products where p.Id == id select p).FirstOrDefault();
                    productList.Add(pObj);
                    dgvChildItems.DataSource = productList;
                    totalAmount += Convert.ToInt32(pObj.Price);
                    if (txtUnitPrice.Text == "")
                    {
                        txtUnitPrice.Text = "0";
                    }
                    if (chkSpecialPromotion.Checked == true)
                    {
                        txtUnitPrice.Text = (Convert.ToInt32(txtUnitPrice.Text) + totalAmount).ToString();
                    }
                }
                else
                {
                    //to show meassage for duplicate 
                    MessageBox.Show("This product is already include!");
                }
            }
            else
            {
                //to show message
            }
        }
        private void cboMainCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMainCategory.SelectedIndex > 0)
            {
                int productCategoryId = Int32.Parse(cboMainCategory.SelectedValue.ToString());
                List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
                APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
                SubCategoryObj1.Id = 0;
                SubCategoryObj1.Name = "Select";
                APP_Data.ProductSubCategory SubCategoryObj2 = new APP_Data.ProductSubCategory();
                //SubCategoryObj2.Id = 1;
                //SubCategoryObj2.Name = "None";
                pSubCatList.Add(SubCategoryObj1);
                //  pSubCatList.Add(SubCategoryObj2);
                pSubCatList.AddRange((from c in entity.ProductSubCategories where c.ProductCategoryId == productCategoryId select c).ToList());
                cboSubCategory.DataSource = pSubCatList;
                cboSubCategory.DisplayMember = "Name";
                cboSubCategory.ValueMember = "Id";
                cboSubCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cboSubCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
                cboSubCategory.Enabled = true;
            }
            else
            {
                cboSubCategory.SelectedIndex = 0;
                cboSubCategory.Enabled = false;
            }
        }
        private void dgvChildItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvChildItems.Rows[e.RowIndex];
                        string pdcode = row.Cells[0].Value.ToString();
                        APP_Data.Product p = entity.Products.Where(x => x.ProductCode == pdcode).FirstOrDefault();
                        if (txtUnitPrice.Text != "")
                        {
                            txtUnitPrice.Text = (Convert.ToInt32(txtUnitPrice.Text) - p.Price).ToString();
                        }


                        dgvChildItems.DataSource = "";
                        wrapperList.RemoveAt(e.RowIndex);
                        productList.RemoveAt(e.RowIndex);
                        dgvChildItems.DataSource = productList;
                    }
                }
            }
        }

        ////private void chkSpecialPromotion_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    if (chkSpecialPromotion.Checked)
        ////    {
        ////        cboProductList.Enabled = true;
        ////        btnAddItem.Enabled = true;
        ////        txtUnitPrice.Clear();
        ////        txtUnitPrice.ReadOnly = false;
        ////        chkSpecialPromotion.Enabled = true;
        ////    }
        ////    else
        ////    {
        ////        cboProductList.Enabled = false;
        ////        btnAddItem.Enabled = false;
        ////        productList.Clear();
        ////        wrapperList.Clear();
        ////        dgvChildItems.DataSource = "";
        ////        txtUnitPrice.Clear();               
        ////        chkSpecialPromotion.Enabled = false;
        ////    }
        ////}

        private void chkIsConsignment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsConsignment.Checked)
            {
                cboConsignmentCounter.Enabled = true;
                // txtConsignmentPrice.Enabled = true;
                cboConQty.Enabled = true;
                rdoAmount.Enabled = true;
                rdoPercent.Enabled = true;
                txtAmt.Enabled = true;
                txtConQty.Enabled = true;
                cboConQty.SelectedIndex = 0;
                btnConsignor.Enabled = true;
                btnQtyChangeHistory.Enabled = true;
            }
            else
            {
                cboConsignmentCounter.Enabled = false;
                cboConQty.Enabled = false;
                txtConsignmentPrice.Enabled = false;
                cboConsignmentCounter.SelectedIndex = 0;
                txtConsignmentPrice.Text = "";

                txtAmt.Enabled = false;
                txtAmt.Text = "";
                txtConQty.Enabled = false;
                txtConQty.Text = "0";
                rdoAmount.Enabled = false;
                rdoPercent.Enabled = false;
                btnConsignor.Enabled = false;
                btnQtyChangeHistory.Enabled = false;
            }
        }

        private void NewProduct_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtName);
            tp.Hide(txtQty);
            tp.Hide(txtUnitPrice);
            tp.Hide(cboBrand);
            tp.Hide(cboMainCategory);
            tp.Hide(cboProductList);
            tp.Hide(cboSubCategory);
            tp.Hide(cboUnit);
            tp.Hide(cboConsignmentCounter);
            tp.Hide(txtBarcode);
            tp.Hide(txtWholeSalePrice);
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtMinStockQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void chkMinStock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMinStock.Checked)
            {
                txtMinStockQty.Enabled = true;
            }
            else
            {
                txtMinStockQty.Enabled = false;
                txtMinStockQty.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtLocation.Text = "";
            txtBarcode.Text = "";
            txtProductCode.Text = "";
            txtConsignmentPrice.Text = "";
            txtConsignmentPrice.Enabled = false;

            txtAmt.Text = "";
            txtAmt.Enabled = false;

            txtDiscount.Text = "";
            txtMinStockQty.Text = "";
            txtMinStockQty.Enabled = false;
            txtName.Text = "";
            txtPurchasePrice.Text = "";
            txtQty.Text = "0";
            txtSize.Text = "";
            txtUnitPrice.Text = "";
            txtWholeSalePrice.Text = "";
            cboUnitType.SelectedIndex = 1;
            chkIsConsignment.Checked = false;
            chkSpecialPromotion.Checked = false;
            chkMinStock.Checked = false;
            cboBrand.SelectedIndex = 0;
            if (chkIsConsignment.Checked)
            {
                cboConsignmentCounter.SelectedIndex = 0;
                cboConsignmentCounter.Enabled = false;

                txtToalConQty.Text = "0";
                txtConQty.Text = "0";
                cboConQty.SelectedIndex = 0;

            }
            lblQty.Text = "Qty";
            cboMainCategory.SelectedIndex = 0;
            cboSubCategory.SelectedIndex = 0;
            cboSubCategory.Enabled = false;
            cboTaxList.SelectedIndex = 0;
            cboUnit.SelectedIndex = 0;
            cboProductList.SelectedIndex = 0;
            cboProductList.Enabled = false;
            btnAddItem.Enabled = false;

            rdoAmount.Enabled = false;
            rdoPercent.Enabled = false;
            btnSubmit.Image = POS.Properties.Resources.save_big;
            cboReferenceProductName.SelectedIndex = 0;
            
            
        }


        private void btnNewBrand_Click(object sender, EventArgs e)
        {
            Brand newForm = new Brand();
            newForm.ShowDialog();
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            ProductCategory newForm = new ProductCategory();
            newForm.ShowDialog();
        }

        private void btnNewSubCategofry_Click(object sender, EventArgs e)
        {
            ProductSubCategory newFrom = new ProductSubCategory();
            newFrom.ShowDialog();
        }

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            UnitForm newForm = new UnitForm();
            newForm.ShowDialog();

        }
        #endregion

        #region Function
        private void Clear_Control()
        {
            txtLocation.Text = "";
            txtBarcode.Text = "";
            txtProductCode.Text = "";
            txtConsignmentPrice.Text = "";
            txtConsignmentPrice.Enabled = false;

            txtAmt.Text = "";
            txtAmt.Enabled = false;

            txtDiscount.Text = "";
            txtMinStockQty.Text = "";
            txtMinStockQty.Enabled = false;
            txtName.Text = "";
            txtPurchasePrice.Text = "";
            txtQty.Text = "0";
            txtSize.Text = "";
            txtUnitPrice.Text = "";
            txtWholeSalePrice.Text = "";
            chkIsConsignment.Checked = false;
            chkSpecialPromotion.Checked = false;
            chkMinStock.Checked = false;
            cboBrand.SelectedIndex = 0;
            cboConsignmentCounter.SelectedIndex = 0;
            cboConsignmentCounter.Enabled = false;
            cboMainCategory.SelectedIndex = 0;
            cboSubCategory.SelectedIndex = 0;
            cboSubCategory.Enabled = false;
            cboTaxList.SelectedIndex = 0;
            cboUnit.SelectedIndex = 0;
            cboProductList.SelectedIndex = 0;
            cboProductList.Enabled = false;
            btnAddItem.Enabled = false;
            dgvChildItems.DataSource = "";

            cboUnit.SelectedIndex = 0;

            txtToalConQty.Text = "0";
            txtConQty.Text = "0";
            cboConQty.SelectedIndex = 0;
            lblQty.Text = "Qty";
            txtImagePath.Clear();
            ptImage.Image = null;
        }

        private void ClearInputs()
        {
            txtLocation.Text = "";
            txtBarcode.Text = "";
            txtProductCode.Text = "";
            txtConsignmentPrice.Text = "";
            txtConsignmentPrice.Enabled = false;

            txtAmt.Text = "";
            txtAmt.Enabled = false;

            txtDiscount.Text = "";
            txtMinStockQty.Text = "";
            txtMinStockQty.Enabled = false;
            txtName.Text = "";
            txtPurchasePrice.Text = "";
            txtQty.Text = "0";
            txtSize.Text = "";
            txtUnitPrice.Text = "";
            txtWholeSalePrice.Text = "";
            chkIsConsignment.Checked = false;
            chkSpecialPromotion.Checked = false;
            chkMinStock.Checked = false;
            cboBrand.SelectedIndex = 0;
            cboConsignmentCounter.SelectedIndex = 0;
            cboConsignmentCounter.Enabled = false;
            cboMainCategory.SelectedIndex = 0;
            cboSubCategory.SelectedIndex = 0;
            cboSubCategory.Enabled = false;
            cboTaxList.SelectedIndex = 0;
            cboUnit.SelectedIndex = 0;
            cboProductList.SelectedIndex = 0;
            cboProductList.Enabled = false;
            btnAddItem.Enabled = false;
            dgvChildItems.DataSource = "";

            cboUnit.SelectedIndex = 0;

            txtToalConQty.Text = "0";
            txtConQty.Text = "0";
            cboConQty.SelectedIndex = 0;
            lblQty.Text = "Qty";
            txtImagePath.Clear();
            ptImage.Image = null;

            chkUseReference.Checked = false;
            cboReferenceProductName.SelectedIndex = -1;
            UseReference(false);
        }

        public void ReloadBrand()
        {
            entity = new POSEntities();
            List<APP_Data.Brand> BrandList = new List<APP_Data.Brand>();

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
            if (isEdit)
            {
                if (currentProduct.Brand != null)
                {
                    cboBrand.Text = currentProduct.Brand.Name;
                }
                //else
                //{
                //    cboBrand.Text = "None";
                //}
            }
        }

        public void SetCurrentConsignor(Int32 ConsignorId)
        {

            ConsignmentCounter currentConsignor = entity.ConsignmentCounters.Where(x => x.Id == ConsignorId).FirstOrDefault();
            if (currentConsignor != null)
            {
                cboConsignmentCounter.SelectedValue = currentConsignor.Id;
            }
        }

        public void SetCurrentUnit(Int32 UnitId)
        {

            Unit currentUnit = entity.Units.Where(x => x.Id == UnitId).FirstOrDefault();
            if (currentUnit != null)
            {
                cboUnit.SelectedValue = currentUnit.Id;
            }
        }

        public void SetCurrentBrand(Int32 BrandId)
        {
            APP_Data.Brand currentBrand = entity.Brands.Where(x => x.Id == BrandId).FirstOrDefault();
            if (currentBrand != null)
            {
                cboBrand.SelectedValue = currentBrand.Id;
            }
        }

        public void SetCurrentCategory(Int32 CategoryId)
        {
            APP_Data.ProductCategory currentCategory = entity.ProductCategories.Where(x => x.Id == CategoryId).FirstOrDefault();
            if (currentCategory != null)
            {
                cboMainCategory.SelectedValue = currentCategory.Id;
            }
        }

        public void SetCurrentSubCategory(Int32 SubCategoryId)
        {
            APP_Data.ProductSubCategory currentSubCategory = entity.ProductSubCategories.Where(x => x.Id == SubCategoryId).FirstOrDefault();
            if (currentSubCategory != null)
            {
                cboSubCategory.Text = currentSubCategory.Name;
            }
        }

        public void ReloadConsignor()
        {
            entity = new POSEntities();
            List<ConsignmentCounter> consignmentCounterList = new List<ConsignmentCounter>();
            ConsignmentCounter consignmentObj = new ConsignmentCounter();
            consignmentObj.Id = 0;
            consignmentObj.Name = "Select";
            consignmentCounterList.Add(consignmentObj);
            consignmentCounterList.AddRange((from c in entity.ConsignmentCounters select c).ToList());
            cboConsignmentCounter.DataSource = consignmentCounterList;
            cboConsignmentCounter.DisplayMember = "Name";
            cboConsignmentCounter.ValueMember = "Id";
            cboConsignmentCounter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboConsignmentCounter.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void ReloadCategory()
        {
            entity = new POSEntities();
            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();

            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            pSubCatList.Add(SubCategoryObj1);

            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";

            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            //var pMainCatList = (from maincag in entity.ProductCategories select maincag).ToList();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";

            pMainCatList.Add(MainCategoryObj1);

            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;


            if (isEdit)
            {
                if (currentProduct.ProductCategory != null)
                {
                    cboMainCategory.Text = currentProduct.ProductCategory.Name;
                    if (currentProduct.ProductSubCategory != null)
                    {
                        cboSubCategory.Text = currentProduct.ProductSubCategory.Name;
                    }
                    //else
                    //{
                    //    cboSubCategory.Text = "None";
                    //}
                    cboSubCategory.Enabled = true;
                }
                else
                {
                    cboMainCategory.Text = "Select";
                    cboSubCategory.Enabled = false;
                }
            }
        }
        public void ReloadSubCategory()
        {
            List<APP_Data.ProductSubCategory> pSubCatList = new List<APP_Data.ProductSubCategory>();
            APP_Data.ProductSubCategory SubCategoryObj1 = new APP_Data.ProductSubCategory();
            SubCategoryObj1.Id = 0;
            SubCategoryObj1.Name = "Select";
            pSubCatList.Add(SubCategoryObj1);

            cboSubCategory.DataSource = pSubCatList;
            cboSubCategory.DisplayMember = "Name";
            cboSubCategory.ValueMember = "Id";

            List<APP_Data.ProductCategory> pMainCatList = new List<APP_Data.ProductCategory>();
            APP_Data.ProductCategory MainCategoryObj1 = new APP_Data.ProductCategory();
            MainCategoryObj1.Id = 0;
            MainCategoryObj1.Name = "Select";

            pMainCatList.Add(MainCategoryObj1);

            pMainCatList.AddRange((from MainCategory in entity.ProductCategories select MainCategory).ToList());
            cboMainCategory.DataSource = pMainCatList;
            cboMainCategory.DisplayMember = "Name";
            cboMainCategory.ValueMember = "Id";
            cboMainCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboMainCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            if (isEdit)
            {
                if (currentProduct.ProductCategory != null)
                {
                    cboMainCategory.Text = currentProduct.ProductCategory.Name;
                    if (currentProduct.ProductSubCategory != null)
                    {
                        cboSubCategory.Text = currentProduct.ProductSubCategory.Name;
                    }
                    //else
                    //{
                    //    cboSubCategory.Text = "None";
                    //}
                    cboSubCategory.Enabled = true;
                }
                else
                {
                    cboMainCategory.Text = "Select";
                    cboSubCategory.Enabled = false;
                }
            }
        }

        public void ReloadUnit()
        {
            entity = new POSEntities();
            List<Unit> unitList = new List<Unit>();
            Unit unitObj = new Unit();
            unitObj.Id = 0;
            unitObj.UnitName = "Select";
            unitList.Add(unitObj);
            unitList.AddRange((from u in entity.Units select u).ToList());
            cboUnit.DataSource = unitList;
            cboUnit.DisplayMember = "UnitName";
            cboUnit.ValueMember = "Id";
            cboUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboUnit.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (isEdit)
            {

                cboUnit.Text = currentProduct.Unit.UnitName;
            }
        }
        #endregion

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private bool Calculation_Con_Qty()
        {
            bool status = true;
            if (txtConQty.Text == string.Empty)
            {
                txtConQty.Text = "0";
            }

            if (cboConQty.Text == "+")
            {
                txtToalConQty.Text = Convert.ToInt32(Convert.ToInt32(txtQty.Text) + Convert.ToInt32(txtConQty.Text)).ToString();
                return true;
            }
            else if (cboConQty.Text == "-")
            {
                if (Convert.ToInt32(txtQty.Text) >= Convert.ToInt32(txtConQty.Text))
                {
                    txtToalConQty.Text = Convert.ToInt32(Convert.ToInt32(txtQty.Text) - Convert.ToInt32(txtConQty.Text)).ToString();
                    return true;
                }
                else
                {
                    MessageBox.Show("Can't reduce Consignment Qty.");
                    status = false;
                }
            }
            return status;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((txtConQty.Focused) && (keyData == (Keys.Enter) || keyData == (Keys.Tab)))
            {
                if (Calculation_Con_Qty())
                {
                    btnSubmit.Focus();
                }
                else
                {
                    txtConQty.Focus();
                }
                return true;
            }
            else if (btnSubmit.Focused && keyData == (Keys.Shift | Keys.Tab))
            {
                txtConQty.Focus();
                return true;
            }
            else if (txtBarcode.Focused && keyData == (Keys.Tab | Keys.Shift))
            {
                if (cboReferenceProductName.Enabled == false)
                {
                    chkUseReference.Focus();
                }
                else
                {
                    cboReferenceProductName.Focus();
                }
                return true;
            }
            else if (txtBarcode.Focused && keyData == (Keys.Tab))
            {
                txtProductCode.Focus();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

        }

        private void chkSpecialPromotion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialPromotion.Checked)
            {
                cboProductList.Enabled = true;
                btnAddItem.Enabled = true;
                txtUnitPrice.Clear();
                txtUnitPrice.ReadOnly = false;
                chkSpecialPromotion.Enabled = true;

                //txtUnitPrice.Clear();
                var brandId = (from b in entity.Brands where b.Name == "Special Promotion" select b.Id).FirstOrDefault();
                cboBrand.SelectedValue = brandId;

                var mainCatId = (from b in entity.ProductCategories where b.Name == "Special Promotion" select b.Id).FirstOrDefault();
                cboMainCategory.SelectedValue = mainCatId;

                var mainSubCatId = (from b in entity.ProductSubCategories where b.Name == "Special Promotion" select b.Id).FirstOrDefault();
                cboSubCategory.SelectedValue = mainSubCatId;
                wrapperList.Clear();
                productList.Clear();
            }
            else
            {
                cboProductList.Enabled = false;
                btnAddItem.Enabled = false;
                productList.Clear();
                wrapperList.Clear();
                dgvChildItems.DataSource = "";
                txtUnitPrice.Clear();
                //chkSpecialPromotion.Enabled = false;


                cboBrand.SelectedValue = 0;
                cboMainCategory.SelectedValue = 0;
                cboSubCategory.SelectedValue = 0;
                wrapperList.Clear();
                productList.Clear();
                txtUnitPrice.Clear();
                dgvChildItems.DataSource = null;
            }
        }


        private void cboMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboMainCategory.SelectedIndex > 0)
            //{
            //    if (isEdit == false)
            //    {
            //        int id = Convert.ToInt32(cboMainCategory.SelectedValue);
            //        APP_Data.ProductCategory pdSub = entity.ProductCategories.Where(x => x.Id == id).FirstOrDefault();
            //        if (pdSub != null && pdSub.Prefix != null)
            //        {
            //            var ProductCode = entity.GetProductCode(pdSub.Prefix, 3, 2);
            //            txtProductCode.Text = ProductCode.FirstOrDefault().ToString();
            //            txtBarcode.Text = txtProductCode.Text;
            //        }
            //    }
            //}
            //else
            //{
            //    if (isEdit == false)
            //    {
            //        txtProductCode.Clear();
            //        txtBarcode.Clear();
            //    }

            //}
          
            if (cboMainCategory.Text == "FOC")
            {
                cboSubCategory.Text = "FOC";
                txtUnitPrice.Text = "0";
                txtWholeSalePrice.Text = "0";
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            txtProductCode.Text = txtBarcode.Text.ToString();
            txtName.Focus();
        }

        private void txtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtAmt_Leave(object sender, EventArgs e)
        {
            chechk_symbol(txtAmt);
            Radio_Checked();
        }

        private void Radio_Checked()
        {
            if (txtAmt.Text != "" && txtAmt.Text != "0")
            {
                if (txtUnitPrice.Text != "" && txtUnitPrice.Text != "0")
                {
                    if (rdoAmount.Checked == true)
                    {
                        if (Convert.ToInt32(txtUnitPrice.Text) > Convert.ToInt32(txtAmt.Text))
                        {
                            _CosignmentPrice = Convert.ToInt32(txtUnitPrice.Text) - Convert.ToInt32(txtAmt.Text);
                        }
                        else
                        {
                            tp.SetToolTip(txtAmt, "Error");
                            tp.Show("Amount must not over Unit Price!", txtAmt);

                        }
                    }
                    else
                    {
                        _CosignmentPrice = Convert.ToInt32(txtUnitPrice.Text) - (Convert.ToInt32(txtUnitPrice.Text) / 100 * Convert.ToInt32(txtAmt.Text));
                    }
                    txtConsignmentPrice.Text = _CosignmentPrice.ToString();
                }
                else
                {
                    Clear_ConsignmentAmt();
                }
            }
            else
            {
                Clear_ConsignmentAmt();
            }
        }

        private void Clear_ConsignmentAmt()
        {

            txtConsignmentPrice.Clear();
        }

        private void rdoAmount_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Checked();
        }

        private void rdoPercent_CheckedChanged(object sender, EventArgs e)
        {
            Radio_Checked();
        }

        private void txtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Radio_Checked();
            }
        }

        private void txtUnitPrice_Leave(object sender, EventArgs e)
        {
            chechk_symbol(txtUnitPrice);

            Radio_Checked();
        }


        private void chechk_symbol(TextBox txt)
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";

            if (txt.Text != string.Empty)
            {
                //stroe the every caharter u enter in the textbox
                char[] testarr = txt.Text.ToCharArray();
                //to check the symbols in the given input through for loop

                for (int i = 0; i < testarr.Length; i++)
                {
                    if (!char.IsNumber(testarr[i]))
                    {
                        tp.SetToolTip(txt, "Error");
                        tp.Show("Symbols are not allowed", txt);
                        txt.Focus();
                    }
                }
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            //chechk_symbol(txtDiscount);
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            chechk_symbol(txtQty);
        }

        private void txtMinStockQty_Leave(object sender, EventArgs e)
        {
            chechk_symbol(txtMinStockQty);
        }

        private void txtConsignmentPrice_Leave(object sender, EventArgs e)
        {
            chechk_symbol(txtConsignmentPrice);
        }

        private void btnConsignor_Click(object sender, EventArgs e)
        {
            ConsignmentProductCounter newForm = new ConsignmentProductCounter();
            newForm.ShowDialog();
        }

        private void txtConQty_Leave(object sender, EventArgs e)
        {
            Calculation_Con_Qty();

        }

        private void btnQtyChangeHistory_Click(object sender, EventArgs e)
        {

            ProductDetailQty newForm = new ProductDetailQty();
            newForm.ProductId = ProductId;
            newForm.ShowDialog();

        }

        private void cboConQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Calculation_Con_Qty())
            {
                btnSubmit.Focus();
            }
            else
            {
                cboConQty.Focus();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Picture";
            dlg.Filter = "JPEGs (*.jpg;*.jpeg;*.jpe) |*.jpg;*.jpeg;*.jpe |GIFs (*.gif)|*.gif|PNGs (*.png)|*.png";

            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = dlg.FileName;
                    ptImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    ptImage.ImageLocation = txtImagePath.Text;
                    FilePath = System.IO.Path.GetFileName(dlg.FileName);

                }

            }
            catch (Exception ex)
            {
                //MessageBox.ShowMessage(Globalizer.MessageType.Warning, "You have to select Picture.\n Try again!!!");
                MessageBox.Show("You have to select Picture.\n Try again!!!");
                throw ex;
            }

        }

        public bool ThumbnailCallback()
        {
            return false;
        }


        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void chkUseReference_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseReference.Checked)
            {
                UseReference(true);
            }
            else
            {
                UseReference(false);
            }
        }

        private void UseReference(bool _ref)
        {
            lblReferenceProductName.Enabled = _ref;
            cboReferenceProductName.Enabled = _ref;
            IsReference = _ref;
        }

        private void cboReferenceProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsReference)
            {
                entity = new POSEntities();
                if (cboReferenceProductName.SelectedIndex > 0)
                {
                    int _productId = Convert.ToInt32(cboReferenceProductName.SelectedValue);
                    var _referenceData = (from pro in entity.Products where pro.Id == _productId select pro).FirstOrDefault();
                    txtName.Text = _referenceData.Name;
                    txtUnitPrice.Text = _referenceData.Price.ToString();
                    txtWholeSalePrice.Text = _referenceData.WholeSalePrice.ToString();
                    cboBrand.SelectedValue = _referenceData.BrandId;
                    if (_referenceData.ProductCategoryId != null)
                    {
                        cboMainCategory.SelectedValue = _referenceData.ProductCategoryId;
                    }

                    if (_referenceData.ProductSubCategoryId != null)
                    {
                        //cboSubCategory.SelectedValue = _referenceData.ProductSubCategoryId;
                        cboSubCategory.Text = _referenceData.ProductSubCategory.Name;
                    }
                    //else
                    //{
                    //    cboSubCategory.Text = "None";
                    //}

                    cboUnitType.Text = _referenceData.UnitType;
                    cboTaxList.SelectedValue = _referenceData.TaxId;
                    cboUnit.SelectedValue = _referenceData.UnitId;
                }
                else
                {
                    Clear_Control();
                }
            }

        }

        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)      //  Ctrl + M => Click Save
            {
                btnSubmit.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.A) //  Ctrl +A => Click Cancel
            {
                btnCancel.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.U) //  Ctrl +U=> Click Cancel
            {
                btnSubmit.PerformClick();
            }

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            //txtProductCode.Text = txtBarcode.Text.ToString();
        }

        private void cboReferenceProductName_Leave(object sender, EventArgs e)
        {
            if (IsReference)
            {
                entity = new POSEntities();
                if (cboReferenceProductName.SelectedIndex > 0)
                {
                    int _productId = Convert.ToInt32(cboReferenceProductName.SelectedValue);
                    var _referenceData = (from pro in entity.Products where pro.Id == _productId select pro).FirstOrDefault();
                    txtName.Text = _referenceData.Name;
                    txtUnitPrice.Text = _referenceData.Price.ToString();
                    txtWholeSalePrice.Text = _referenceData.WholeSalePrice.ToString();
                    cboBrand.SelectedValue = _referenceData.BrandId;
                    if (_referenceData.ProductCategoryId != null)
                    {
                        cboMainCategory.SelectedValue = _referenceData.ProductCategoryId;
                    }

                    if (_referenceData.ProductSubCategoryId != null)
                    {
                        cboSubCategory.SelectedValue = _referenceData.ProductSubCategoryId;
                    }
                    //else
                    //{
                    //    cboSubCategory.Text = "None";
                    //}

                    cboUnitType.Text = _referenceData.UnitType;
                    cboTaxList.SelectedValue = _referenceData.TaxId;
                    cboUnit.SelectedValue = _referenceData.UnitId;
                }
                else
                {
                    Clear_Control();
                }
            }
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBrand.SelectedIndex > 0)
            {
                if (!isEdit)
                {
                    if (IsStockAutoGenerate == true)
                    {
                        int _brandId = Convert.ToInt32(cboBrand.SelectedValue);
                        string _stockAutoGenerateNo = Utility.Stock_AutoGenerateNo(_brandId);

                        txtBarcode.Text = _stockAutoGenerateNo;
                        txtProductCode.Text = _stockAutoGenerateNo;
                    }
                }
            }
        }


    }
}
