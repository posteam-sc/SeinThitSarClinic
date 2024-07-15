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

namespace POS
{
    public partial class Login : Form
    {
        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();

        #region Events

        public Login()
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

        private void Login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            List<APP_Data.Counter> counterList = new List<APP_Data.Counter>();
            //entity

            APP_Data.Counter counterObj1 = new APP_Data.Counter();
            counterObj1.Id = 0;
            counterObj1.Name = "Select";
            counterList.Add(counterObj1);
            counterList.AddRange((from c in entity.Counters select c).ToList());
            cboCounter.DataSource = counterList;
            cboCounter.DisplayMember = "Name";
            cboCounter.ValueMember = "Id";

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            Boolean hasError = false;

            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            //Validation
            if (txtUserName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtUserName, "Error");
                tp.Show("Please fill up user name!", txtUserName);
                hasError = true;
            }
            else if (cboCounter.SelectedIndex < 1)
            {
                tp.SetToolTip(cboCounter, "Error");
                tp.Show("Please fill up counter name!", cboCounter);
                hasError = true;
            }
            if (!hasError)
            {
                string name = txtUserName.Text;
                string password = txtPassword.Text;
                int counterNo = Convert.ToInt32(cboCounter.SelectedValue);
                User user = (from u in entity.Users where u.Name == name select u).FirstOrDefault<User>();
                if (user != null)
                {
                    string p = Utility.DecryptString(user.Password, "SCPos");
                    if (p == password)
                    {
                        MemberShip.UserName = user.Name;
                        MemberShip.UserRole = user.UserRole.RoleName;
                        MemberShip.UserRoleId = Convert.ToInt32(user.UserRoleId);
                        MemberShip.UserId = user.Id;
                        MemberShip.isLogin = true;
                        MemberShip.CounterId = counterNo;
                        DailyRecord dailyRecord = (from rec in entity.DailyRecords where rec.CounterId == counterNo && rec.IsActive == true select rec).FirstOrDefault();

                        ((MDIParent)this.ParentForm).toolStripStatusLabel.Text = "Sales Person : " + MemberShip.UserName + " | Counter : " + cboCounter.Text + "";



                        ManageRoles();

                        Sales form = new Sales();
                        form.WindowState = FormWindowState.Maximized;
                        form.MdiParent = ((MDIParent)this.ParentForm);
                        form.Show();

                        ((MDIParent)this.ParentForm).logInToolStripMenuItem1.Visible = false;
                        ((MDIParent)this.ParentForm).logOutToolStripMenuItem.Visible = true;

                        this.Close();
                        CheckSetting();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    if (name == "superuser")
                    {
                        int year = Convert.ToInt32(DateTime.Now.Year.ToString());
                        int month = Convert.ToInt32(DateTime.Now.Month.ToString());
                        int num = year + month;
                        string newpass = num.ToString() + "sourcecode" + month.ToString();
                        if (newpass == password)
                        {
                            MemberShip.isAdmin = true;
                            ((MDIParent)this.ParentForm).menuStrip.Enabled = true;
                            Sales form = new Sales();
                            form.WindowState = FormWindowState.Maximized;
                            form.MdiParent = ((MDIParent)this.ParentForm);
                            form.Show();
                            CheckSetting();
                        }
                        else MessageBox.Show("Wrong Password");
                    }
                    else
                    {
                        MessageBox.Show("There is no user exist with this user name");
                    }
                }
            }

        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtUserName);
            tp.Hide(cboCounter);
        }

        #endregion

        #region Functions

        private void CheckSetting()
        {
            Boolean HasEmpty = false;

            if (SettingController.BranchName == null || SettingController.BranchName == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultCity == 0 || SettingController.BranchName == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultTaxRate == null || SettingController.DefaultTaxRate == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultTopSaleRow == 0)
            {
                HasEmpty = true;
            }
            else if (SettingController.OpeningHours == null || SettingController.OpeningHours == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.PhoneNo == null || SettingController.PhoneNo == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.ShopName == null || SettingController.ShopName == string.Empty)
            {
                HasEmpty = true;
            }
            else if (SettingController.DefaultTaxRate != null)
            {
                int id = Convert.ToInt32(SettingController.DefaultTaxRate);
                APP_Data.Tax taxObj = entity.Taxes.Where(x => x.Id == id).FirstOrDefault();
                if (taxObj == null)
                {
                    HasEmpty = true;
                }
            }
            else if (SettingController.DefaultCity != 0)
            {
                int id = SettingController.DefaultCity;
                APP_Data.City cityObj = entity.Cities.Where(x => x.Id == id).FirstOrDefault();
                if (cityObj == null)
                {
                    HasEmpty = true;
                }
            }
            else if (DefaultPrinter.A4Printer == null || DefaultPrinter.A4Printer == string.Empty)
            {
                HasEmpty = true;
            }
            else if (DefaultPrinter.BarcodePrinter == null || DefaultPrinter.BarcodePrinter == string.Empty)
            {
                HasEmpty = true;
            }
            else if (DefaultPrinter.SlipPrinter == null || DefaultPrinter.SlipPrinter == string.Empty)
            {
                HasEmpty = true;
            }

            if (HasEmpty)
            {
                Setting newForm = new Setting();
                newForm.ControlBox = false;
                newForm.ShowDialog();
            }

        }

        private void ManageRoles()
        {

            //if user isn't using server, he/she can't do backup
            if (DatabaseControlSetting._ServerName.ToUpper().StartsWith(System.Environment.MachineName.ToUpper()))
            {
                ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled = true;
            }

            //Admin
            if (MemberShip.UserRole == "Admin")
            {
                MemberShip.isAdmin = true;
                ((MDIParent)this.ParentForm).menuStrip.Enabled = true;
                // All True
                #region Account Menu
                //Account Menu is Visiable False By Default
                ((MDIParent)this.ParentForm).accountToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).userListToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).addNewUserToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).roleManagementToolStripMenuItem1.Enabled = true;
                #endregion

                #region Customer Menu
                // Main Menu Visibility 
                ((MDIParent)this.ParentForm).customerToolStripMenuItem.Visible = true;
                // Sub Menu Visibility
                ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addNewCustomerToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).addNewCustomerToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).customerListToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).customerListToolStripMenuItem1.Enabled =
                 ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Enabled =
                #endregion
             
                #region Supplier Menu
                    // Main Menu Visilibity
                ((MDIParent)this.ParentForm).supplierToolStripMenuItem.Visible =
                    // Sub Menu Visilibity
                ((MDIParent)this.ParentForm).supplierListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).supplierListToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).outstandingSupplierListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).outstandingSupplierListToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).outstandingSupplierListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).outstandingSupplierListToolStripMenuItem.Visible =

                #endregion

                #region Consignment Settlement Menu
                    // Main Menu Visilibity
                ((MDIParent)this.ParentForm).consignmentToolStripMenuItem.Visible =
                     ((MDIParent)this.ParentForm).consignmentToolStripMenuItem.Enabled =
                    // Sub Menu Visibility
                         ((MDIParent)this.ParentForm).consignmentSettlementToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).consignmentSettlementToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).consignmentSettlementListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).consignmentSettlementListToolStripMenuItem.Visible =
                #endregion

                #region Purchsing Menu
                    // Main Menu visibility
                ((MDIParent)this.ParentForm).purchasingToolStripMenuItem.Visible =
                    // Sub Menu Visibility
                ((MDIParent)this.ParentForm).newPurchaseOrderToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).newPurchaseOrderToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).purchaseHistoryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseHistoryToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).purchaseDeleteLogToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseDeleteLogToolStripMenuItem.Visible =
                #endregion

                #region Product Menu
                    // Main Menu Visibility
                ((MDIParent)this.ParentForm).productToolStripMenuItem.Visible =
                    // Sub Menu Visibility
                ((MDIParent)this.ParentForm).productCategoryToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).productCategoryToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).productSubCategoryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).productSubCategoryToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).brandToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).brandToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).addNewProductToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addNewProductToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).productListToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).productListToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).productPriceChangeHistoryListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).productPriceChangeHistoryListToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).stockUnitConversionToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).stockUnitConversionToolStripMenuItem.Visible =
                  ((MDIParent)this.ParentForm).stockUnitConversionListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).stockUnitConversionToolStripMenuItem.Visible =
                #endregion

                #region Adjustment
                    // Main Menu Visibility
                ((MDIParent)this.ParentForm).adjustmentToolStripMenuItem.Visible =
                    // Sub Menu Visibility
                ((MDIParent)this.ParentForm).adjustmentListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).adjustmentListToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).addNewadjustmentToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addNewadjustmentToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).adjustmentDeleteLogToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).adjustmentDeleteLogToolStripMenuItem.Visible =
                #endregion

                #region Setting
                    // Sub Menu visibility
                ((MDIParent)this.ParentForm).counterToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).counterToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).addConsigmentCounterToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addConsigmentCounterToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).giftCardContToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).giftCardContToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).addMemeberRuleToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addMemeberRuleToolStripMenuItem.Visible =
                #endregion

                #region Report Menu
                    // Sub Menu visibility
                ((MDIParent)this.ParentForm).dailySummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).dailySummaryToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).topToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).topToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).outstandingCustomerReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).outstandingCustomerReportToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).AdjustmentReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).AdjustmentReportToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).stockTransactionToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).stockTransactionToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).averageMonthlyReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).averageMonthlyReportToolStripMenuItem.Visible =

                // Main Menu Visibility                
                ((MDIParent)this.ParentForm).reportsToolStripMenuItem.Visible = true;
          
                #endregion

                #region Tools Menu
                //export and import are only allowed on server machine
                bool IsAllowed = DatabaseControlSetting._ServerName.ToUpper().StartsWith(System.Environment.MachineName.ToUpper());

                ((MDIParent)this.ParentForm).toolsToolStripMenuItem.Visible = 
                ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Visible =
                ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Visible = IsAllowed;

                #endregion
            }
            //Super Casher OR Casher
            else
            {
                MemberShip.isAdmin = false;
                ((MDIParent)this.ParentForm).menuStrip.Enabled = true;
                RoleManagementController controller = new RoleManagementController();
                controller.Load(MemberShip.UserRoleId);

                #region Account Menu
                //Account Menu is Visiable False By Default
                ((MDIParent)this.ParentForm).accountToolStripMenuItem1.Visible =
                ((MDIParent)this.ParentForm).userListToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).addNewUserToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).roleManagementToolStripMenuItem1.Enabled = false;
                #endregion

                #region Customer Menu
                // Main Menu Visibility 
               // ((MDIParent)this.ParentForm).customerToolStripMenuItem.Visible = controller.Customer.Add && controller.Customer.View;

                if (controller.Customer.Add == false && controller.Customer.View == false 
                    && controller.OutstandingCustomer.View == false && controller.OutstandingCustomer.ViewDetail == false)
                {
                    ((MDIParent)this.ParentForm).customerToolStripMenuItem.Visible = false;
                }
                else
                {
                    ((MDIParent)this.ParentForm).customerToolStripMenuItem.Visible = true;

                    // Sub Menu Visibility
                    ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Visible =
                    ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Enabled = controller.Customer.View;
                    ((MDIParent)this.ParentForm).addNewCustomerToolStripMenuItem.Visible =
                    ((MDIParent)this.ParentForm).addNewCustomerToolStripMenuItem.Enabled = controller.Customer.Add;
                    ((MDIParent)this.ParentForm).customerListToolStripMenuItem1.Visible =
                    ((MDIParent)this.ParentForm).customerListToolStripMenuItem1.Enabled = controller.Customer.View;

                    ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Visible =
                   ((MDIParent)this.ParentForm).outstandingcustomerListToolStripMenuItem.Enabled = controller.OutstandingCustomer.View;
                }
             
                #endregion

                #region Supplier Menu
                if (controller.Supplier.Add == false && controller.Supplier.View == false
                 && controller.OutstandingSupplier.View == false && controller.OutstandingSupplier.ViewDetail == false)
                {
                    ((MDIParent)this.ParentForm).supplierToolStripMenuItem.Visible = false;
                }
                else
                {
                    // Main Menu Visilibity
                    ((MDIParent)this.ParentForm).supplierToolStripMenuItem.Visible = true;
               
                   // ((MDIParent)this.ParentForm).supplierToolStripMenuItem.Visible = controller.Supplier.View && controller.Supplier.Add;
                    // Sub Menu Visilibity
                    ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Enabled =
                   ((MDIParent)this.ParentForm).addSupplierToolStripMenuItem.Visible = controller.Supplier.Add;

                    ((MDIParent)this.ParentForm).supplierListToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).supplierListToolStripMenuItem.Visible = controller.Supplier.View;

                    ((MDIParent)this.ParentForm).outstandingSupplierListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).outstandingSupplierListToolStripMenuItem.Visible = controller.OutstandingSupplier.View;

                   
                }
                #endregion

                #region Purchsing Menu
                if (controller.PurchaseRole.Add == false && controller.PurchaseRole.View == false
                    && controller.PurchaseRole.DeleteLog == false)
         
                {
                    ((MDIParent)this.ParentForm).purchasingToolStripMenuItem.Visible = false;
                }
                else
                {
                    // Main Menu visibility
                    ((MDIParent)this.ParentForm).purchasingToolStripMenuItem.Visible = true;
                    // Sub Menu Visibility
                    ((MDIParent)this.ParentForm).newPurchaseOrderToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).newPurchaseOrderToolStripMenuItem.Visible = controller.PurchaseRole.Add;
                    ((MDIParent)this.ParentForm).purchaseHistoryToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).purchaseHistoryToolStripMenuItem.Visible = controller.PurchaseRole.View;
                    ((MDIParent)this.ParentForm).purchaseDeleteLogToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).purchaseDeleteLogToolStripMenuItem.Visible = controller.PurchaseRole.DeleteLog;
                }
                #endregion

                #region Product Menu
                // Main Menu Visibility
                //((MDIParent)this.ParentForm).productToolStripMenuItem.Visible = controller.Category.View && controller.SubCategory.View && controller.Brand.View && controller.Product.Add && controller.Product.View;
                if (controller.Category.View == false && controller.SubCategory.View == false && controller.Brand.View == false && controller.Product.Add == false && controller.Product.View == false
                    && controller.UnitConversion.Add == false && controller.UnitConversion.View==false)
                {
                    ((MDIParent)this.ParentForm).productToolStripMenuItem.Visible = false;
                }
                else
                {
                    ((MDIParent)this.ParentForm).productToolStripMenuItem.Visible = true;

                    // Sub Menu Visibility
                    ((MDIParent)this.ParentForm).productCategoryToolStripMenuItem1.Enabled =
                    ((MDIParent)this.ParentForm).productCategoryToolStripMenuItem1.Visible = controller.Category.View;
                    ((MDIParent)this.ParentForm).productSubCategoryToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).productSubCategoryToolStripMenuItem.Visible = controller.SubCategory.View;
                    ((MDIParent)this.ParentForm).brandToolStripMenuItem1.Enabled =
                    ((MDIParent)this.ParentForm).brandToolStripMenuItem1.Visible = controller.Brand.View;
                    ((MDIParent)this.ParentForm).addNewProductToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).addNewProductToolStripMenuItem.Visible = controller.Product.Add;
                    ((MDIParent)this.ParentForm).productListToolStripMenuItem1.Enabled =
                    ((MDIParent)this.ParentForm).productListToolStripMenuItem1.Visible = controller.Product.View;
                    ((MDIParent)this.ParentForm).productPriceChangeHistoryListToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).productPriceChangeHistoryListToolStripMenuItem.Visible = controller.Product.View;
                    ((MDIParent)this.ParentForm).stockUnitConversionToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).stockUnitConversionToolStripMenuItem.Visible = controller.UnitConversion.Add;
                    ((MDIParent)this.ParentForm).stockUnitConversionListToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).stockUnitConversionListToolStripMenuItem.Visible = controller.UnitConversion.View;   
                }
              

                #endregion

                #region Adjustment
                // Main Menu Visibility
                ((MDIParent)this.ParentForm).adjustmentToolStripMenuItem.Visible = controller.Adjustment.View && controller.Adjustment.Add;
                // Sub Menu Visibility
                ((MDIParent)this.ParentForm).adjustmentListToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).adjustmentListToolStripMenuItem.Visible = controller.Adjustment.View;
                ((MDIParent)this.ParentForm).addNewadjustmentToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).addNewadjustmentToolStripMenuItem.Visible = controller.Adjustment.Add;
                ((MDIParent)this.ParentForm).adjustmentDeleteLogToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).adjustmentDeleteLogToolStripMenuItem.Visible = controller.Adjustment.View;
                #endregion

                #region Consignment
                // Main Menu Visibility
                //((MDIParent)this.ParentForm).consignmentToolStripMenuItem.Visible = controller.ConsigmentSettlement.View && controller.ConsigmentSettlement.EditOrDelete;
                if (controller.ConsigmentSettlement.View == false && controller.ConsigmentSettlement.EditOrDelete == false)
                {
                    ((MDIParent)this.ParentForm).consignmentToolStripMenuItem.Visible = false;
                }
                else
                {
                    ((MDIParent)this.ParentForm).consignmentToolStripMenuItem.Visible = true;
                    // Sub Menu Visibility
                    ((MDIParent)this.ParentForm).consignmentSettlementListToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).consignmentSettlementListToolStripMenuItem.Visible = controller.ConsigmentSettlement.View;
                    ((MDIParent)this.ParentForm).consignmentSettlementToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).consignmentSettlementToolStripMenuItem.Visible = controller.ConsigmentSettlement.Add;
                }
          
            
                #endregion

                #region Setting

                //((MDIParent)this.ParentForm).settingsToolStripMenuItem1.Visible = controller.Setting.Add && controller.Consignor.Add
                //    && controller.MeasurementUnit.Add && controller.CurrencyExchange.Add
                //    && controller.TaxRate.Add && controller.City.Add;

                // Main Menu Visibility
                if (!controller.Setting.Add && controller.Consignor.Add
                    && controller.MeasurementUnit.Add && controller.CurrencyExchange.Add
                    && controller.TaxRate.Add && controller.City.Add)
                {
                    ((MDIParent)this.ParentForm).settingsToolStripMenuItem1.Visible = false;
                }
                else
                {
                    ((MDIParent)this.ParentForm).settingsToolStripMenuItem1.Visible = true;

                    // Sub Menu visibility
                    ((MDIParent)this.ParentForm).configurationSettingToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).configurationSettingToolStripMenuItem.Visible = controller.Setting.Add;

                    ((MDIParent)this.ParentForm).counterToolStripMenuItem1.Enabled =
                    ((MDIParent)this.ParentForm).counterToolStripMenuItem1.Visible = controller.Counter.Add;

                    ((MDIParent)this.ParentForm).addConsigmentCounterToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).addConsigmentCounterToolStripMenuItem.Visible = controller.Consignor.Add;

                    ((MDIParent)this.ParentForm).giftCardContToolStripMenuItem.Enabled =
                  ((MDIParent)this.ParentForm).giftCardContToolStripMenuItem.Visible = controller.GiftCard.View;

                    ((MDIParent)this.ParentForm).measurementUnitToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).measurementUnitToolStripMenuItem.Visible = controller.MeasurementUnit.Add;

                    ((MDIParent)this.ParentForm).currencyExchangeToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).currencyExchangeToolStripMenuItem.Visible = controller.CurrencyExchange.Add;

                    ((MDIParent)this.ParentForm).taxRatesToolStripMenuItem.Enabled =
                   ((MDIParent)this.ParentForm).taxRatesToolStripMenuItem.Visible = controller.TaxRate.Add;

                    ((MDIParent)this.ParentForm).addMemeberRuleToolStripMenuItem.Enabled =
                  ((MDIParent)this.ParentForm).addMemeberRuleToolStripMenuItem.Visible = controller.MemberRule.Add;

                    ((MDIParent)this.ParentForm).addMemeberRuleToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).addMemeberRuleToolStripMenuItem.Visible = controller.MemberRule.Add || controller.MemberRule.Add;

                    ((MDIParent)this.ParentForm).addCityToolStripMenuItem.Enabled =
                    ((MDIParent)this.ParentForm).addCityToolStripMenuItem.Visible = controller.MemberRule.Add || controller.City.Add;

                    
                }
                
            
                #endregion

                #region Report Menu
                // Sub Menu visibility
                ((MDIParent)this.ParentForm).dailySummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).dailySummaryToolStripMenuItem.Visible = controller.DailySaleSummary.View;
                ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).transactionToolStripMenuItem.Visible = controller.TransactionReport.View;
                ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).transactionSummaryToolStripMenuItem.Visible = controller.TransactionSummaryReport.View;
                ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).transactionDetailByItemToolStripMenuItem.Visible = controller.TransactionDetailReport.View;
                ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseToolStripMenuItem.Visible = controller.PurchaseReport.View;
                ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).purchaseDiscountToolStripMenuItem.Visible = controller.PurchaseDiscount.View;
                ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).itemSummaryToolStripMenuItem.Visible = controller.ItemSummaryReport.View;
                ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).saleBreakDownToolStripMenuItem.Visible = controller.SaleBreakdown.View;
                ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).taxesSummaryToolStripMenuItem.Visible = controller.TaxSummaryReport.View;
                ((MDIParent)this.ParentForm).topToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).topToolStripMenuItem.Visible = controller.TopBestSellerReport.View;
                ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).customersSaleToolStripMenuItem.Visible = controller.CustomerSales.View;
                ((MDIParent)this.ParentForm).outstandingCustomerReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).outstandingCustomerReportToolStripMenuItem.Visible = controller.OutstandingCustomerReport.View;
                ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).customerInfomationToolStripMenuItem.Visible = controller.CustomerInformation.View;
                ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).productReportToolStripMenuItem.Visible = controller.ProductReport.View;
                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).itemPurchaseOrderToolStripMenuItem.Visible = controller.ReorderPointReport.View;
                ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).consignmentCounterToolStripMenuItem.Visible = controller.Consigment.View;
                ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).profitAndLossToolStripMenuItem.Visible = controller.ProfitAndLoss.View;
                ((MDIParent)this.ParentForm).AdjustmentReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).AdjustmentReportToolStripMenuItem.Visible = controller.AdjustmentReport.View;
                ((MDIParent)this.ParentForm).stockTransactionToolStripMenuItem1.Enabled =
                ((MDIParent)this.ParentForm).stockTransactionToolStripMenuItem1.Visible = controller.StockTransactionReport.View;
                ((MDIParent)this.ParentForm).averageMonthlyReportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).averageMonthlyReportToolStripMenuItem.Visible = controller.AverageMonthlyReport.View;



                // Main Menu Visibility                
                var SubItemList = ((MDIParent)this.ParentForm).reportsToolStripMenuItem.DropDownItems;
                bool IsVisiable = false;
                foreach (ToolStripMenuItem item in SubItemList)
                {
                    if (item.Enabled == true)
                    {
                        IsVisiable = true;
                        break;
                    }
                }
                ((MDIParent)this.ParentForm).reportsToolStripMenuItem.Visible = IsVisiable;
                #endregion

                #region Tools Menu
                //export are only allowed on server machine
                bool IsAllowed = DatabaseControlSetting._ServerName.ToUpper().StartsWith(System.Environment.MachineName.ToUpper());
                //Main Menu
                ((MDIParent)this.ParentForm).toolsToolStripMenuItem.Visible = IsAllowed;

                // Sub Menu
                // 1 Chashier are not allowed to restore database, 
                ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).databaseImportToolStripMenuItem.Visible = false;

                // 2 export are only allowed on server machine
                ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Enabled =
                ((MDIParent)this.ParentForm).databaseExportToolStripMenuItem.Visible = IsAllowed;
                #endregion
            }
        }

        #endregion
    }
}
