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
    public partial class City : Form
    {
        #region Variable

        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        int cityId = 0;
        private bool isEdit = false;
        private int CityId = 0;
        #endregion

        public City()
        {
            InitializeComponent();
        }

        private void City_Load(object sender, EventArgs e)
        {
            dgvCityList.AutoGenerateColumns = false;
            dgvCityList.DataSource = entity.Cities.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            bool HaveError = false;
            if (txtName.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtName, "Error");
                tp.Show("Please fill up brand name!", txtName);
                HaveError = true;
            }
            if (!HaveError)
            {
                string CityName = txtName.Text.Trim();
                APP_Data.City CityObj = new APP_Data.City();
                APP_Data.City alredyCityObj = entity.Cities.Where(x => x.CityName.Trim() == CityName).FirstOrDefault();
                if (alredyCityObj == null)
                {

                    if (!isEdit)
                    {
                        dgvCityList.DataSource = "";
                        CityObj.CityName = txtName.Text;
                        entity.Cities.Add(CityObj);
                        entity.SaveChanges();
                        dgvCityList.DataSource = entity.Cities.ToList();
                        cityId = CityObj.Id;
                        MessageBox.Show("Successfully Saved!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Back_CityData_ToCallForm();
                    }
                    else
                    {
                        APP_Data.City EditCity = entity.Cities.Where(x => x.Id == CityId).FirstOrDefault();
                        EditCity.CityName = txtName.Text.Trim();
                        entity.SaveChanges();

                        dgvCityList.DataSource = (from b in entity.Cities orderby b.Id descending select b).ToList();

                        cityId = EditCity.Id;
                        Back_CityData_ToCallForm();
                    }
                    Clear();
                }
                else
                {
                    tp.SetToolTip(txtName, "Error");
                    tp.Show("This city name is already exist!", txtName);
                }
            }
        }

        private void dgvCityList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentId;
            if (e.RowIndex >= 0)
            {
                //Role Management
                RoleManagementController controller = new RoleManagementController();
                controller.Load(MemberShip.UserRoleId);
                if (controller.City.EditOrDelete || MemberShip.isAdmin)
                {
                    //Edit
                    if (e.ColumnIndex == 2)
                    {

                        //Role Management

                        DataGridViewRow row = dgvCityList.Rows[e.RowIndex];
                        currentId = Convert.ToInt32(row.Cells[0].Value);

                        APP_Data.City City = (from b in entity.Cities where b.Id == currentId select b).FirstOrDefault();
                        txtName.Text = City.CityName;
                        isEdit = true;
                        this.Text = "Edit City";
                        CityId = City.Id;
                        btnAdd.Image = Properties.Resources.save_small;


                    }
                    //Delete
                    if (e.ColumnIndex == 3)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvCityList.Rows[e.RowIndex];
                            currentId = Convert.ToInt32(row.Cells[0].Value);
                            int count = (from Cus in entity.Customers where Cus.CityId == currentId select Cus).ToList().Count;
                            if (count < 1)
                            {
                                dgvCityList.DataSource = "";
                                APP_Data.City city = (from c in entity.Cities where c.Id == currentId select c).FirstOrDefault();
                                entity.Cities.Remove(city);
                                entity.SaveChanges();
                                dgvCityList.DataSource = entity.Cities.ToList();

                                cityId = 0;
                                MessageBox.Show("Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtName.Text = "Select";

                                Back_CityData_ToCallForm();
                            }
                            else
                            {
                                //To show message box 
                                MessageBox.Show("This city name is currently in use!", "Enable to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You are not allowed to edit/delete city.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        #region Method
        private void Back_CityData_ToCallForm()
        {
            #region active setting and customer
            if (System.Windows.Forms.Application.OpenForms["Setting"] != null)
            {
                Setting newForm = (Setting)System.Windows.Forms.Application.OpenForms["Setting"];
                newForm.ReLoadCity();
                newForm.SetCurrentCity(cityId);
            }
            cityId = 0;

            if (System.Windows.Forms.Application.OpenForms["NewCustomer"] != null)
            {
                NewCustomer newForm = (NewCustomer)System.Windows.Forms.Application.OpenForms["NewCustomer"];
                newForm.reloadCity(txtName.Text);
            }
            txtName.Text = "";
            this.Close();
            #endregion
        }

        private void Clear()
        {
            isEdit = false;
            this.Text = "Add New City";
            txtName.Text = string.Empty;
            CityId = 0;
            btnAdd.Image = Properties.Resources.add_small;
        }
        #endregion
    }
}
