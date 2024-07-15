namespace POS
{
    partial class TransactionDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDetailForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvTransactionDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefundQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRefundCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsFOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lblSalePerson = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRoomNo = new System.Windows.Forms.Label();
            this.tlpCredit = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblRefundAmt = new System.Windows.Forms.Label();
            this.tlpCash = new System.Windows.Forms.TableLayoutPanel();
            this.lblPrevTitle = new System.Windows.Forms.Label();
            this.lblAmountFromGiftcardTitle = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDis = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAmountFromGiftCard = new System.Windows.Forms.Label();
            this.lblRecieveAmunt = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalTax = new System.Windows.Forms.Label();
            this.lblMCDiscount = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblPaymentMethod1 = new System.Windows.Forms.Label();
            this.lblOutstandingAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionDetail)).BeginInit();
            this.tlpCredit.SuspendLayout();
            this.tlpCash.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale Person :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(648, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(647, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time :";
            // 
            // dgvTransactionDetail
            // 
            this.dgvTransactionDetail.AllowUserToAddRows = false;
            this.dgvTransactionDetail.AllowUserToResizeColumns = false;
            this.dgvTransactionDetail.AllowUserToResizeRows = false;
            this.dgvTransactionDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.colRefundQty,
            this.Column4,
            this.Column5,
            this.Column9,
            this.Column6,
            this.colRefundCost,
            this.Column8,
            this.colIsFOC,
            this.colDelete});
            this.dgvTransactionDetail.Location = new System.Drawing.Point(22, 93);
            this.dgvTransactionDetail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvTransactionDetail.Name = "dgvTransactionDetail";
            this.dgvTransactionDetail.RowHeadersVisible = false;
            this.dgvTransactionDetail.Size = new System.Drawing.Size(1047, 323);
            this.dgvTransactionDetail.TabIndex = 3;
            this.dgvTransactionDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactionDetail_CellClick);
            this.dgvTransactionDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransactionDetail_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Product Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Total Qty";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // colRefundQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRefundQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRefundQty.HeaderText = "Refund Qty";
            this.colRefundQty.Name = "colRefundQty";
            this.colRefundQty.ReadOnly = true;
            this.colRefundQty.Width = 50;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Unit Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column5
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "Discount Percent";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // Column9
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column9.HeaderText = "Tax Percent";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 90;
            // 
            // Column6
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column6.HeaderText = "Total Cost";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 90;
            // 
            // colRefundCost
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRefundCost.DefaultCellStyle = dataGridViewCellStyle8;
            this.colRefundCost.HeaderText = "Refund Cost";
            this.colRefundCost.Name = "colRefundCost";
            this.colRefundCost.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Id";
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // colIsFOC
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colIsFOC.DefaultCellStyle = dataGridViewCellStyle9;
            this.colIsFOC.HeaderText = "Remark";
            this.colIsFOC.Name = "colIsFOC";
            this.colIsFOC.ReadOnly = true;
            this.colIsFOC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsFOC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIsFOC.Width = 60;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForLinkValue = true;
            // 
            // lblSalePerson
            // 
            this.lblSalePerson.AutoSize = true;
            this.lblSalePerson.BackColor = System.Drawing.Color.Transparent;
            this.lblSalePerson.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalePerson.Location = new System.Drawing.Point(150, 14);
            this.lblSalePerson.Name = "lblSalePerson";
            this.lblSalePerson.Size = new System.Drawing.Size(13, 20);
            this.lblSalePerson.TabIndex = 6;
            this.lblSalePerson.Text = "-";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDate.Location = new System.Drawing.Point(697, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(13, 20);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "-";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTime.Location = new System.Drawing.Point(696, 46);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(13, 20);
            this.lblTime.TabIndex = 8;
            this.lblTime.Text = "-";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::POS.Properties.Resources.print_big;
            this.btnPrint.Location = new System.Drawing.Point(958, 421);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(111, 34);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Customer Name :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(43, 68);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(13, 20);
            this.lblCustomerName.TabIndex = 12;
            this.lblCustomerName.Text = "-";
            this.lblCustomerName.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::POS.Properties.Resources.update_small;
            this.btnUpdate.Location = new System.Drawing.Point(350, 45);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cboCustomer
            // 
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.Location = new System.Drawing.Point(154, 43);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(181, 28);
            this.cboCustomer.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(861, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Room No. :";
            // 
            // lblRoomNo
            // 
            this.lblRoomNo.AutoSize = true;
            this.lblRoomNo.Location = new System.Drawing.Point(954, 14);
            this.lblRoomNo.Name = "lblRoomNo";
            this.lblRoomNo.Size = new System.Drawing.Size(13, 20);
            this.lblRoomNo.TabIndex = 21;
            this.lblRoomNo.Text = "-";
            // 
            // tlpCredit
            // 
            this.tlpCredit.BackColor = System.Drawing.Color.Transparent;
            this.tlpCredit.ColumnCount = 2;
            this.tlpCredit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpCredit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCredit.Controls.Add(this.label7, 0, 0);
            this.tlpCredit.Controls.Add(this.lblRefundAmt, 1, 0);
            this.tlpCredit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpCredit.Location = new System.Drawing.Point(22, 640);
            this.tlpCredit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tlpCredit.Name = "tlpCredit";
            this.tlpCredit.RowCount = 1;
            this.tlpCredit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCredit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpCredit.Size = new System.Drawing.Size(516, 26);
            this.tlpCredit.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "Refund Amount :";
            // 
            // lblRefundAmt
            // 
            this.lblRefundAmt.AutoSize = true;
            this.lblRefundAmt.Location = new System.Drawing.Point(390, 0);
            this.lblRefundAmt.Name = "lblRefundAmt";
            this.lblRefundAmt.Size = new System.Drawing.Size(13, 20);
            this.lblRefundAmt.TabIndex = 21;
            this.lblRefundAmt.Text = "-";
            // 
            // tlpCash
            // 
            this.tlpCash.BackColor = System.Drawing.Color.Transparent;
            this.tlpCash.ColumnCount = 2;
            this.tlpCash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.60111F));
            this.tlpCash.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.39889F));
            this.tlpCash.Controls.Add(this.lblPrevTitle, 0, 8);
            this.tlpCash.Controls.Add(this.lblAmountFromGiftcardTitle, 0, 7);
            this.tlpCash.Controls.Add(this.lblR, 0, 6);
            this.tlpCash.Controls.Add(this.label8, 0, 5);
            this.tlpCash.Controls.Add(this.lblt, 0, 4);
            this.tlpCash.Controls.Add(this.label4, 0, 3);
            this.tlpCash.Controls.Add(this.label6, 0, 2);
            this.tlpCash.Controls.Add(this.lblDis, 0, 1);
            this.tlpCash.Controls.Add(this.label10, 0, 0);
            this.tlpCash.Controls.Add(this.lblAmountFromGiftCard, 1, 7);
            this.tlpCash.Controls.Add(this.lblRecieveAmunt, 1, 6);
            this.tlpCash.Controls.Add(this.lblTotal, 1, 4);
            this.tlpCash.Controls.Add(this.lblTotalTax, 1, 3);
            this.tlpCash.Controls.Add(this.lblMCDiscount, 1, 2);
            this.tlpCash.Controls.Add(this.lblDiscount, 1, 1);
            this.tlpCash.Controls.Add(this.lblPaymentMethod1, 1, 0);
            this.tlpCash.Controls.Add(this.lblOutstandingAmount, 1, 8);
            this.tlpCash.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tlpCash.Location = new System.Drawing.Point(22, 421);
            this.tlpCash.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tlpCash.Name = "tlpCash";
            this.tlpCash.RowCount = 9;
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.42236F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.04348F));
            this.tlpCash.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCash.Size = new System.Drawing.Size(722, 218);
            this.tlpCash.TabIndex = 22;
            this.tlpCash.Visible = false;
            // 
            // lblPrevTitle
            // 
            this.lblPrevTitle.AutoSize = true;
            this.lblPrevTitle.Location = new System.Drawing.Point(3, 193);
            this.lblPrevTitle.Name = "lblPrevTitle";
            this.lblPrevTitle.Size = new System.Drawing.Size(140, 20);
            this.lblPrevTitle.TabIndex = 6;
            this.lblPrevTitle.Text = "Used Prepaid Amount  :";
            // 
            // lblAmountFromGiftcardTitle
            // 
            this.lblAmountFromGiftcardTitle.AutoSize = true;
            this.lblAmountFromGiftcardTitle.Location = new System.Drawing.Point(3, 168);
            this.lblAmountFromGiftcardTitle.Name = "lblAmountFromGiftcardTitle";
            this.lblAmountFromGiftcardTitle.Size = new System.Drawing.Size(147, 20);
            this.lblAmountFromGiftcardTitle.TabIndex = 16;
            this.lblAmountFromGiftcardTitle.Text = "Amount From Giftcards  :";
            this.lblAmountFromGiftcardTitle.Visible = false;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(3, 144);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(118, 20);
            this.lblR.TabIndex = 2;
            this.lblR.Text = "Received Amount  :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(374, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "(Including Discount Amount, Member Card Discount, Tax Amount)";
            // 
            // lblt
            // 
            this.lblt.AutoSize = true;
            this.lblt.Location = new System.Drawing.Point(3, 96);
            this.lblt.Name = "lblt";
            this.lblt.Size = new System.Drawing.Size(45, 20);
            this.lblt.TabIndex = 0;
            this.lblt.Text = "Total :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tax Amount :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Member Card Discount :";
            // 
            // lblDis
            // 
            this.lblDis.AutoSize = true;
            this.lblDis.Location = new System.Drawing.Point(3, 24);
            this.lblDis.Name = "lblDis";
            this.lblDis.Size = new System.Drawing.Size(112, 20);
            this.lblDis.TabIndex = 1;
            this.lblDis.Text = "Discount Amount :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Payment Method :";
            // 
            // lblAmountFromGiftCard
            // 
            this.lblAmountFromGiftCard.AutoSize = true;
            this.lblAmountFromGiftCard.Location = new System.Drawing.Point(390, 168);
            this.lblAmountFromGiftCard.Name = "lblAmountFromGiftCard";
            this.lblAmountFromGiftCard.Size = new System.Drawing.Size(13, 20);
            this.lblAmountFromGiftCard.TabIndex = 17;
            this.lblAmountFromGiftCard.Text = "-";
            this.lblAmountFromGiftCard.Visible = false;
            // 
            // lblRecieveAmunt
            // 
            this.lblRecieveAmunt.AutoSize = true;
            this.lblRecieveAmunt.Location = new System.Drawing.Point(390, 144);
            this.lblRecieveAmunt.Name = "lblRecieveAmunt";
            this.lblRecieveAmunt.Size = new System.Drawing.Size(13, 20);
            this.lblRecieveAmunt.TabIndex = 14;
            this.lblRecieveAmunt.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(390, 96);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 20);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "-";
            // 
            // lblTotalTax
            // 
            this.lblTotalTax.AutoSize = true;
            this.lblTotalTax.Location = new System.Drawing.Point(390, 72);
            this.lblTotalTax.Name = "lblTotalTax";
            this.lblTotalTax.Size = new System.Drawing.Size(13, 20);
            this.lblTotalTax.TabIndex = 13;
            this.lblTotalTax.Text = "-";
            // 
            // lblMCDiscount
            // 
            this.lblMCDiscount.AutoSize = true;
            this.lblMCDiscount.Location = new System.Drawing.Point(390, 48);
            this.lblMCDiscount.Name = "lblMCDiscount";
            this.lblMCDiscount.Size = new System.Drawing.Size(13, 20);
            this.lblMCDiscount.TabIndex = 16;
            this.lblMCDiscount.Text = "-";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(390, 24);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(13, 20);
            this.lblDiscount.TabIndex = 4;
            this.lblDiscount.Text = "-";
            // 
            // lblPaymentMethod1
            // 
            this.lblPaymentMethod1.AutoSize = true;
            this.lblPaymentMethod1.Location = new System.Drawing.Point(390, 0);
            this.lblPaymentMethod1.Name = "lblPaymentMethod1";
            this.lblPaymentMethod1.Size = new System.Drawing.Size(13, 20);
            this.lblPaymentMethod1.TabIndex = 7;
            this.lblPaymentMethod1.Text = "-";
            // 
            // lblOutstandingAmount
            // 
            this.lblOutstandingAmount.AutoSize = true;
            this.lblOutstandingAmount.Location = new System.Drawing.Point(390, 193);
            this.lblOutstandingAmount.Name = "lblOutstandingAmount";
            this.lblOutstandingAmount.Size = new System.Drawing.Size(13, 20);
            this.lblOutstandingAmount.TabIndex = 7;
            this.lblOutstandingAmount.Text = "-";
            // 
            // TransactionDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1081, 676);
            this.Controls.Add(this.tlpCredit);
            this.Controls.Add(this.tlpCash);
            this.Controls.Add(this.lblRoomNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSalePerson);
            this.Controls.Add(this.dgvTransactionDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "TransactionDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Detail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransactionDetailForm_FormClosing);
            this.Load += new System.EventHandler(this.TransactionDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionDetail)).EndInit();
            this.tlpCredit.ResumeLayout(false);
            this.tlpCredit.PerformLayout();
            this.tlpCash.ResumeLayout(false);
            this.tlpCash.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTransactionDetail;
        private System.Windows.Forms.Label lblSalePerson;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefundQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRefundCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsFOC;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRoomNo;
        private System.Windows.Forms.TableLayoutPanel tlpCredit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblRefundAmt;
        private System.Windows.Forms.TableLayoutPanel tlpCash;
        private System.Windows.Forms.Label lblPrevTitle;
        private System.Windows.Forms.Label lblAmountFromGiftcardTitle;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAmountFromGiftCard;
        private System.Windows.Forms.Label lblRecieveAmunt;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Label lblMCDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblPaymentMethod1;
        private System.Windows.Forms.Label lblOutstandingAmount;
    }
}