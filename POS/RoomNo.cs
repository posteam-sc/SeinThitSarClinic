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
    public partial class RoomNo : Form
    {
        #region Variables

        POSEntities entity = new POSEntities();
        private ToolTip tp = new ToolTip();
        private bool isEdit = false;
        private int RoomId = 0;
        #endregion
        #region Event
        public RoomNo()
        {
            InitializeComponent();
        }

  
        private void RoomNo_Load(object sender, EventArgs e)
        {
            dgvRoomList.AutoGenerateColumns = false;
            DataBind();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            if (txtRoomNo.Text.Trim() == string.Empty)
            {
                tp.SetToolTip(txtRoomNo, "Error");
                tp.Show("Please fill up Room Number!", txtRoomNo);
                hasError = true;
            }
            if (!hasError)
            {
                APP_Data.Room roomObj1 = new APP_Data.Room();
                APP_Data.Room roomObj2 = (from r in entity.Rooms where r.RoomNo == txtRoomNo.Text select r).FirstOrDefault();
                if (roomObj2 == null)
                {
                    
                    if (!isEdit)
                    {
                       
                        roomObj1.RoomNo = txtRoomNo.Text;
                        entity.Rooms.Add(roomObj1);
                        entity.SaveChanges();
                        DataBind();
                        RoomId = roomObj1.Id;
                        MessageBox.Show("Successfully Saved!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        APP_Data.Room EditRoom = entity.Rooms.Where(x => x.Id == RoomId).FirstOrDefault();
                        EditRoom.RoomNo = txtRoomNo.Text.Trim();
                        entity.SaveChanges();

                        dgvRoomList.DataSource = (from b in entity.Rooms orderby b.Id descending select b).ToList();
                        Clear();
                        RoomId = EditRoom.Id;
                    }

                    //#region active new Room
                    if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
                    {
                        Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                        newForm.Clear();
                    }
                    //#endregion
                }
                else
                {
                    tp.SetToolTip(txtRoomNo, "Error");
                    tp.Show("This unit name is already exist!", txtRoomNo);
                }
                txtRoomNo.Text = "";
            }
        }

        #endregion

        #region Function
        private void Clear()
        {
            isEdit = false;
            this.Text = "Add New Room";
            txtRoomNo.Text = string.Empty;
            RoomId = 0;
            btnAdd.Image = Properties.Resources.add_small;
        }

        private void DataBind()
        {
            entity = new POSEntities();
            dgvRoomList.DataSource = (from r in entity.Rooms orderby r.Id descending select r).ToList();
        }

        #endregion

        private void dgvRoomList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentId;
            if (e.RowIndex >= 0)
            {
                ////Role Management
                //RoleManagementController controller = new RoleManagementController();
                //controller.Load(MemberShip.UserRoleId);
                //if (controller.MeasurementUnit.EditOrDelete || MemberShip.isAdmin)
                //{

                    //Edit
                    if (e.ColumnIndex == 2)
                    {

                        //Role Management

                        DataGridViewRow row = dgvRoomList.Rows[e.RowIndex];
                        currentId = Convert.ToInt32(row.Cells[0].Value);

                        APP_Data.Room Room= (from r in entity.Rooms where r.Id == currentId select r).FirstOrDefault();
                        txtRoomNo.Text = Room.RoomNo;
                        isEdit = true;
                        this.Text = "Edit RoomNo.";
                        RoomId = Room.Id;
                        btnAdd.Image = Properties.Resources.save_small;


                    }
                    //delete
                    if (e.ColumnIndex == 3)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            DataGridViewRow row = dgvRoomList.Rows[e.RowIndex];
                            Room roomObj = (Room)row.DataBoundItem;
                            if (roomObj.Transactions.Count == 0)
                            {
                                entity.Rooms.Remove(roomObj);
                                entity.SaveChanges();
                                DataBind();
                                MessageBox.Show("Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The Room Number is already used in transaction", "Unable to Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                //}
                //else
                //{
                //    MessageBox.Show("You are not allowed to edit/delete room numbers", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
        }

        private void RoomNo_MouseMove(object sender, MouseEventArgs e)
        {
            tp.Hide(txtRoomNo);
        }

        private void RoomNo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["Sales"] != null)
            {
                Sales newForm = (Sales)System.Windows.Forms.Application.OpenForms["Sales"];
                newForm.Clear();
            }
        }
    }
}
