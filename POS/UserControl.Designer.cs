﻿namespace POS
{
    partial class UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl));
            this.btnAddSalesPerson = new System.Windows.Forms.Button();
            this.dgvSalesPersonList = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesPersonList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddSalesPerson
            // 
            this.btnAddSalesPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddSalesPerson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnAddSalesPerson.FlatAppearance.BorderSize = 0;
            this.btnAddSalesPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnAddSalesPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnAddSalesPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSalesPerson.Image = global::POS.Properties.Resources.adduser;
            this.btnAddSalesPerson.Location = new System.Drawing.Point(51, 12);
            this.btnAddSalesPerson.Name = "btnAddSalesPerson";
            this.btnAddSalesPerson.Size = new System.Drawing.Size(162, 52);
            this.btnAddSalesPerson.TabIndex = 0;
            this.btnAddSalesPerson.UseVisualStyleBackColor = false;
            this.btnAddSalesPerson.Click += new System.EventHandler(this.btnAddSalesPerson_Click);
            // 
            // dgvSalesPersonList
            // 
            this.dgvSalesPersonList.AllowUserToAddRows = false;
            this.dgvSalesPersonList.AllowUserToResizeColumns = false;
            this.dgvSalesPersonList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvSalesPersonList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesPersonList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvSalesPersonList.Location = new System.Drawing.Point(51, 80);
            this.dgvSalesPersonList.Name = "dgvSalesPersonList";
            this.dgvSalesPersonList.Size = new System.Drawing.Size(788, 540);
            this.dgvSalesPersonList.TabIndex = 1;
            this.dgvSalesPersonList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesPersonList_CellClick);
            this.dgvSalesPersonList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSalesPersonList_DataBindingComplete);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Id";
            this.Column6.HeaderText = "ID";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "User Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "User Role";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DateTime";
            this.Column2.HeaderText = "Created Since";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.Text = "Edit";
            this.Column3.UseColumnTextForLinkValue = true;
            this.Column3.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Text = "Delete";
            this.Column4.UseColumnTextForLinkValue = true;
            this.Column4.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(901, 632);
            this.Controls.Add(this.dgvSalesPersonList);
            this.Controls.Add(this.btnAddSalesPerson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User List";
            this.Activated += new System.EventHandler(this.UserControl_Activated);
            this.Load += new System.EventHandler(this.UserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesPersonList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddSalesPerson;
        private System.Windows.Forms.DataGridView dgvSalesPersonList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.DataGridViewLinkColumn Column4;
    }
}