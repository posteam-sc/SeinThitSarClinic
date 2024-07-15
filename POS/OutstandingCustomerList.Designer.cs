namespace POS
{
    partial class OutstandingCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutstandingCustomerList));
            this.dgvCustomerList = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpfromDate = new System.Windows.Forms.DateTimePicker();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblsName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomerList
            // 
            this.dgvCustomerList.AllowUserToAddRows = false;
            this.dgvCustomerList.AllowUserToResizeColumns = false;
            this.dgvCustomerList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCustomerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column8,
            this.Column3});
            this.dgvCustomerList.Location = new System.Drawing.Point(3, 220);
            this.dgvCustomerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCustomerList.Name = "dgvCustomerList";
            this.dgvCustomerList.Size = new System.Drawing.Size(782, 450);
            this.dgvCustomerList.TabIndex = 2;
            this.dgvCustomerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerList_CellClick);
            this.dgvCustomerList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomerList_DataBindingComplete);
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
            this.Column1.HeaderText = "Customer Name";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PhoneNumber";
            this.Column2.HeaderText = "Phone Number";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Payable Amount";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Refund Amount";
            this.Column8.Name = "Column8";
            this.Column8.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.Text = "Outstanding List";
            this.Column3.UseColumnTextForLinkValue = true;
            this.Column3.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnAddNewCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddNewCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnAddNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnAddNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewCustomer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewCustomer.Image = global::POS.Properties.Resources.addnewcustomer;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(436, 11);
            this.btnAddNewCustomer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(171, 52);
            this.btnAddNewCustomer.TabIndex = 1;
            this.btnAddNewCustomer.UseVisualStyleBackColor = false;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.btnAddNewCustomer);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpfromDate);
            this.groupBox1.Controls.Add(this.cboCustomerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblsName);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(149, 185);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(268, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(252, 138);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 32);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(149, 138);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(85, 32);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(149, 94);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(268, 25);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpfromDate
            // 
            this.dtpfromDate.Location = new System.Drawing.Point(149, 63);
            this.dtpfromDate.Name = "dtpfromDate";
            this.dtpfromDate.Size = new System.Drawing.Size(268, 25);
            this.dtpfromDate.TabIndex = 3;
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(149, 20);
            this.cboCustomerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(268, 26);
            this.cboCustomerName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Date:";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(105, 20);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(12, 18);
            this.lblSupplierName.TabIndex = 1;
            this.lblSupplierName.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date:";
            // 
            // lblsName
            // 
            this.lblsName.AutoSize = true;
            this.lblsName.Location = new System.Drawing.Point(4, 20);
            this.lblsName.Name = "lblsName";
            this.lblsName.Size = new System.Drawing.Size(91, 18);
            this.lblsName.TabIndex = 0;
            this.lblsName.Text = "Customer Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Status bar:";
            // 
            // OutstandingCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(788, 675);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCustomerList);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OutstandingCustomerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outstanding Customer List";
            this.Load += new System.EventHandler(this.OutstandingCustomerList_Load);
            this.Resize += new System.EventHandler(this.CustomerList_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomerList;
        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewLinkColumn Column3;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DateTimePicker dtpfromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        }
}