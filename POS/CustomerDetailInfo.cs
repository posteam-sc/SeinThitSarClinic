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
    public partial class CustomerDetailInfo : Form
    {
        #region Variables
            POSEntities entity = new POSEntities();
            public int customerId;
        #endregion

        #region Event
        public CustomerDetailInfo()
        {
            InitializeComponent();
        }

        private void CustomerDetailInfo_Load(object sender, EventArgs e)
        {
            Customer cust = (from c in entity.Customers where c.Id == customerId select c).FirstOrDefault<Customer>();

            lblName.Text = cust.Title + " " + cust.Name;

            lblMCId.Text = cust.VIPMemberId != null ? cust.VIPMemberId : "-";


            lblMType.Text = (from m in entity.MemberTypes where m.Id == cust.MemberTypeID select m.Name).FirstOrDefault();

            if (lblMType.Text == null || lblMType.Text == "")
            {
                lblMType.Text = "-";
            }

            lblPhoneNumber.Text = cust.PhoneNumber != "" ? cust.PhoneNumber : "-";

            lblNrc.Text = cust.NRC != "" ? cust.NRC : "-";

            lblAddress.Text = cust.Address != "" ? cust.Address : "-";

            lblEmail.Text = cust.Email != "" ? cust.Email : "-";

            lblGender.Text = cust.Gender != "" ? cust.Gender : "-";

            lblBirthday.Text = cust.Birthday != null ? Convert.ToDateTime(cust.Birthday).ToString("dd-MM-yyyy") : "-";
            lblCity.Text = cust.City != null ? cust.City.CityName : "-";
            dgvNormalTransaction.AutoGenerateColumns = false;
            List<Transaction> transList = cust.Transactions.Where(trans => (trans.IsDeleted == false || trans.IsDeleted == null) && (trans.IsComplete==true)).ToList();           
            dgvNormalTransaction.DataSource = transList;          

        }

        private void dgvNormalTransaction_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvNormalTransaction.Rows)
            {
                Transaction ts = (Transaction)row.DataBoundItem;
                row.Cells[0].Value = ts.Id;               
                row.Cells[1].Value = ts.DateTime.Value.Date.ToString("dd-MM-yyyy");
                //row.Cells[2].Value = ts.DateTime.Value.TimeOfDay.Hours.ToString() + ts.DateTime.Value.TimeOfDay.Minutes.ToString();
                row.Cells[2].Value = ts.DateTime.Value.TimeOfDay.Hours.ToString() +":"+ ts.DateTime.Value.TimeOfDay.Minutes.ToString()+":" + ts.DateTime.Value.Second.ToString();
                row.Cells[3].Value = ts.PaymentType.Name;
                row.Cells[4].Value = ts.TotalAmount;   
                row.Cells[5].Value = ts.Type;
                row.Cells[6].Value = ts.User.Name;
            }
        }
         #endregion

        private void dgvNormalTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string currentTransactionId = dgvNormalTransaction.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (e.ColumnIndex == 7)
                {
                    TransactionDetailForm newForm = new TransactionDetailForm();
                    newForm.transactionId = currentTransactionId;
                    newForm.ShowDialog();
                }
            }
        }

        
    }
}
