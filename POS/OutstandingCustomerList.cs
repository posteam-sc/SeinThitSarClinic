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
    public partial class OutstandingCustomerList : Form
    {
        private POSEntities entity = new POSEntities();
        List<CustomerInfoHolder> customerInfoHolderList = new List<CustomerInfoHolder>(); 

        public OutstandingCustomerList()
        {
            InitializeComponent();
            dgvCustomerList.AutoGenerateColumns = false;
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
                form.ShowDialog();
            } 
            else
            {
                MessageBox.Show("You are not allowed to add new customer", "Access Denied",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);                
            }
        }

        private void CustomerList_Resize(object sender, EventArgs e)
        { 
            int height =  this.Height;
            int width = this.Width;

            dgvCustomerList.Height = this.Height - 250;
            dgvCustomerList.Width = this.Width - 100;
            dgvCustomerList.Top = ((this.Height / 10) + 50);
            
            btnAddNewCustomer.Width = this.Width / 5;
            btnAddNewCustomer.Height = this.Height / 10;
        }

        private void OutstandingCustomerList_Load(object sender, EventArgs e)
        {
            Utility.BindCustomer(cboCustomerName);
        }       

        private void dgvCustomerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                CustomerInfoHolder cInfo = (CustomerInfoHolder)row.DataBoundItem;

                row.Cells[0].Value = cInfo.Id.ToString();
                row.Cells[1].Value = cInfo.Name.ToString();
                row.Cells[2].Value = cInfo.PhNo.ToString();
                row.Cells[3].Value = cInfo.PayableAmount;
                row.Cells[4].Value = cInfo.RefundAmount;
            }
     
        }

        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Delete
                if (e.ColumnIndex == 7)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Customer.EditOrDelete || MemberShip.isAdmin)
                    {

                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];
                            Customer cust = (Customer)row.DataBoundItem;
                            cust = (from c in entity.Customers where c.Id == cust.Id select c).FirstOrDefault<Customer>();

                            //Need to recheck
                            if (cust.Transactions.Count > 0)
                            {
                                MessageBox.Show("This customer has outstanding amount!", "Unable to Delete");
                                return;
                            }
                            else
                            {
                                entity.Customers.Remove(cust);
                                entity.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //Edit
                else if (e.ColumnIndex == 6)
                {
                    //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.Customer.EditOrDelete || MemberShip.isAdmin)
                    {
                        NewCustomer form = new NewCustomer();
                        form.isEdit = true;
                        form.Text = "Edit Customer";
                        form.CustomerId = Convert.ToInt32(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to edit customer", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                //View Detail
                else if (e.ColumnIndex == 5)
                {
                     //Role Management
                    RoleManagementController controller = new RoleManagementController();
                    controller.Load(MemberShip.UserRoleId);
                    if (controller.OutstandingCustomer.ViewDetail|| MemberShip.isAdmin)
                    {
                    //Show Customer Detail Form
                    CustomerDetail form = new CustomerDetail();
                    form.customerId = Convert.ToInt32(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    form.TotalOutstanding = Convert.ToInt64(dgvCustomerList.Rows[e.RowIndex].Cells[3].Value);
                    form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to view outstanding customer detail", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void DataBind(int customerId, DateTime fromDate, DateTime toDate) {
          
            List<Customer> customerList = new List<Customer>();
            entity = new POSEntities();
            customerInfoHolderList.Clear();

            if (customerId != 0) { 
            customerList = (from c in entity.Customers
                            join t in entity.Transactions on c.Id equals t.CustomerId
                            where (t.Type == "Credit" || t.Type == "CreditRefund" || t.Type == "Prepaid")
                            && c.Id == customerId
                            && (t.DateTime >= fromDate && t.DateTime <= toDate)
                            select c).Distinct().ToList();
            }else{
                customerList = (from c in entity.Customers
                                join t in entity.Transactions on c.Id equals t.CustomerId
                                where (t.Type == "Credit" || t.Type == "CreditRefund" || t.Type == "Prepaid")
                                && (t.DateTime >= fromDate && t.DateTime <= toDate)
                                select c).Distinct().ToList();
                }
            if (customerList.Count > 0) {
                this.progressBar1.Visible = true;
                // Set Minimum to 1 to represent the first file being copied.
                progressBar1.Minimum = 1;
                // Set Maximum to the total number of Users created.
                progressBar1.Maximum = customerList.Count;
                // Set the initial value of the ProgressBar.
                progressBar1.Value = 1;
                // Set the Step property to a value of 1 to represent each user is being created.
                progressBar1.Step = 1;

                foreach (Customer c in customerList) {
                    int totalDebt = 0, totalPrepaid = 0; long totalRefund = 0;
                    CustomerInfoHolder crObj = new CustomerInfoHolder();

                    crObj.Id = c.Id;
                    crObj.Name = c.Name;
                    crObj.PhNo = c.PhoneNumber;

                    List<Transaction> rtList = new List<Transaction>();

                    foreach (Transaction tf in c.Transactions) {
                        if (tf.IsPaid == false && tf.IsDeleted == false) {
                            totalDebt += (int)((tf.TotalAmount) - tf.RecieveAmount);
                            rtList = (from rt in entity.Transactions where rt.Type == TransactionType.CreditRefund && rt.ParentId == tf.Id select rt).ToList();

                            if (rtList.Count > 0) {
                                foreach (Transaction rt in rtList) {
                                    totalDebt -= (int)rt.RecieveAmount;
                                    }
                                }

                            totalDebt -= Convert.ToInt32(tf.UsePrePaidDebts.Sum(x => x.UseAmount).Value);
                            }
                        if (tf.Type == TransactionType.Prepaid && tf.IsActive == false && tf.IsDeleted == false) {
                            totalPrepaid += (int)tf.RecieveAmount;
                            int useAmount = 0;
                            if (tf.UsePrePaidDebts1 != null) {
                                foreach (UsePrePaidDebt useObj in tf.UsePrePaidDebts1) {
                                    useAmount += (int)useObj.UseAmount;
                                    }
                                }
                            totalPrepaid -= useAmount;
                            }
                        else if (tf.Type == TransactionType.CreditRefund && tf.IsDeleted == false) {

                            totalRefund += (long)tf.RecieveAmount;
                            }
                        }
                    totalDebt -= totalPrepaid;
                    int _payablAmt = 0;
                    var PrepaidList = c.Transactions.Where(tras => tras.Type == TransactionType.Prepaid).Where(trans => trans.IsActive == false).ToList();
                    _payablAmt = Convert.ToInt32(PrepaidList.AsEnumerable().Sum(s => s.TotalAmount));
                    if (totalDebt > 0) {
                        crObj.PayableAmount = totalDebt - _payablAmt;
                        crObj.RefundAmount = totalRefund;
                        customerInfoHolderList.Add(crObj);
                        }
                    // Perform the increment on the ProgressBar.
                    this.progressBar1.PerformStep();
                    }//end of customer list looping.
                dgvCustomerList.DataSource = null;
                dgvCustomerList.DataSource = customerInfoHolderList;
                }            
            else MessageBox.Show("There is no data to show!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
        private void btnPreview_Click(object sender, EventArgs e) {
            int customerId = 0;
            if (cboCustomerName.SelectedIndex != 0) {
                customerId = Convert.ToInt32(cboCustomerName.SelectedValue);
                }
            DataBind(customerId,Convert.ToDateTime( dtpfromDate.Value.ToShortDateString()),Convert.ToDateTime( dtpToDate.Value.ToShortDateString()));
            }

        private void btnReset_Click(object sender, EventArgs e) {
            dtpToDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
            this.cboCustomerName.SelectedIndex = 0;
            dgvCustomerList.DataSource = null;
            this.progressBar1.Visible = false;
            }
        }
}
