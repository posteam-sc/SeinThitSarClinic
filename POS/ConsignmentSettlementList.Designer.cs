namespace POS
{
    partial class ConsignmentSettlementList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvConSettlementList = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTranDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsignmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConsignor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSettlementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSettlementAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToSaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalSettlementAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboConsignor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConSettlementList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConSettlementList
            // 
            this.dgvConSettlementList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConSettlementList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvConSettlementList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConSettlementList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.colTranDetailId,
            this.colConsignmentNo,
            this.colConsignor,
            this.colSettlementDate,
            this.colSettlementAmount,
            this.colCreatedUser,
            this.colFromSaleDate,
            this.colToSaleDate,
            this.colComment,
            this.colViewDetail,
            this.colDelete});
            this.dgvConSettlementList.Location = new System.Drawing.Point(7, 60);
            this.dgvConSettlementList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvConSettlementList.Name = "dgvConSettlementList";
            this.dgvConSettlementList.Size = new System.Drawing.Size(1208, 600);
            this.dgvConSettlementList.TabIndex = 1;
            this.dgvConSettlementList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConSettlementList_CellClick);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Id";
            this.Column6.HeaderText = "ID";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // colTranDetailId
            // 
            this.colTranDetailId.DataPropertyName = "TranDetailID";
            this.colTranDetailId.HeaderText = "TransactionDetailId";
            this.colTranDetailId.Name = "colTranDetailId";
            this.colTranDetailId.ReadOnly = true;
            this.colTranDetailId.Visible = false;
            // 
            // colConsignmentNo
            // 
            this.colConsignmentNo.DataPropertyName = "ConsignmentNo";
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.colConsignmentNo.DefaultCellStyle = dataGridViewCellStyle38;
            this.colConsignmentNo.HeaderText = "Consignment No.";
            this.colConsignmentNo.Name = "colConsignmentNo";
            this.colConsignmentNo.ReadOnly = true;
            this.colConsignmentNo.Width = 130;
            // 
            // colConsignor
            // 
            this.colConsignor.DataPropertyName = "Consignor";
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.colConsignor.DefaultCellStyle = dataGridViewCellStyle39;
            this.colConsignor.HeaderText = "Consignor";
            this.colConsignor.Name = "colConsignor";
            this.colConsignor.ReadOnly = true;
            this.colConsignor.Width = 180;
            // 
            // colSettlementDate
            // 
            this.colSettlementDate.DataPropertyName = "SettlementDate";
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle40.Format = "dd - MMM - yyyy";
            dataGridViewCellStyle40.NullValue = null;
            this.colSettlementDate.DefaultCellStyle = dataGridViewCellStyle40;
            this.colSettlementDate.HeaderText = "Settlement Date";
            this.colSettlementDate.Name = "colSettlementDate";
            this.colSettlementDate.ReadOnly = true;
            // 
            // colSettlementAmount
            // 
            this.colSettlementAmount.DataPropertyName = "SettlementAmount";
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle41.Format = "N0";
            dataGridViewCellStyle41.NullValue = null;
            this.colSettlementAmount.DefaultCellStyle = dataGridViewCellStyle41;
            this.colSettlementAmount.HeaderText = "Settlement Amount";
            this.colSettlementAmount.Name = "colSettlementAmount";
            this.colSettlementAmount.ReadOnly = true;
            this.colSettlementAmount.Width = 80;
            // 
            // colCreatedUser
            // 
            this.colCreatedUser.DataPropertyName = "CreatedUser";
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.colCreatedUser.DefaultCellStyle = dataGridViewCellStyle42;
            this.colCreatedUser.HeaderText = "Created User";
            this.colCreatedUser.Name = "colCreatedUser";
            this.colCreatedUser.ReadOnly = true;
            this.colCreatedUser.Width = 150;
            // 
            // colFromSaleDate
            // 
            this.colFromSaleDate.DataPropertyName = "FromSaleDate";
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle43.Format = "dd - MMM - yyyy";
            dataGridViewCellStyle43.NullValue = null;
            this.colFromSaleDate.DefaultCellStyle = dataGridViewCellStyle43;
            this.colFromSaleDate.HeaderText = "From Sale Date";
            this.colFromSaleDate.Name = "colFromSaleDate";
            this.colFromSaleDate.ReadOnly = true;
            // 
            // colToSaleDate
            // 
            this.colToSaleDate.DataPropertyName = "ToSaleDate";
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle44.Format = "dd - MMM - yyyy";
            this.colToSaleDate.DefaultCellStyle = dataGridViewCellStyle44;
            this.colToSaleDate.HeaderText = "To Sale Date";
            this.colToSaleDate.Name = "colToSaleDate";
            this.colToSaleDate.ReadOnly = true;
            // 
            // colComment
            // 
            this.colComment.DataPropertyName = "Comment";
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.colComment.DefaultCellStyle = dataGridViewCellStyle45;
            this.colComment.HeaderText = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.ReadOnly = true;
            this.colComment.Width = 150;
            // 
            // colViewDetail
            // 
            this.colViewDetail.HeaderText = "";
            this.colViewDetail.Name = "colViewDetail";
            this.colViewDetail.Text = "View Detail";
            this.colViewDetail.UseColumnTextForLinkValue = true;
            this.colViewDetail.VisitedLinkColor = System.Drawing.Color.Blue;
            this.colViewDetail.Width = 80;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForLinkValue = true;
            this.colDelete.Width = 80;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(138, 18);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(13, 20);
            this.lblSupplierName.TabIndex = 1;
            this.lblSupplierName.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboMonth);
            this.groupBox1.Controls.Add(this.txtTotalSettlementAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboConsignor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1198, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtTotalSettlementAmount
            // 
            this.txtTotalSettlementAmount.AutoSize = true;
            this.txtTotalSettlementAmount.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.txtTotalSettlementAmount.Location = new System.Drawing.Point(1023, 18);
            this.txtTotalSettlementAmount.Name = "txtTotalSettlementAmount";
            this.txtTotalSettlementAmount.Size = new System.Drawing.Size(151, 20);
            this.txtTotalSettlementAmount.TabIndex = 6;
            this.txtTotalSettlementAmount.Text = "Total Settlement Amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(990, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label2.Location = new System.Drawing.Point(819, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total Settlement Amount";
            // 
            // cboConsignor
            // 
            this.cboConsignor.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.cboConsignor.FormattingEnabled = true;
            this.cboConsignor.Location = new System.Drawing.Point(179, 15);
            this.cboConsignor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboConsignor.Name = "cboConsignor";
            this.cboConsignor.Size = new System.Drawing.Size(227, 28);
            this.cboConsignor.TabIndex = 1;
            this.cboConsignor.SelectedIndexChanged += new System.EventHandler(this.cboConsignor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Consignment Counter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(497, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Settlement &Month:";
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownWidth = 150;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "Janauary",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cboMonth.Location = new System.Drawing.Point(617, 16);
            this.cboMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(100, 28);
            this.cboMonth.TabIndex = 3;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // ConsignmentSettlementList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 663);
            this.Controls.Add(this.dgvConSettlementList);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsignmentSettlementList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consignment Settlement List";
            this.Load += new System.EventHandler(this.ConsignmentSettlementList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConSettlementList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConSettlementList;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboConsignor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtTotalSettlementAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTranDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsignmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConsignor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSettlementDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSettlementAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToSaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComment;
        private System.Windows.Forms.DataGridViewLinkColumn colViewDetail;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMonth;
    }
}