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

namespace POS
{
    public partial class Sales : Form
    {
        #region Variables
        string name, code = ""; int sellingPrice = 0;
        System.Windows.Forms.Control control = new System.Windows.Forms.Control();
        private POSEntities entity = new POSEntities();

        TextBox prodCode = new TextBox();

        private Boolean isDraft = false;

        private String DraftId = string.Empty;

        public EventArgs e { get; set; }

        public int CurrentCustomerId = 0;
        bool isload = false;

        public string mssg = "";

        public int? MemberTypeID = 0;

        public decimal? MCDiscountPercent = 0;

        public decimal? ItemDiscountZeroAmt = 0;
        public decimal? NonConsignProAmt = 0;
        public bool? IsWholeSale = false;
      
        public int total = 0;

        public string New = "";

        public string DiscountType = "";
        public int _rowIndex;

        int Qty = 0;

        List<Stock_Transaction> productList = new List<Stock_Transaction>();

       // public Product _productInfo=new Product();
        public int FOCQty = 1;

        List<SaleProductController> _saleProductList = new List<SaleProductController>();

        bool isAdd = false;

        #endregion

        #region Events

        public Sales()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        #region Hot keys handler
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.M)      //  Ctrl + M => Focus Member Id
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                txtMEMID.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.E)      // Ctrl + E => Focus DropDown Customer
            {
                cboProductName.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                cboCustomer.DroppedDown = true;
                if (cboCustomer.Focused != true)
                {
                    cboCustomer.Focus();
                }
            }
            else if (e.Control && e.KeyCode == Keys.N) //  Ctrl + N => Click Create New Customer
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                btnAddNewCustomer.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.A) // Ctrl + A => Focus Search Product Code Drop Down 
            {
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                cboProductName.DroppedDown = true;
                if (cboProductName.Focused != true)
                {
                    cboProductName.Focus();
                }
            }
            else if (e.Control && e.KeyCode == Keys.H) // Ctrl + H => Click Search 
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                btnSearch.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.D) // Ctrl + D => focus discount
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                txtAdditionalDiscount.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.Y) // Ctrl + Y => focus Payment Method
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = true;
                if (cboPaymentMethod.Focused != true)
                {
                    cboPaymentMethod.Focus();
                }
            }
            else if (e.Control && e.KeyCode == Keys.T) // Ctrl + T => focus delete in table
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                dgvSalesItem.CurrentCell = dgvSalesItem.Rows[0].Cells[9];
                dgvSalesItem.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.Q) // Ctrl + Q => focus Quantity in table
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                dgvSalesItem.CurrentCell = dgvSalesItem.Rows[0].Cells[3];
                dgvSalesItem.Focus();
            }
            //else if (e.Control && e.KeyCode == Keys.C)     // Ctrl + C => Click Cancel
            //{
            //    cboProductName.DroppedDown = false;
            //    cboCustomer.DroppedDown = false;
            //    cboPaymentMethod.DroppedDown = false;
            //    btnCancel.PerformClick();
            //}
            else if (e.Control && e.KeyCode == Keys.P)     // Ctrl + P => Click Paid
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                btnPaid.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.S)     // Ctrl + S => Click Save As Draft
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                btnSave.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.L)     // Ctrl + L => Click Load As Draft
            {
                cboProductName.DroppedDown = false;
                cboCustomer.DroppedDown = false;
                cboPaymentMethod.DroppedDown = false;
                btnLoadDraft.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.F)     // Ctrl + C => Click FOC
            {
                btnFOC.PerformClick();
            }
            else if (e.Control && e.KeyCode == Keys.R)       // Ctrl + E => Focus DropDown Customer type
            {
             
                if (cboCustomerType.Focused != true)
                {
                    cboCustomerType.Focus();
                }
            }
            else if (e.Control && e.KeyCode == Keys.O)       // Ctrl + E => Focus DropDown room
            {

                if (cboRoomNo.Focused != true)
                {
                    cboRoomNo.Focus();
                }
            }
            
        }
        #endregion

        private void Sales_Load(object sender, EventArgs e)
        {

            #region Setting Hot Kyes For the Controls
            SendKeys.Send("%"); SendKeys.Send("%"); // Clicking "Alt" on page load to show underline of Hot Keys
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            #endregion

            #region Disable Sort Mode of dgvSaleItem Grid
            foreach (DataGridViewColumn col in dgvSalesItem.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            #endregion

            this.cboPaymentMethod.TextChanged -= new EventHandler(cboPaymentMethod_TextChanged);
            dgvSearchProductList.AutoGenerateColumns = false;
            cboPaymentMethod.DataSource = entity.PaymentTypes.ToList();
            cboPaymentMethod.DisplayMember = "Name";
            cboPaymentMethod.ValueMember = "Id";

            Utility.BindProduct(cboProduct);
            Utility.BindCustomerType(cboCustomerType);
            Utility.BindRoom(cboRoomNo);
            cboSearchBy.SelectedIndex = 0;

            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "";
            productList.Add(productObj);
            productList.AddRange(entity.Products.ToList());
            cboProductName.DataSource = productList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Bind_Product();
            ReloadCustomerList();
            cboCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cboPaymentMethod.TextChanged += new EventHandler(cboPaymentMethod_TextChanged);
            dgvSalesItem.Focus();
            dgvSalesItem.ColumnHeadersDefaultCellStyle.Font = new Font("Zawgyi-One", 9F);
              //  , 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            dgvSalesItem.CurrentCell = dgvSalesItem[2, 0];

            cboSearchBy.SelectedIndexChanged += new EventHandler(cboSearchBy_SelectedIndexChanged);
        }

        //private void BindProductName()
        //{
        //    List<Product> productList = new List<Product>();
        //    Product productObj = new Product();
        //    productObj.Id = 0;
        //    productObj.Name = "";
        //    productList.Add(productObj);
        //    productList.AddRange(entity.Products.ToList());
        //    colProductName.DataSource = productList;
        //    colProductName.DisplayMember = "Name";
        //    colProductName.ValueMember = "Id";
        //    colProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    colProductName.AutoCompleteSource = AutoCompleteSource.ListItems;



        //    this.colProductName.DisplayMember = "ProductCodeNo";
        //    this.colProductCodeNo.ValueMember = "ProductID";
        //    this.colProductCodeNo.DataSource = productCollections;
        //    this.colProductCodeNo.DataPropertyName = "ProductID";
        //}

        //private void Bind_Product()
        //{
        //    List<Product> productList = new List<Product>();
        //    Product productObj = new Product();
        //    productObj.Id = 0;
        //    productObj.Name = "";
        //    productList.Add(productObj);
        //    productList.AddRange(entity.Products.ToList());


        //    colProductName.DataSource = productList;
        //    colProductName.DisplayMember = "Name";
        //    colProductName.ValueMember = "Id";
        //  //  colProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        //    //colProductName.AutoCompleteSource = AutoCompleteSource.ListItems;

        //    colProductName.DefaultCellStyle.NullValue = productList[0].Name;
        //}

        private void dgvSalesItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                //Delete
                if (e.ColumnIndex == 9)
                {
                    object deleteProductCode = dgvSalesItem[1, e.RowIndex].Value;

                    //If product code is null, this is just new role without product. Do not need to delete the row.
                    if (deleteProductCode != null)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {


                            if (dgvSalesItem.Rows.Count != 0)
                            {
                                if (dgvSalesItem[10, e.RowIndex].Value == null || Convert.ToInt32(dgvSalesItem[10, e.RowIndex].Value) == 0)
                                {
                                    int currentProductId = Convert.ToInt32(dgvSalesItem[10, e.RowIndex].Value);
                                    entity = new POSEntities();
                                    Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                                    if (pro.IsConsignment == false)
                                    {
                                        int unitPrice = Convert.ToInt32(dgvSalesItem[4, e.RowIndex].Value);
                                        int Qty = Convert.ToInt32(dgvSalesItem[3, e.RowIndex].Value);
                                        int Tax = Convert.ToInt32(dgvSalesItem[6, e.RowIndex].Value);
                                        decimal pricePerProduct = unitPrice * Qty;
                                        //NonConsignProAmt = pricePerProduct + ((pricePerProduct / 100) * pro.Tax.TaxPercent);

                                        NonConsignProAmt = NonConsignProAmt - (pricePerProduct + ((pricePerProduct / 100) * pro.Tax.TaxPercent));

                                    }
                                }
                            }
                            dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                            UpdateTotalCost();
                            dgvSalesItem.CurrentCell = dgvSalesItem[2, e.RowIndex];

                            //Cell_ReadOnly();
                        }
                    }
                }
                else if (e.ColumnIndex == 5)
                {

                }
                else if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    dgvSalesItem.CurrentCell = dgvSalesItem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvSalesItem.BeginEdit(true);
                }

            }
        }

        private void dgvSalesItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    int col = dgvSalesItem.CurrentCell.ColumnIndex;
                    int row = dgvSalesItem.CurrentCell.RowIndex;

                    if (col == 9)
                    {
                        object deleteProductCode = dgvSalesItem[1, row].Value;

                        //If product code is null, this is just new role without product. Do not need to delete the row.
                        if (deleteProductCode != null)
                        {

                            DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result.Equals(DialogResult.OK))
                            {
                                dgvSalesItem.Rows.RemoveAt(row);
                                UpdateTotalCost();
                                dgvSalesItem.CurrentCell = dgvSalesItem[0, row];

                            }
                        }
                    }
                    if (col == 3)
                    {
                        int currentQty = Convert.ToInt32(dgvSalesItem.Rows[row].Cells[3].Value);
                        if (currentQty == 0 || currentQty.ToString() == string.Empty)
                        {
                            //row.Cells[2].Value = "1";
                            MessageBox.Show("Please fill Quantity.");

                            dgvSalesItem.Rows[row].Cells[3].Selected = true;
                            return;
                        }
                    }

                    e.Handled = true;
                }
            }
            catch { }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (Utility.Customer_Combo_Control(cboCustomer))
            {
                return;
            }
            List<TransactionDetail> DetailList = GetTranscationListFromDataGridView();
            if (DetailList.Count() != 0)
            {
                //////for (int i = 0; i < (dgvSalesItem.Rows.Count - 1); i++)
                //////{

                //////    if (dgvSalesItem.Rows[i].Cells["Qty"].Value == null ||
                //////       dgvSalesItem.Rows[i].Cells["Qty"].Value == string.Empty || Convert.ToInt33(dgvSalesItem.Rows[i].Cells["Qty"].Value) == 0 )
                //////    {
                //////        col4 = gridx.Rows[i].Cells["many"].Value.ToString();
                //////    }
                //////}
                var FOCList=DetailList.Where(x => x.IsFOC==true).ToList();

                if (cboPaymentMethod.Text != "FOC")
                {
                    if (DetailList.Count == FOCList.Count)
                    {
                        MessageBox.Show("Can not allow to save FOC Item only!. Please choose FOC Payment Method!");
                        cboPaymentMethod.Focus();
                        return;
                    }
                }

                List<int> index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                                   where r.Cells[3].Value == null || r.Cells[3].Value.ToString() == String.Empty || r.Cells[3].Value.ToString() == "0"
                                   select r.Index).ToList();


                index.RemoveAt(index.Count - 1);

                if (index.Count > 0)
                {

                    foreach (var a in index)
                    {
                        dgvSalesItem.Rows[a].DefaultCellStyle.BackColor = Color.Red;

                    }
                    return;
                }

                if (cboCustomerType.SelectedIndex == 0 || cboCustomerType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select Customer Type!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboCustomerType.Focus();
                    return;
                }
                //else if (cboRoomNo.SelectedIndex == 0 || cboRoomNo.SelectedIndex == -1)
                //{
                //    MessageBox.Show("Please select Room No.!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cboCustomerType.Focus();
                //    return;
                //}

                else if (cboCustomer.SelectedIndex == 0 || cboCustomer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select customer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboCustomer.Focus();
                    return;
                }
                else
                {
                    //   Check_MType();        SD
                    UpdateTotalCost();
                    int? _roomId = 0;
                    if (Convert.ToInt32(cboRoomNo.SelectedValue) == 0)
                    {
                        _roomId = null;
                    }
                    else
                    {
                        _roomId = Convert.ToInt32(cboRoomNo.SelectedValue);
                    }
                   
                    //Cash
                    if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 1)
                    {
                        PaidByCash2 form = new PaidByCash2();
                        form.DetailList = DetailList;
                        int extraDiscount = 0;
                        Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                        int tax = 0;
                        Int32.TryParse(txtExtraTax.Text, out tax);
                        form.IsPrint = chkPrintSlip.Checked;
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = _roomId;
                        
                        form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                        form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                        form.isDraft = isDraft;
                        form.DraftId = DraftId;
                        form.ExtraTax = tax;
                        form.ExtraDiscount = extraDiscount;
                        form.isDebt = false;
                        form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = Convert.ToInt32(cboRoomNo.SelectedValue);
                        Get_MemberTypeID();
                        form.MemberTypeId = MemberTypeID;
                        if (Convert.ToDecimal(txtMCDiscount.Text) == 0)
                        {
                            MCDiscountPercent = 0;
                        }

                        form.MCDiscountPercent = MCDiscountPercent;
                        form.IsWholeSale = chkWholeSale.Checked;
                        if (DiscountType == "BD")
                        {
                            form.BDDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        else
                        {
                            form.MCDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        //if (cboCustomer.SelectedIndex != 0)
                        //    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                        form.ShowDialog();
                    }
                    //Credit
                    else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 2)
                    {
                        PaidByCreditWithPrePaidDebt form = new PaidByCreditWithPrePaidDebt();
                        form.DetailList = DetailList;
                        int extraDiscount = 0;
                        Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                        int tax = 0;
                        Int32.TryParse(txtExtraTax.Text, out tax);
                        form.IsPrint = chkPrintSlip.Checked;
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = _roomId;
                        form.isDraft = isDraft;
                        form.DraftId = DraftId;
                        form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                        form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                        form.ExtraTax = tax;
                        form.ExtraDiscount = extraDiscount;
                        form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                        Get_MemberTypeID();
                        form.MemberTypeId = MemberTypeID;
                        if (Convert.ToDecimal(txtMCDiscount.Text) == 0)
                        {
                            MCDiscountPercent = 0;
                        }

                        form.MCDiscountPercent = MCDiscountPercent;
                        form.IsWholeSale = chkWholeSale.Checked;
                        if (DiscountType == "BD")
                        {
                            form.BDDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        else
                        {
                            form.MCDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        //if (cboCustomer.SelectedIndex != 0)
                        //    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                        form.ShowDialog();
                    }
                    //GiftCard
                    else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 3)
                    {
                        PaidByGiftCard form = new PaidByGiftCard();
                        form.DetailList = DetailList;
                        int extraDiscount = 0;
                        Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                        int tax = 0;
                        Int32.TryParse(txtExtraTax.Text, out tax);
                        form.IsPrint = chkPrintSlip.Checked;
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = _roomId;
                        form.isDraft = isDraft;
                        form.DraftId = DraftId;
                        form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                        form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                        form.ExtraTax = tax;
                        form.ExtraDiscount = extraDiscount;
                        form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                        Get_MemberTypeID();
                        form.MemberTypeId = MemberTypeID;
                        if (Convert.ToDecimal(txtMCDiscount.Text) == 0)
                        {
                            MCDiscountPercent = 0;
                        }

                        form.MCDiscountPercent = MCDiscountPercent;
                        form.IsWholeSale = chkWholeSale.Checked;
                        if (DiscountType == "BD")
                        {
                            form.BDDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        else
                        {
                            form.MCDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        ////if (cboCustomer.SelectedIndex != 0)
                        ////    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                        form.ShowDialog();
                    }
                    else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 5)
                    {
                        PaidByMPU form = new PaidByMPU();
                        form.DetailList = DetailList;
                        int extraDiscount = 0;
                        Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                        int tax = 0;
                        Int32.TryParse(txtExtraTax.Text, out tax);
                        form.IsPrint = chkPrintSlip.Checked;
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = _roomId;
                        form.isDraft = isDraft;
                        form.DraftId = DraftId;
                        form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                        form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                        form.ExtraTax = tax;
                        form.ExtraDiscount = extraDiscount;
                        form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                        Get_MemberTypeID();
                        form.MemberTypeId = MemberTypeID;
                        if (Convert.ToDecimal(txtMCDiscount.Text) == 0)
                        {
                            MCDiscountPercent = 0;
                        }

                        form.MCDiscountPercent = MCDiscountPercent;
                        form.IsWholeSale = chkWholeSale.Checked;
                        if (DiscountType == "BD")
                        {
                            form.BDDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        else
                        {
                            form.MCDiscount = Convert.ToDecimal(txtMCDiscount.Text);
                        }
                        ////if (cboCustomer.SelectedIndex != 0)
                        ////    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                        form.ShowDialog();
                    }
                    else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 4)
                    {
                        PaidByFOC form = new PaidByFOC();
                        form.DetailList = DetailList;
                        form.Type = 4;
                        int extraDiscount = 0;
                        Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                        int tax = 0;
                        Int32.TryParse(txtExtraTax.Text, out tax);
                        form.IsPrint = chkPrintSlip.Checked;
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = _roomId;
                        form.isDraft = isDraft;
                        form.DraftId = DraftId;
                        form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                        form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                        form.ExtraTax = tax;
                        form.ExtraDiscount = extraDiscount;
                        form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                        Get_MemberTypeID();
                        form.MemberTypeId = MemberTypeID;
                        if (Convert.ToDecimal(txtMCDiscount.Text) == 0)
                        {
                            MCDiscountPercent = 0;
                        }

                        form.MCDiscountPercent = MCDiscountPercent;
                        form.BDDiscount = 0;
                        form.MCDiscount = 0;
                        form.IsWholeSale = chkWholeSale.Checked;

                        ////if (cboCustomer.SelectedIndex != 0)
                        ////    form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue.ToString());
                        form.ShowDialog();
                    }
                    else if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 6)
                    {
                        PaidByFOC form = new PaidByFOC();
                        form.DetailList = DetailList;
                        form.Type = 6;
                        int extraDiscount = 0;
                        Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);
                        int tax = 0;
                        Int32.TryParse(txtExtraTax.Text, out tax);
                        form.IsPrint = chkPrintSlip.Checked;
                        form.CustomerTypeId = Convert.ToInt32(cboCustomerType.SelectedValue);
                        form.RoomId = _roomId;
                        form.isDraft = isDraft;
                        form.DraftId = DraftId;
                        form.Discount = Convert.ToInt32(lblDiscountTotal.Text);
                        form.Tax = Convert.ToInt32(lblTaxTotal.Text);
                        form.ExtraTax = tax;
                        form.ExtraDiscount = extraDiscount;

                        form.BDDiscount = 0;
                        form.MCDiscount = 0;
                        form.CustomerId = Convert.ToInt32(cboCustomer.SelectedValue);
                        Get_MemberTypeID();
                        form.MemberTypeId = MemberTypeID;
                        if (Convert.ToDecimal(txtMCDiscount.Text) == 0)
                        {
                            MCDiscountPercent = 0;
                        }

                        form.MCDiscountPercent = MCDiscountPercent;
                        form.IsWholeSale = chkWholeSale.Checked;
                        form.ShowDialog();
                    }
                    ////New = "";
                    ////if (Save == true)
                    ////{
                    ////    DiscountType = "";
                    ////    //ItemDiscountZeroAmt = 0;
                    ////    MemberTypeID = 0;
                    ////    Save = false;
                    ////}

                }
            }
            else
            {
                MessageBox.Show("You haven't select any item to paid");
            }
        }

        private void Get_MemberTypeID()
        {
            if (MemberTypeID == 0 || MemberTypeID == null)
            {
                MemberTypeID = 0;
            }
            else
            {
                if (DiscountType == "BD")
                {
                    MCDiscountPercent = (from m in entity.MemberCardRules where m.MemberTypeId == MemberTypeID select m.BDDiscount).FirstOrDefault();
                }
                else if (DiscountType == "MC")
                {
                    MCDiscountPercent = (from m in entity.MemberCardRules where m.MemberTypeId == MemberTypeID select m.MCDiscount).FirstOrDefault();
                }

            }
        }

        private void Check_MType()
        {
            int[] FOCList = { 4, 6 };
            if (!FOCList.Contains(Convert.ToInt32(cboPaymentMethod.SelectedValue)))
            {
                Fill_Cus();
            }
            else
            {
                txtMCDiscount.Text = "0";
            }
        }

        private void btnLoadDraft_Click(object sender, EventArgs e)
        {
            if (Utility.Customer_Combo_Control(cboCustomer))
            {
                return;
            }
            DialogResult result = MessageBox.Show("This action will erase current sale data. Would you like to continue?", "Load", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                DraftList form = new DraftList();
                form.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //will only work if the grid have data row
            //datagrid count header as a row, so we have to check there is more than one row
            if (Utility.Customer_Combo_Control(cboCustomer))
            {
                return;
            }
            if (dgvSalesItem.Rows.Count > 1)
            {
                List<TransactionDetail> DetailList = GetTranscationListFromDataGridView();

                int extraDiscount = 0;
                Int32.TryParse(txtAdditionalDiscount.Text, out extraDiscount);

                int tax = 0;
                Int32.TryParse(txtExtraTax.Text, out tax);
                int cusId = Convert.ToInt32(cboCustomer.SelectedValue);
                int? customerTypeId = 0;
                int? roomId = 0;

                if (Convert.ToInt32(cboCustomerType.SelectedValue) == 0)
                {
                    customerTypeId = null;
                }
                else
                {
                    customerTypeId=Convert.ToInt32(cboCustomerType.SelectedValue);
                }
        
                if (Convert.ToInt32(cboRoomNo.SelectedValue) == 0)
                {
                    roomId = null;
                }
                else
                {
                    roomId = Convert.ToInt32(cboRoomNo.SelectedValue);
                }

                IsWholeSale = Convert.ToBoolean(chkWholeSale.Checked);
                System.Data.Objects.ObjectResult<String> Id;
                if (cusId > 0)
                {
                  //  Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, cusId);
                    Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, Convert.ToInt32(cboPaymentMethod.SelectedValue), tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, cusId, customerTypeId, roomId, IsWholeSale);
                }
                else
                {
                    //Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, 1, tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, null);
                    Id = entity.InsertDraft(DateTime.Now, MemberShip.UserId, MemberShip.CounterId, TransactionType.Sale, true, true, Convert.ToInt32(cboPaymentMethod.SelectedValue), tax, extraDiscount, DetailList.Sum(x => x.TotalAmount) + tax - extraDiscount, null, null, null, customerTypeId, roomId, IsWholeSale);
                }
                entity = new POSEntities();
                string resultId = Id.FirstOrDefault().ToString();
                Transaction insertedTransaction = (from trans in entity.Transactions where trans.Id == resultId select trans).FirstOrDefault<Transaction>();
                insertedTransaction.IsDeleted = false;

                foreach (TransactionDetail detail in DetailList)
                {
                    detail.IsDeleted = false;
                    insertedTransaction.TransactionDetails.Add(detail);
                }

                entity.SaveChanges();
                Clear();
            }
        }

        private void Sales_Activated(object sender, EventArgs e)
        {
            //DailyRecord latestRecord = (from rec in entity.DailyRecords where rec.CounterId == MemberShip.CounterId && rec.IsActive == true select rec).FirstOrDefault();
            //if (latestRecord == null)
            //{
            //    StartDay form = new StartDay();
            //    form.Show();
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string productName = cboProductName.Text.Trim();
            SearchBy();
            List<Product> pList = entity.Products.Where(x => ((name != "" && x.Name.Contains(name)) || (code != "" && x.ProductCode.Contains(code)) || (sellingPrice != 0 && x.Price == sellingPrice))).ToList();
            if (pList.Count > 0)
            {
                dgvSearchProductList.DataSource = pList;
                dgvSearchProductList.Focus();
            }
            else
            {
                MessageBox.Show("Item not found!", "Cannot find");
                dgvSearchProductList.DataSource = "";
                return;
            }
            this.AcceptButton = null;
        }

        private void dgvSearchProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currentProductId = Convert.ToInt32(dgvSearchProductList.Rows[e.RowIndex].Cells[0].Value);
                int count = dgvSalesItem.Rows.Count;
                if (e.ColumnIndex == 1)
                {
                    entity = new POSEntities();
                    Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                    if (pro != null)
                    {

                        DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                        row.Cells[0].Value = pro.Barcode;
                        row.Cells[1].Value = pro.ProductCode;
                        row.Cells[2].Value = pro.Name;
                        row.Cells[3].Value = 1;
                        //row.Cells[4].Value = pro.Price;
                        row.Cells[4].Value = Utility.WholeSalePriceOrSellingPrice(pro,chkWholeSale.Checked);
                        row.Cells[5].Value = pro.DiscountRate;
                        row.Cells[6].Value = pro.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(pro,false);
                        row.Cells[8].Value = "";
                        row.Cells[10].Value = currentProductId;
                        row.Cells[11].Value = pro.ConsignmentPrice;
                        dgvSalesItem.Rows.Add(row);
                        _rowIndex = dgvSalesItem.Rows.Count - 2;
                        cboProductName.SelectedIndex = 0;
                        dgvSearchProductList.DataSource = "";
                        dgvSearchProductList.ClearSelection();
                        dgvSalesItem.Focus();
                       // var list = dgvSalesItem.DataSource;
                        Check_ProductCode_Exist(pro.ProductCode);

                        Cell_ReadOnly();

                    }
                    else
                    {

                        MessageBox.Show("Item not found!", "Cannot find");
                    }

                    UpdateTotalCost();

                }
            }
        }

        private void dgvSearchProductList_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyData == Keys.Enter && dgvSearchProductList.CurrentCell != null) || (e.KeyData == Keys.Space && dgvSearchProductList.CurrentCell != null))
            {
                int Row = dgvSearchProductList.CurrentCell.RowIndex;
                int Column = dgvSearchProductList.CurrentCell.ColumnIndex;
                int currentProductId = Convert.ToInt32(dgvSearchProductList.Rows[Row].Cells[0].Value);
                int count = dgvSalesItem.Rows.Count;
                if (Column == 1)
                {
                    entity = new POSEntities();
                    Product pro = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
                    if (pro != null)
                    {
                        //fill the new row with the product information
                        //dgvSalesItem.Rows.Add();
                        //int newRowIndex = dgvSalesItem.NewRowIndex;

                        DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                        row.Cells[0].Value = pro.Barcode;
                        row.Cells[1].Value = pro.ProductCode;
                        row.Cells[2].Value = pro.Name;
                        row.Cells[3].Value = 1;
                       // row.Cells[4].Value = pro.Price;
                        row.Cells[4].Value = Utility.WholeSalePriceOrSellingPrice(pro, chkWholeSale.Checked);
                        row.Cells[5].Value = pro.DiscountRate;
                        row.Cells[6].Value = pro.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(pro,false);
                        row.Cells[8].Value = "";
                        row.Cells[10].Value = currentProductId;
                        row.Cells[11].Value = pro.ConsignmentPrice;
                        dgvSalesItem.Rows.Add(row);
                        cboProductName.SelectedIndex = 0;
                        dgvSearchProductList.DataSource = "";
                        dgvSearchProductList.ClearSelection();
                        dgvSalesItem.Focus();
                        //dgvSalesItem.CurrentCell = dgvSalesItem.Rows[count].Cells[0];
                        Check_ProductCode_Exist(pro.ProductCode);

                        Cell_ReadOnly();
                    }
                    else
                    {

                        MessageBox.Show("Item not found!", "Cannot find");
                    }

                    UpdateTotalCost();
                }
            }
        }

        private void cboProductName_KeyDown(object sender, KeyEventArgs e)
        {
            this.AcceptButton = btnSearch;
        }

        private void txtAdditionalDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtExtraTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Function

        private List<TransactionDetail> GetTranscationListFromDataGridView()
        {
            List<TransactionDetail> DetailList = new List<TransactionDetail>();

            foreach (DataGridViewRow row in dgvSalesItem.Rows)
            {
                if (!row.IsNewRow && row.Cells[10].Value != null && row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    TransactionDetail transDetail = new TransactionDetail();
                    bool IsFOC = false;
                    if (row.Cells[8].Value.ToString() == "FOC")
                    {
                        IsFOC = true;
                    }
                    int qty = 0, productId = 0;
                  //  bool alreadyinclude = false;
                    decimal discountRate = 0;
                    Int32.TryParse(row.Cells[10].Value.ToString(), out productId);
                    Int32.TryParse(row.Cells[3].Value.ToString(), out qty);
                    Decimal.TryParse(row.Cells[5].Value.ToString(), out discountRate);
                    ////Check if the product is already include in above row
                    //foreach (TransactionDetail td in DetailList)
                    //{
                    //    if (td.ProductId == productId && td.DiscountRate == discountRate)
                    //    {
                    //        Product tempProd = (from p in entity.Products where p.Id == productId select p).FirstOrDefault<Product>();
                    //        td.Qty = td.Qty + qty;
                    //        td.TotalAmount = Convert.ToInt64(getActualCost(tempProd, discountRate, IsFOC)) * td.Qty;
                    //        alreadyinclude = true;
                    //    }
                    //}

                    //if (!alreadyinclude)
                    //{
                        //Check productId is valid or not.
                        entity = new POSEntities();
                        Product pro = (from p in entity.Products where p.Id == productId select p).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            transDetail.ProductId = pro.Id;
                          //  transDetail.UnitPrice = pro.Price;
                            transDetail.SellingPrice = Utility.WholeSalePriceOrSellingPrice(pro, chkWholeSale.Checked);

                            FOC_Price(pro, IsFOC);
                            transDetail.UnitPrice = Utility.WholeSalePriceOrSellingPrice(pro, chkWholeSale.Checked);
                            
                            transDetail.DiscountRate = discountRate;
                            transDetail.TaxRate = Convert.ToDecimal(pro.Tax.TaxPercent);
                            transDetail.Qty = qty;
                           // transDetail.TotalAmount = Convert.ToInt64(getActualCost(pro, discountRate, IsFOC)) * qty;
                            if (Convert.ToInt32(cboPaymentMethod.SelectedValue) == 4)
                            {
                                transDetail.TotalAmount = 0;
                            }
                            else
                            {
                                transDetail.TotalAmount = Convert.ToInt64(getActualCost(pro, discountRate, IsFOC)) * qty;
                            }
                            transDetail.ConsignmentPrice = pro.ConsignmentPrice;
                            //transDetail.IsFOC = Convert.ToBoolean(row.Cells[8].Value);
                            if (row.Cells[8].Value.ToString() == "FOC")
                            {
                                transDetail.IsFOC = true;
                            }
                            else
                            {
                                transDetail.IsFOC = false;
                            }
                            
                            DetailList.Add(transDetail);
                        }
                 //   }
                }
            }

            return DetailList;
        }

        private void UpdateTotalCost()
        {
            int discount = 0, tax = 0, totalqty = 0;
            total = 0; ItemDiscountZeroAmt = 0; NonConsignProAmt = 0;
            foreach (DataGridViewRow dgrow in dgvSalesItem.Rows)
            {
                //check if the current one is new empty row
                if (!dgrow.IsNewRow && dgrow.Cells[1].Value != null && dgrow.Cells[12].Value == null )
                {
                    string rowProductCode = string.Empty;
                    int qty = 0;
                    //rowProductCode = dgrow.Cells[1].Value.ToString().Trim();
                    rowProductCode = dgrow.Cells[1].Value.ToString();
                    //Boolean IsFOC = Convert.ToBoolean(dgrow.Cells[8].Value);
                    Boolean IsFOC = false;
                    if (dgrow.Cells[8].Value == null)
                    {
                        IsFOC = false;
                    }
                    else if (dgrow.Cells[8].Value.ToString() == "FOC")
                    {
                        IsFOC = true;
                    }

                    if (rowProductCode != string.Empty && dgrow.Cells[3].Value != null)
                    {
                        //Get qty
                        Int32.TryParse(dgrow.Cells[3].Value.ToString(), out qty);
                        entity = new POSEntities();
                        Product pro = (from p in entity.Products where p.ProductCode == rowProductCode select p).FirstOrDefault<Product>();

                        decimal productDiscount = 0;
                        if (dgrow.Cells[5].Value != null)
                        {
                            Decimal.TryParse(dgrow.Cells[5].Value.ToString(), out productDiscount);
                        }
                        else
                        {
                            productDiscount = pro.DiscountRate;
                        }

                        total += (int)Math.Ceiling(getActualCost(pro, productDiscount, IsFOC) * qty);
                       // discount += (int)Math.Ceiling(getDiscountAmount(pro.Price, productDiscount) * qty);
                        discount += (int)Math.Ceiling(getDiscountAmount(Utility.WholeSalePriceOrSellingPrice(pro,chkWholeSale.Checked), productDiscount) * qty);
                        tax += (int)Math.Ceiling(getTaxAmount(pro,IsFOC) * qty);
                        totalqty += qty;

                        //get discount % 0 Unit Price
                        if (productDiscount == 0)
                        {
                          //  decimal pricePerProduct = pro.Price * qty;
                            decimal pricePerProduct = Utility.WholeSalePriceOrSellingPrice(pro,chkWholeSale.Checked) * qty;
                            ItemDiscountZeroAmt += pricePerProduct + ((pricePerProduct / 100) * pro.Tax.TaxPercent);


                        }


                        if (pro.IsConsignment == false)
                        {
                          //  decimal pricePerProduct = pro.Price * qty;
                            decimal pricePerProduct = Utility.WholeSalePriceOrSellingPrice(pro, chkWholeSale.Checked) *qty;
                            NonConsignProAmt += pricePerProduct + ((pricePerProduct / 100) * pro.Tax.TaxPercent);

                        }
                        Check_MType();
                    }

                }

            }

            if (dgvSalesItem.Rows.Count == 1)
            {
                txtMCDiscount.Text = "0";
            }

            lblTotal.Text = total.ToString();
            lblDiscountTotal.Text = discount.ToString();
            lblTaxTotal.Text = tax.ToString();
            lblTotalQty.Text = totalqty.ToString();

        }

        //private void Check_MTypeAndCalculation()
        //{
        //    ////int cId=Convert.ToInt32(cboCustomer.SelectedValue);
        //    ////var Sus = (from a in entity.Customers  where a.Id == cId select a).FirstOrDefault();
        //    ////if (Sus.Stus == null)
        //    ////{
        //    string[] focList = { "FOC", "Tester" };
        //    var mIdList = (from a in entity.PaymentTypes where !focList.Contains(a.Name) select a.Id).ToList();


        //    int paymentType = Convert.ToInt32(cboPaymentMethod.SelectedValue);

        //    if (mIdList.Contains(paymentType))
        //    {
        //        Calculate_MCDisocunt();
        //    }
        //    else
        //    {
        //        txtMCDiscount.Text = "0";
        //    }
        //}


        private void Calculate_MCDisocunt()
        {
            APP_Data.MemberCardRule data = (from a in entity.MemberCardRules where a.MemberTypeId == MemberTypeID select a).FirstOrDefault();
            decimal? _discount = 0;
            if (data != null)
            {
                int? cusId = Convert.ToInt32(cboCustomer.SelectedValue);

                string[] Birthday = { "", "-" };
                if (!Birthday.Contains(lblBirthday.Text))
                {
                    if (Convert.ToDateTime(lblBirthday.Text).Month == System.DateTime.Now.Month)
                    {
                        var bdList = (from t in entity.Transactions where t.CustomerId == cusId && t.BDDiscountAmt != 0 select t).ToList();
                        if (bdList.Count == 0)
                        {
                            _discount = data.BDDiscount;
                            DiscountType = "BD";
                        }
                        else
                        {
                            _discount = data.MCDiscount;
                            DiscountType = "MC";
                        }
                    }
                    else
                    {
                        _discount = data.MCDiscount;
                        DiscountType = "MC";
                    }
                }
                else
                {
                    _discount = data.MCDiscount;
                    DiscountType = "MC";
                }

                if (txtAdditionalDiscount.Text == "")
                {
                    txtAdditionalDiscount.Text = "0";
                }
                decimal? Dis = 0;
                // decimal? MinusDisTotal = ItemDiscountZeroAmt - Convert.ToDecimal(txtAdditionalDiscount.Text);
                decimal? MinusDisTotal = NonConsignProAmt;
                Dis = ((MinusDisTotal) / 100 * _discount);
                if (Dis > 0)
                {
                    txtMCDiscount.Text = Convert.ToInt32(Dis).ToString();
                }
                else
                {
                    txtMCDiscount.Text = "0";
                }
            }
        }

        private void Fill_Cus()
        {
            if (lblTotal.Text != "" || lblTotal.Text != "0")
            {
                int cId = Convert.ToInt32(cboCustomer.SelectedValue);
                MemberTypeID = (from c in entity.Customers where c.Id == cId select c.MemberTypeID).FirstOrDefault();
                if (txtMEMID.Text == "" || txtMEMID.Text == "-")
                {
                    if (MemberTypeID != null)
                    {
                        Calculate_MCDisocunt();
                    }
                    else
                    {
                        txtMCDiscount.Text = "0";
                    }
                }
                else
                {
                    Calculate_MCDisocunt();
                }
            }
        }

        //private void FirstTimeMember()
        //{
        //    List<MemberCardRule> mR = (from p in entity.MemberCardRules select p).ToList();
        //    var minRange = mR.Min(r => r.RangeFrom);
        //    int mTypeId = 0;
        //    string mType = "";


        //    int MinusDisTotal = total - Convert.ToInt32(txtAdditionalDiscount.Text);
        //    if (txtMEMID.Text == "")
        //    {
        //        if (MinusDisTotal >= Convert.ToInt32(minRange))
        //        {
        //            for (int i = 0; i <= mR.Count - 1; i++)
        //            {
        //                if (mR[i].RangeTo == "Above")
        //                {
        //                    //if (MinusDisTotal >= Convert.ToInt32(mR[i].RangeFrom))
        //                    //{
        //                    mR[i].RangeTo = (MinusDisTotal + 1).ToString();
        //                    //  }
        //                }
        //                if (Enumerable.Range(Convert.ToInt32(mR[i].RangeFrom), Convert.ToInt32(mR[i].RangeTo)).Contains(total))
        //                {
        //                    mTypeId = mR[i].MemberTypeId;
        //                    mType = (from p in entity.MemberTypes where p.Id == mTypeId select p.Name).FirstOrDefault();
        //                    break;
        //                }
        //            }
        //            Customer_Display(mType);
        //        }

        //    }
        //}



        private decimal getActualCost(Product prod, Boolean IsFOC)
        {
            decimal? actualCost = 0;

            //decrease discount ammount            
           // actualCost = prod.Price - ((prod.Price / 100) * prod.DiscountRate);
            FOC_Price(prod, IsFOC);

            actualCost = Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) - ((Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) / 100) * prod.DiscountRate);
            //add tax ammount            
           // actualCost = actualCost + ((prod.Price / 100) * prod.Tax.TaxPercent);
            actualCost = actualCost + ((Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) / 100) * prod.Tax.TaxPercent);

            return (decimal)actualCost;
        }

        private decimal getActualCost(Product prod, decimal discountRate,Boolean IsFOC)
        {
            decimal? actualCost = 0;
            //decrease discount ammount            
           // actualCost = prod.Price - ((prod.Price / 100) * discountRate);
            FOC_Price(prod, IsFOC);
            actualCost = Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) - ((Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) / 100) * discountRate);
            //add tax ammount            
            actualCost = actualCost + ((Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) / 100) * prod.Tax.TaxPercent);
            return (decimal)actualCost;
        }


        //private decimal getDiscountAmount(Product prod)
        //{
        //    return (((decimal)prod.Price / 100) * prod.DiscountRate);
        //}

        //private decimal getDiscountAmount(long productPrice, decimal productDiscount)
        //{
        //    return (((decimal)productPrice / 100) * productDiscount);
        //}
        private decimal getDiscountAmount(decimal productPrice, decimal productDiscount)
        {
            return (((decimal)productPrice / 100) * productDiscount);
        }

        private decimal getTaxAmount(Product prod,Boolean IsFOC)
        {
            FOC_Price(prod, IsFOC);
            return ((Utility.WholeSalePriceOrSellingPrice(prod, chkWholeSale.Checked) / 100) * Convert.ToDecimal(prod.Tax.TaxPercent));
        }

        private void FOC_Price(Product prod, Boolean IsFOC)
        {
            if (IsFOC)
            {
                prod.Price = 0;
                prod.WholeSalePrice = 0;
                prod.Tax.TaxPercent = 0;
                prod.DiscountRate = 0;
            }
        }

        public void LoadDraft(string TransactionId)
        {
            Clear();
            DraftId = TransactionId;

            entity = new POSEntities();
            Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId && ts.IsComplete == false select ts).FirstOrDefault<Transaction>();
            this.dgvSalesItem.CellValueChanged -= this.dgvSalesItem_CellValueChanged;
            if (draft != null)
            {
                var _tranDetails = (from a in entity.TransactionDetails where a.TransactionId == TransactionId select a).ToList();
                //pre add the rows
                dgvSalesItem.Rows.Insert(0, draft.TransactionDetails.Count());

                int index = 0;
                //foreach (TransactionDetail detail in draft.TransactionDetails)
                foreach (TransactionDetail detail in _tranDetails)
                {
                    //If product still exist
                    if (detail.Product != null)
                    {
                        isload = true;
                        DataGridViewRow row = dgvSalesItem.Rows[index];
                        //fill the current row with the product information
                        row.Cells[0].Value = detail.Product.Barcode;
                        row.Cells[1].Value = detail.Product.ProductCode;
                        row.Cells[2].Value = detail.Product.Name;
                        row.Cells[3].Value = detail.Qty;
                       // row.Cells[4].Value = detail.Product.Price;
                        row.Cells[4].Value = detail.UnitPrice;
                        row.Cells[5].Value = detail.DiscountRate;
                        row.Cells[6].Value = detail.Product.Tax.TaxPercent;
                        row.Cells[7].Value = getActualCost(detail.Product, detail.DiscountRate, Convert.ToBoolean(detail.IsFOC)) * detail.Qty;
                        if (Convert.ToBoolean(detail.IsFOC) == true)
                        {
                            row.Cells[8].Value = "FOC";
                        }
                        else
                        {
                            row.Cells[8].Value = "";
                        }
                        row.Cells[10].Value = detail.ProductId;
                        row.Cells[11].Value = detail.ConsignmentPrice;
                        index++;
                    }
                }
                cboPaymentMethod.SelectedValue = draft.PaymentTypeId;
                txtAdditionalDiscount.Text = draft.DiscountAmount.ToString();
                txtExtraTax.Text = draft.TaxAmount.ToString();

                cboCustomerType.SelectedValue = draft.CustomerTypeId == null ? 0 : draft.CustomerTypeId;
                cboRoomNo.SelectedValue = draft.RoomId == null ? 0 : draft.RoomId;
                  
               this.chkWholeSale.CheckedChanged -= new EventHandler(chkWholeSale_CheckedChanged);
                chkWholeSale.Checked = Convert.ToBoolean(draft.IsWholeSale);

                if (draft.Customer != null)
                {
                    SetCurrentCustomer((int)draft.CustomerId);
                }
                UpdateTotalCost();

                //** delete draft transaction **
                Transaction delete_draft = (from trans in entity.Transactions where trans.Id == DraftId select trans).FirstOrDefault<Transaction>();

                delete_draft.TransactionDetails.Clear();
                var Detail = entity.TransactionDetails.Where(d => d.TransactionId == delete_draft.Id);
                foreach (var d in Detail)
                {
                    entity.TransactionDetails.Remove(d);
                }
                entity.Transactions.Remove(delete_draft);
                entity.SaveChanges();
                   
            }
            else
            {
                //no associate transaction
                MessageBox.Show("The item doesn't exist anymore!");
            }

            isDraft = true;
            this.dgvSalesItem.CellValueChanged += this.dgvSalesItem_CellValueChanged;
            this.chkWholeSale.CheckedChanged += new EventHandler(chkWholeSale_CheckedChanged);
        }

        public void Clear()
        {
            CurrentCustomerId = 0;
            entity = new POSEntities();
            dgvSalesItem.Rows.Clear();
            dgvSalesItem.Focus();
            txtAdditionalDiscount.Text = "0";
            txtExtraTax.Text = "0";
            lblTotal.Text = "0";
            txtMCDiscount.Text = "0";
            lblTaxTotal.Text = "0";
            lblDiscountTotal.Text = "0";
            lblTotalQty.Text = "0";
            isDraft = false;
            DraftId = string.Empty;
            dgvSearchProductList.DataSource = "";
            cboProductName.SelectedIndex = 0;
            List<Product> productList = new List<Product>();
            Product productObj = new Product();
            productObj.Id = 0;
            productObj.Name = "";
            productList.Add(productObj);
            productList.AddRange((from p in entity.Products select p).ToList());
            cboProductName.DataSource = productList;
            cboProductName.DisplayMember = "Name";
            cboProductName.ValueMember = "Id";
            cboProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboProductName.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCustomer.SelectedIndex = 0;
            txtMEMID.Text = "";
            lblMemberType.Text = "";
            ItemDiscountZeroAmt = 0;
           // lblBirthday.BackColor = System.Drawing.Color.Transparent;
            ReloadCustomerList();
            cboPaymentMethod.SelectedIndex = 0;
            chkWholeSale.Checked = false;
            txtBarcode.Clear();
            Utility.BindProduct(cboProduct);
            Utility.BindCustomerType(cboCustomerType);
            Utility.BindRoom(cboRoomNo);
            _rowIndex = 0;
        }

        public void SetCurrentCustomer(Int32 CustomerId)
        {
            CurrentCustomerId = CustomerId;
            Customer currentCustomer = entity.Customers.Where(x => x.Id == CustomerId).FirstOrDefault();
            if (currentCustomer != null)
            {
                //lblCustomerName.Text = currentCustomer.Name;
                //lblNRIC.Text = currentCustomer.NRC;
                //lblPhoneNumber.Text = currentCustomer.PhoneNumber;

                if (currentCustomer.Birthday == null)
                {
                    // lblBirthday.Text = currentCustomer.Birthday.Value.ToString("dd-MMM-yyyy");
                    lblBirthday.Text = "-";
                    lblBirthday.BackColor = System.Drawing.Color.Transparent;
                }
                else
                {
                    var bod = Convert.ToDateTime(currentCustomer.Birthday).ToString("dd-MMM-yyyy");
                    lblBirthday.Text = bod.ToString();

                    if (Convert.ToDateTime(lblBirthday.Text).Month == System.DateTime.Now.Month)
                    {
                        int cusId = Convert.ToInt32(cboCustomer.SelectedValue);
                        var bdList = (from t in entity.Transactions where t.CustomerId == cusId && t.BDDiscountAmt != 0 select t).ToList();

                        if (bdList.Count == 0)
                        {
                            lblBirthday.BackColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            lblBirthday.BackColor = System.Drawing.Color.Transparent;
                        }
                    }
                    else
                    {
                        lblBirthday.BackColor = System.Drawing.Color.Transparent;
                    }
                }
                cboCustomer.Text = currentCustomer.Name;
                cboCustomer.SelectedItem = currentCustomer;
                txtMEMID.Text = currentCustomer.VIPMemberId;

                int? MTID = currentCustomer.MemberTypeID;

                if (MTID != null)
                {
                    MemberType mt = entity.MemberTypes.Where(x => x.Id == MTID).FirstOrDefault();
                    lblMemberType.Text = mt.Name;
                }
                else
                {
                    lblMemberType.Text = "-";
                }
                //*SD*
                ///// Check_MType();////
            }
        }

        public void ReloadCustomerList()
        {
            entity = new POSEntities();
            //Add Customer List with default option
            List<APP_Data.Customer> customerList = new List<APP_Data.Customer>();
            APP_Data.Customer customer = new APP_Data.Customer();
            customer.Id = 0;
            customer.Name = "None";
            customerList.Add(customer);
            customerList.AddRange(entity.Customers.ToList());
            cboCustomer.DataSource = customerList;
            cboCustomer.DisplayMember = "Name";
            cboCustomer.ValueMember = "Id";
            //if (customerList.Count > 1)

            cboCustomer.SelectedIndex = 1;
        }


        private void Cell_ReadOnly()
        {
            if (_rowIndex != -1)
            {
                DataGridViewRow row = dgvSalesItem.Rows[_rowIndex];
                if (_rowIndex > 0)
                {
                    if (row.Cells[1].Value != null)
                    {
                        string currentProductCode = row.Cells[1].Value.ToString();
                        List<string> _productList = dgvSalesItem.Rows
                               .OfType<DataGridViewRow>()
                               .Where(r => r.Cells[1].Value != null)
                               .Select(r => r.Cells[1].Value.ToString())
                               .ToList();

                        List<string> _checkProList = new List<string>();

                        _checkProList = (from p in _productList where p.Contains(currentProductCode) select p).ToList();
                        _checkProList.RemoveAt(_checkProList.Count - 1);
                        if (_checkProList.Count == 0)
                        {
                            dgvSalesItem.Rows[_rowIndex].Cells[0].ReadOnly = true;
                            dgvSalesItem.Rows[_rowIndex].Cells[1].ReadOnly = true;
                            dgvSalesItem.Rows[_rowIndex].Cells[2].ReadOnly = true;
                        }
                    }

                }
                else
                {
                    dgvSalesItem.Rows[_rowIndex].Cells[0].ReadOnly = true;
                    dgvSalesItem.Rows[_rowIndex].Cells[1].ReadOnly = true;
                    dgvSalesItem.Rows[_rowIndex].Cells[2].ReadOnly = true;
                }
            }
            else
            {
                dgvSalesItem.Rows[0].Cells[0].ReadOnly = true;
                dgvSalesItem.Rows[0].Cells[1].ReadOnly = true;
                dgvSalesItem.Rows[0].Cells[2].ReadOnly = true;
            }

            dgvSalesItem.CurrentCell = dgvSalesItem[2, dgvSalesItem.Rows.Count - 1];

        }

        private bool Check_ProductCode_Exist(string currentProductCode)
        {
            bool check = false;
            //     string currentProductCode = dgvSalesItem.Rows[_rowIndex].Cells[1].Value.ToString();
            List<int> _indexCount = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                                     where r.Cells[1].Value != null && r.Cells[1].Value.ToString() == currentProductCode
                                       && (r.Cells[8].Value.ToString() != null) && (r.Cells[8].Value.ToString() != "FOC")
                                     select r.Index).ToList();
            //  }

            if (_indexCount.Count > 1)
            {
                _indexCount.RemoveAt(_indexCount.Count - 1);

                int index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                             where r.Cells[1].Value != null && r.Cells[1].Value.ToString() == currentProductCode
                             && (r.Cells[8].Value.ToString() != "FOC")
                             select r.Index).FirstOrDefault();




                dgvSalesItem.Rows[index].Cells[3].Value = Convert.ToInt32(dgvSalesItem.Rows[index].Cells[3].Value) + 1;
                // dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count-2);
                BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count - 2); }));

                dgvSalesItem.Rows[dgvSalesItem.Rows.Count - 2].Cells[12].Value = "delete";
                check = true;

            }
            return check;
        }

        #endregion

        private void dgvSalesItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _rowIndex = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalesItem.Rows[e.RowIndex];
                dgvSalesItem.CommitEdit(new DataGridViewDataErrorContexts());
                if (row.Cells[0].Value != null || row.Cells[1].Value != null || row.Cells[2].Value != null)
                {
                    var value = row.Cells[8].Value;
                    //Boolean IsFOc = Convert.ToBoolean(row.Cells[8].Value);
                    Boolean IsFOC = false;
                    if (row.Cells[8].Value == null)
                    {
                        IsFOC = false;
                    }
                    else if ( row.Cells[8].Value.ToString() == "FOC")
                    {
                        IsFOC = true;
                    }
                    //New item code input
                    if (e.ColumnIndex == 0)
                    {
                        string currentBarcode = row.Cells[0].Value.ToString();

                        //get current product
                        //Product pro = (from p in entity.Products where p.Barcode.Contains(currentBarcode) select p).FirstOrDefault<Product>();
                        entity = new POSEntities();
                        Product pro = (from p in entity.Products where p.Barcode == currentBarcode select p).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            //fill the current row with the product information

                            isload = true;
                            row.Cells[0].Value = pro.Barcode;
                            row.Cells[1].Value = pro.ProductCode;
                            row.Cells[2].Value = pro.Name;
                            row.Cells[3].Value = 1;
                       
                          //  row.Cells[4].Value = pro.Price;
                            row.Cells[4].Value = Utility.WholeSalePriceOrSellingPrice(pro, chkWholeSale.Checked);
                            row.Cells[5].Value = pro.DiscountRate;
                            row.Cells[6].Value = pro.Tax.TaxPercent;
                            row.Cells[7].Value = getActualCost(pro, IsFOC);

                            if (IsFOC)
                            {
                                row.Cells[8].Value = "FOC";
                            }
                            else
                            {
                                row.Cells[8].Value = "";
                            }
                            row.Cells[10].Value = pro.Id;
                            row.Cells[11].Value = pro.ConsignmentPrice;


                        }
                        else
                        {
                            //remove current row if input have no associate product
                            MessageBox.Show("Wrong item code");
                            mssg = "Wrong";
                            try
                            {
                                //if (e.RowIndex > 0)
                                //{
                                //    dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                                //   // BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(e.RowIndex); }));
                                //    dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                                //}
                                //else
                                //{
                                // BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(e.RowIndex); }));
                                //dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                                // }
                            }
                            catch (Exception ex)
                            {

                            }

                        }
                    }
                    //Product Code Change
                    else if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                    {
                        string currentProductCode = "";
                        string currentProductName = "";
                        switch (e.ColumnIndex)
                        {
                            case 1:
                                currentProductCode = row.Cells[1].Value.ToString();
                                break;
                            case 2:
                                currentProductName = row.Cells[2].Value.ToString();
                                break;
                        }

                        //get current product
                        entity = new POSEntities();
                        Product pro = (from p in entity.Products where ((currentProductCode != "" && p.ProductCode == currentProductCode) || (currentProductName != "" && p.Name == currentProductName)) select p).FirstOrDefault<Product>();
                        if (pro != null)
                        {
                            //fill the current row with the product information

                            isload = true;
                            row.Cells[0].Value = pro.Barcode;
                            row.Cells[1].Value = pro.ProductCode;
                            row.Cells[2].Value = pro.Name;
                            row.Cells[3].Value = 1;
                           // row.Cells[4].Value = pro.Price;
                            row.Cells[4].Value = Utility.WholeSalePriceOrSellingPrice(pro, chkWholeSale.Checked);
                            row.Cells[5].Value = pro.DiscountRate;
                            row.Cells[6].Value = pro.Tax.TaxPercent;
                            row.Cells[7].Value = getActualCost(pro, IsFOC);
                            if (IsFOC)
                            {
                                row.Cells[8].Value = "FOC";
                            }
                            else
                            {
                                row.Cells[8].Value = "";
                            }
                            row.Cells[10].Value = pro.Id;
                            row.Cells[11].Value = pro.ConsignmentPrice;

                        }
                        else
                        {
                            //remove current row if input have no associate product
                            MessageBox.Show("Wrong item code");
                            mssg = "Wrong";
                            try
                            {
                                //if (e.RowIndex > 0)
                                //{
                                //    dgvSalesItem.Rows.RemoveAt(e.RowIndex);
                                //    dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                                //}
                            }
                            catch (Exception ex)
                            {


                            }

                        }

                        //check if current row isn't topmost
                        if (e.RowIndex > 0 && mssg == "")
                        {
                            Check_ProductCode_Exist(currentProductCode);
                        }

                    }
                    //Qty Changes
                    else if (e.ColumnIndex == 3)
                    {
                        int currentQty = 1;

                        if (isload == true)
                        {
                            string currentProductCode = row.Cells[1].Value.ToString();
                            //get current Project by Id
                            entity = new POSEntities();
                            Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();


                            //int currentQty = 1;
                            try
                            {
                                //get updated qty
                                currentQty = Convert.ToInt32(row.Cells[3].Value);

                                if (currentQty.ToString() != null && currentQty != 0)
                                {
                                    row.DefaultCellStyle.BackColor = Color.White;
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red;
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Input quantity have invalid keywords.");
                                row.Cells[3].Value = "1";
                            }


                            //update the total cost
                            row.Cells[7].Value = currentQty * getActualCost(pro, IsFOC);
                            isload = false;
                        }
                        else
                        {
                            Decimal currentDiscountRate = 0;

                            int discountRate = 0;


                            currentDiscountRate = Convert.ToDecimal(row.Cells[5].Value);
                            // if (row.Cells[5].Value.ToString() != null && row.Cells[5].Value.ToString() != "0.00")
                            try
                            {
                                if (currentDiscountRate.ToString() != null && currentDiscountRate != 0)
                                {
                                    currentDiscountRate = Convert.ToDecimal(row.Cells[5].Value.ToString());
                                    discountRate = Convert.ToInt32(currentDiscountRate);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Input Discount rate have invalid keywords.");
                                row.Cells[5].Value = "0.00";
                            }

                            string currentProductCode = row.Cells[1].Value.ToString();



                            //get current Project by Id
                            entity = new POSEntities();
                            Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();


                            currentQty = 1;
                            try
                            {
                                //get updated qty
                                currentQty = Convert.ToInt32(row.Cells[3].Value);
                                if (currentQty.ToString() != null && currentQty != 0)
                                {
                                    row.DefaultCellStyle.BackColor = Color.White;
                                }
                                else
                                {
                                    row.DefaultCellStyle.BackColor = Color.Red;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Input quantity have invalid keywords.");
                                row.Cells[3].Value = "1";
                            }

                            //update the total cost
                            //      row.Cells[7].Value = currentQty * getActualCost(pro,discountRate);
                            row.Cells[7].Value = currentQty * getActualCost(pro, discountRate, IsFOC);
                            return;
                        }

                    }

                    //Discount Rate Change
                    else if (e.ColumnIndex == 5)
                    {
                        string currentProductCode = row.Cells[1].Value.ToString();
                        //get current Project by Id
                        entity = new POSEntities();
                        Product pro = (from p in entity.Products where p.ProductCode == currentProductCode select p).FirstOrDefault<Product>();



                        int currentQty = 1;
                        try
                        {
                            //get updated qty
                            currentQty = Convert.ToInt32(row.Cells[3].Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Input quantity have invalid keywords.");
                            row.Cells[3].Value = "1";
                        }

                        decimal DiscountRate = 0;
                        try
                        {
                            //get updated qty
                            // Decimal.TryParse(row.Cells[5].Value.ToString(), out DiscountRate);
                            DiscountRate = Convert.ToDecimal(row.Cells[5].Value);
                            if (DiscountRate > 100)
                            {
                                row.Cells[5].Value = 100;
                                DiscountRate = 100;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Input Discount rate have invalid keywords.");
                            row.Cells[5].Value = "0.00";
                        }


                        //update the total cost
                        row.Cells[7].Value = currentQty * getActualCost(pro, DiscountRate, IsFOC);

                    }
                    if (mssg == "")
                    {
                        Cell_ReadOnly();
                    }

                    UpdateTotalCost();
                }
                else
                {
                    //dgvSalesItem.Rows.RemoveAt(e.RowIndex);

                    dgvSalesItem.CurrentCell = dgvSalesItem[2, e.RowIndex];
                    MessageBox.Show("You need to input product code or barcode or product name firstly in order to add product quantity!");
                    mssg = "Wrong";
                }
            }
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboCustomer.SelectedIndex != 0)
            {
                SetCurrentCustomer(Convert.ToInt32(cboCustomer.SelectedValue.ToString()));

            }
            else
            {
                //Clear customer data
                CurrentCustomerId = 0;
                //lblCustomerName.Text = "-";
                lblBirthday.Text = "-";
                //lblNRIC.Text = "-";
               // lblPhoneNumber.Text = "-";
                txtMEMID.Text = "-";
                lblMemberType.Text = "-";
            }
            UpdateTotalCost();

        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            //Role Management
            RoleManagementController controller = new RoleManagementController();
            controller.Load(MemberShip.UserRoleId);
            if (controller.Customer.Add || MemberShip.isAdmin)
            {

                NewCustomer form = new NewCustomer();
                form.isEdit = false;
                form.Type = 'C';
                form.ShowDialog();
                //  ReloadCustomerList();
            }
            else
            {
                MessageBox.Show("You are not allowed to add new customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lbAdvanceSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //CustomerSearch form = new CustomerSearch();
            //form.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        internal Boolean DeleteCopy(string TransactionId)
        {
            this.dgvSalesItem.CellValueChanged -= this.dgvSalesItem_CellValueChanged;
            Boolean IsContinue = true; Boolean IsFormClosing = true;

            //Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId select ts).FirstOrDefault<Transaction>();
            Transaction draft = (from ts in entity.Transactions where ts.Id == TransactionId select ts).FirstOrDefault();

            if (draft.Type == "Credit")
            {
                CreditTransactionList _crList = new CreditTransactionList();

                IsContinue = _crList.Update_Settlement(draft, Convert.ToDateTime(draft.DateTime));
            }

            if (IsContinue)
            {
                Clear();
                entity = new POSEntities();
                draft = (from ts in entity.Transactions where ts.Id == TransactionId select ts).FirstOrDefault();
                draft.IsDeleted = true;
                DraftId = TransactionId;
                decimal disTotal = 0, taxTotal = 0;
                //Delete transaction
                // draft.IsDeleted = true;

                chkWholeSale.Checked = Convert.ToBoolean(draft.IsWholeSale);

                //  List<TransactionDetail> tempTransactionDetaillist = entity.TransactionDetails.Where(x => x.IsDeleted == false).ToList();

                // add gift card amount
                if (draft.GiftCardId != null && draft.GiftCard != null)
                {
                    draft.GiftCard.Amount = draft.GiftCard.Amount + Convert.ToInt32(draft.GiftCardAmount);
                }

                var list = draft.TransactionDetails.Where(x => x.IsDeleted == false).ToList();
                foreach (TransactionDetail detail in draft.TransactionDetails.Where(x => x.IsDeleted == false))
                {
                    detail.IsDeleted = true;
                    detail.Product.Qty = detail.Product.Qty + detail.Qty;



                    // update Prepaid Transaction id = false   and delete list in useprepaiddebt table
                    Utility.Plus_PreaidAmt(draft);


                    //detail.Product.Qty = 100;
                    //   entity.Entry(detail).State = EntityState.Modified;
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
                                entity.SaveChanges();
                            }
                        }
                    }
                    entity.SaveChanges();
                }

                //save in stock transaction
                Save_SaleQty_ToStockTransaction(productList, Convert.ToDateTime(draft.DateTime));
                productList.Clear();

                DeleteLog dl = new DeleteLog();
                dl.DeletedDate = DateTime.Now;
                dl.CounterId = MemberShip.CounterId;
                dl.UserId = MemberShip.UserId;
                dl.IsParent = true;
                dl.TransactionId = draft.Id;

                entity.DeleteLogs.Add(dl);
                entity.SaveChanges();

                //copy transaction
                if (draft != null)
                {

                    //pre add the rows
                    // dgvSalesItem.Rows.Insert(0, draft.TransactionDetails.Count());
                    dgvSalesItem.Rows.Insert(0, list.Count());
                    int index1 = 0;
                    // foreach (TransactionDetail detail in draft.TransactionDetails)
                    foreach (TransactionDetail detail in list)
                    {
                        //If product still exist
                        if (detail.Product != null)
                        {
                            DataGridViewRow row = dgvSalesItem.Rows[index1];
                            //fill the current row with the product information
                            row.Cells[0].Value = detail.Product.Barcode;
                            row.Cells[1].Value = detail.Product.ProductCode;
                            row.Cells[2].Value = detail.Product.Name;
                            row.Cells[3].Value = detail.Qty;

                            row.Cells[4].Value = detail.UnitPrice;
                            // FOC_Price(detail.Product, detail.IsFOC);
                            // row.Cells[4].Value = Utility.WholeSalePriceOrSellingPrice(detail.Product,Convert.ToBoolean(draft.IsWholeSale));
                            row.Cells[5].Value = detail.DiscountRate;
                            row.Cells[6].Value = detail.TaxRate;
                            row.Cells[7].Value = getActualCost(Convert.ToInt64(detail.UnitPrice), detail.DiscountRate, Convert.ToDecimal(detail.TaxRate)) * detail.Qty;
                            //row.Cells[8].Value = Convert.ToBoolean(detail.IsFOC);

                            if (Convert.ToBoolean(detail.IsFOC) == true)
                            {
                                row.Cells[8].Value = "FOC";
                            }
                            else
                            {
                                row.Cells[8].Value = "";
                            }
                            disTotal += Convert.ToInt64(getDiscountAmount(Convert.ToInt64(detail.UnitPrice), detail.DiscountRate) * detail.Qty);
                            taxTotal += Convert.ToInt64(getTaxAmount(Convert.ToInt64(detail.UnitPrice), Convert.ToDecimal(detail.TaxRate)) * detail.Qty);
                            row.Cells[10].Value = detail.ProductId;
                            row.Cells[11].Value = detail.ConsignmentPrice;
                            index1++;
                        }
                    }
                    cboPaymentMethod.SelectedValue = draft.PaymentTypeId;
                    txtAdditionalDiscount.Text = (draft.DiscountAmount - disTotal).ToString();
                    txtExtraTax.Text = (draft.TaxAmount - taxTotal).ToString();

                    chkWholeSale.CheckedChanged -= new EventHandler(chkWholeSale_CheckedChanged);
                    chkWholeSale.Checked = Convert.ToBoolean(draft.IsWholeSale);


                    if (draft.Customer != null)
                    {
                        SetCurrentCustomer((int)draft.CustomerId);
                    }

                    if (draft.Type == "Credit")
                    {
                        cboPaymentMethod.Text = "Credit";
                    }
                    UpdateTotalCost();

                }
            }
            else
            {
                IsFormClosing = false;
            }
            this.dgvSalesItem.CellValueChanged += this.dgvSalesItem_CellValueChanged;
            chkWholeSale.CheckedChanged += new EventHandler(chkWholeSale_CheckedChanged);
            return IsFormClosing;
        }

        private decimal getActualCost(long productPrice, decimal productDiscount, decimal tax)
        {
            decimal? actualCost = 0;

            //decrease discount ammount            
            actualCost = productPrice - ((productPrice / 100) * productDiscount);
            //add tax ammount            
            actualCost = actualCost + ((productPrice / 100) * tax);
            return (decimal)actualCost;
        }

        private decimal getTaxAmount(long productPrice, decimal tax)
        {
            return ((productPrice / 100) * Convert.ToDecimal(tax));
        }


        private void txtMEMID_KeyDown(object sender, KeyEventArgs e)
        {
            this.AcceptButton = null;

            if (e.KeyData == Keys.Enter)
            {
                string VIPID = txtMEMID.Text;
                Customer cus = entity.Customers.Where(x => x.VIPMemberId == VIPID).FirstOrDefault();
                if (cus != null)
                {
                    SetCurrentCustomer(cus.Id);
                    UpdateTotalCost();
                }
                else
                {
                    MessageBox.Show("VIP Member ID not found!", "Cannot find");
                    //Clear customer data
                    CurrentCustomerId = 0;
                    //lblCustomerName.Text = "-";
                    lblBirthday.Text = "-";
                    //lblNRIC.Text = "-";
                  //  lblPhoneNumber.Text = "-";
                    cboCustomer.SelectedIndex = 0;
                    lblMemberType.Text = "-";
                }
            }
        }

        private void txtAdditionalDiscount_Leave(object sender, EventArgs e)
        {
            //Check_MType();//SD
            UpdateTotalCost();
        }

        private void txtAdditionalDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                // Check_MType();//SD
                UpdateTotalCost();
                SendKeys.Send("{TAB}");

            }
        }

        private void txtNO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboPaymentMethod_TextChanged(object sender, EventArgs e)
        {
            //  Check_MType();  SD
            UpdateTotalCost();
        }

        private void dgvSalesItem_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSalesItem.Rows[e.RowIndex];
                dgvSalesItem.CommitEdit(new DataGridViewDataErrorContexts());
                if (row.Cells[0].Value == null && row.Cells[1].Value == null && row.Cells[2].Value == null && row.Cells[5].Value == null && row.Cells[3].Value == null)
                {
                    if (row.Cells[9].Value != null)
                    {
                        BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(e.RowIndex); }));
                        //dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                    }
                }
                else if (mssg == "Wrong")
                {
                    if (row.Cells[9].Value != null)
                    {
                        BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(e.RowIndex); }));
                        if (row.Cells[0].Value != null)
                        {
                            dgvSalesItem.CurrentCell = dgvSalesItem[0, e.RowIndex];
                        }
                        else if (row.Cells[1].Value != null)
                        {
                            dgvSalesItem.CurrentCell = dgvSalesItem[1, e.RowIndex];
                        }
                        mssg = "";
                    }
                }
            }
        }


        #region for saving Sale Qty in Stock Transaction table
        private void Save_SaleQty_ToStockTransaction(List<Stock_Transaction> productList, DateTime _tranDate)
        {
            int _year, _month;

            _year = _tranDate.Year;
            _month = _tranDate.Month;
            Utility.Sale_Run_Process(_year, _month, productList);
        }
        #endregion

        private void dgvSalesItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dgvSalesItem_EditingControlShowing1(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(colQty_KeyPress);
            if (dgvSalesItem.CurrentCell.OwningColumn.Name.Equals("colProductName"))
            {
             
                control =e.Control;
              
                    prodCode  = e.Control as TextBox;
          
                string text=prodCode.Text;
                if (prodCode != null)
                {
                    prodCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    prodCode.AutoCompleteCustomSource = AutoCompleteLoad();
                    prodCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }
            }

            else if (dgvSalesItem.CurrentCell.OwningColumn.Name.Equals("colQty")) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    prodCode.AutoCompleteCustomSource = null;
                    tb.KeyPress += new KeyPressEventHandler(colQty_KeyPress);
                }
            }
            else if (dgvSalesItem.CurrentCell.OwningColumn.Name.Equals("colBarCode") || dgvSalesItem.CurrentCell.OwningColumn.Name.Equals("colProductCode")) //Desired Column
            {
                prodCode.AutoCompleteCustomSource = null;
            }
        }

        private void colQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       

        public AutoCompleteStringCollection AutoCompleteLoad_ByParial(string _name)
        {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();

            var product = entity.Products.Where(x => x.Name.Contains(_name)).Select(x => x.Name).ToList();

            foreach (var p in product)
            {
                str.Add(p.ToString());
            }
            return str;
        }

        public AutoCompleteStringCollection AutoCompleteLoad()
        {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            
            var product = entity.Products.Select(x => x.Name).ToList();

            foreach (var p in product)
            {
                str.Add(p.ToString());
            }
            return str;
        }

    

        private void chkWholeSale_CheckedChanged(object sender, EventArgs e)
        {
            bool chk = chkWholeSale.Checked;
            DialogResult result = new DialogResult();
            string mssg="";
            if (chk)
            {
                mssg ="Whole Sale";
            }
            else
            {
                mssg="Retail Sale";
            }
              
            if (dgvSalesItem.Rows.Count > 1)
                {
                    result = MessageBox.Show("Are you sure  want to sell with "  + mssg + "? If  Yes, the datas will be clear!", "mPOS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result.Equals(DialogResult.Yes))
                    {
                        btnCancel.PerformClick();
                    }
                }
               
        }

        private void btnFOC_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            gbFOC.Visible = true;
           // Utility.BindProduct(cboProduct);
            cboProduct.SelectedIndex = 0;
            txtBarcode.Clear();
            cboProduct.Focus();
        }

        private void Clear_FOC()
        {
            txtBarcode.Clear();
            cboProduct.SelectedIndex = 0;
            txtQty.Text = "0";
        }

        internal bool Add_DataToGrid(int currentProductId)
        {
            Product _productInfo = (from p in entity.Products where p.Id == currentProductId select p).FirstOrDefault<Product>();
            if (_productInfo != null)
               {
                   int count = dgvSalesItem.Rows.Count;
                   DataGridViewRow row = (DataGridViewRow)dgvSalesItem.Rows[count - 1].Clone();
                   row.Cells[0].Value = _productInfo.Barcode;
                   row.Cells[1].Value = _productInfo.ProductCode;
                   row.Cells[2].Value = _productInfo.Name;
                   row.Cells[3].Value = FOCQty;
                   //row.Cells[4].Value = pro.Price;
                   row.Cells[4].Value = 0;
                   row.Cells[5].Value = 0;
                   row.Cells[6].Value = 0;
                   row.Cells[7].Value = 0;
                   row.Cells[8].Value = "FOC";
                   row.Cells[10].Value = _productInfo.Id;
                   row.Cells[11].Value = _productInfo.ConsignmentPrice;
                 
                   dgvSalesItem.Rows.Add(row);
                   _rowIndex = dgvSalesItem.Rows.Count - 2;
                   //cboProductName.SelectedIndex = 0;
                   //dgvSearchProductList.DataSource = "";
                   //dgvSearchProductList.ClearSelection();
                   dgvSalesItem.Focus();
                   //var list = dgvSalesItem.DataSource;

                   Check_ProductFOCCode_Exist(_productInfo.ProductCode);

                   Cell_ReadOnly();
               }


            UpdateTotalCost();
            return true;
        }


        private bool Check_ProductFOCCode_Exist(string currentProductCode)
        {
            bool check = false;
            //     string currentProductCode = dgvSalesItem.Rows[_rowIndex].Cells[1].Value.ToString();
            List<int> _indexCount = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                                     where r.Cells[1].Value != null && r.Cells[1].Value.ToString() == currentProductCode
                                     //&& Convert.ToBoolean(r.Cells[8].Value) == true
                                     && (r.Cells[8].Value.ToString() == "FOC")
                                     select r.Index).ToList();
            //  }

            if (_indexCount.Count > 1)
            {
                _indexCount.RemoveAt(_indexCount.Count - 1);

                int index = (from r in dgvSalesItem.Rows.Cast<DataGridViewRow>()
                             where r.Cells[1].Value != null && r.Cells[1].Value.ToString() == currentProductCode
                              // && Convert.ToBoolean(r.Cells[8].Value) == true
                              && (r.Cells[8].Value.ToString() == "FOC")
                             select r.Index).FirstOrDefault();




                dgvSalesItem.Rows[index].Cells[3].Value = Convert.ToInt32(dgvSalesItem.Rows[index].Cells[3].Value) + FOCQty;
                // dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count-2);
                BeginInvoke(new Action(delegate { dgvSalesItem.Rows.RemoveAt(dgvSalesItem.Rows.Count - 2); }));

                dgvSalesItem.Rows[dgvSalesItem.Rows.Count - 2].Cells[12].Value = "delete";
                check = true;

            }
            return check;
        }

   

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            Barcode_Input();
        }

        private void Barcode_Input()
        {
            string _barcode = txtBarcode.Text;
            long productId = (from p in entity.Products where p.Barcode == _barcode && p.IsConsignment == false select p.Id).FirstOrDefault();
            cboProduct.SelectedValue = productId;
            cboProduct.Focus();
        }

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex > 0)
            {
                long productId = Convert.ToInt32(cboProduct.SelectedValue);
                string barcode = (from p in entity.Products where p.Id == productId select p.ProductCode).FirstOrDefault();
                txtBarcode.Text = barcode;
                txtQty.Text = "1";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim() != string.Empty && cboProduct.SelectedIndex > 0 &&  txtQty.Text.Trim() != string.Empty && Convert.ToInt32(txtQty.Text) > 0)
            {
                FOCQty = Convert.ToInt32(txtQty.Text);
                int _proId = Convert.ToInt32(cboProduct.SelectedValue);
                Add_DataToGrid(_proId);
                Clear_FOC();
            }
           // gbFOC.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gbFOC.Visible = false;
        }

        private void dgvSalesItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchBy.Text = "";
            SearchBy();
        }

        private void SearchBy()
        {
        
            switch (cboSearchBy.Text)
            {
                case "Code":
                    txtSearchBy.Visible = true;
                    cboProductName.Visible = false;
                    code = txtSearchBy.Text.Trim();
                    sellingPrice =0;
                    name = "";
                    break;

                case "Selling Price":
                    txtSearchBy.Visible = true;
                    cboProductName.Visible = false;
                    sellingPrice = txtSearchBy.Text=="" ? 0 : Convert.ToInt32(txtSearchBy.Text.Trim());
                    code = "";
                    name = "";
                    break;

                case "Name":
                    txtSearchBy.Visible = false;
                    cboProductName.Visible = true;
                    name = cboProductName.Text.Trim();
                    code = "";
                    sellingPrice = 0;
                    break;
            }
        }

        private void txtSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cboSearchBy.Text == "Selling Price")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
           
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((txtSearchBy.Focused) && (keyData ==  (Keys.Tab)))
            {
                btnSearch.Focus();
                return true;
            }
          
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

        }

        
    }
}
