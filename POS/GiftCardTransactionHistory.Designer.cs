namespace POS
{
    partial class GiftCardTransactionHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvGiftTransactionList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalGiftCardAmt = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiftCardAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCashAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViewDetail = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiftTransactionList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGiftTransactionList
            // 
            this.dgvGiftTransactionList.AllowUserToAddRows = false;
            this.dgvGiftTransactionList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiftTransactionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvGiftTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiftTransactionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column10,
            this.colDate,
            this.colTime,
            this.Column4,
            this.Column5,
            this.colGiftCardAmount,
            this.colCashAmount,
            this.colViewDetail});
            this.dgvGiftTransactionList.Location = new System.Drawing.Point(2, 6);
            this.dgvGiftTransactionList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvGiftTransactionList.Name = "dgvGiftTransactionList";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiftTransactionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgvGiftTransactionList.RowHeadersVisible = false;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGiftTransactionList.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvGiftTransactionList.Size = new System.Drawing.Size(983, 562);
            this.dgvGiftTransactionList.TabIndex = 1;
            this.dgvGiftTransactionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiftTransactionList_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Gift Card Amount :";
            // 
            // lblTotalGiftCardAmt
            // 
            this.lblTotalGiftCardAmt.AutoSize = true;
            this.lblTotalGiftCardAmt.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGiftCardAmt.Location = new System.Drawing.Point(162, 581);
            this.lblTotalGiftCardAmt.Name = "lblTotalGiftCardAmt";
            this.lblTotalGiftCardAmt.Size = new System.Drawing.Size(13, 20);
            this.lblTotalGiftCardAmt.TabIndex = 3;
            this.lblTotalGiftCardAmt.Text = "-";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TransactionId";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column1.HeaderText = "TransactionId";
            this.Column1.Name = "Column1";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Type";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column9.HeaderText = "Type";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "PaymentMethod";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column10.HeaderText = "Payment Method";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "Date";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle17;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 80;
            // 
            // colTime
            // 
            this.colTime.DataPropertyName = "Time";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colTime.DefaultCellStyle = dataGridViewCellStyle18;
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SalePerson";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column4.HeaderText = "Sale Person";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column5.HeaderText = "Total Amount";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 90;
            // 
            // colGiftCardAmount
            // 
            this.colGiftCardAmount.DataPropertyName = "GiftCardAmount";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "N0";
            dataGridViewCellStyle21.NullValue = null;
            this.colGiftCardAmount.DefaultCellStyle = dataGridViewCellStyle21;
            this.colGiftCardAmount.HeaderText = "Gift Card Amount";
            this.colGiftCardAmount.Name = "colGiftCardAmount";
            this.colGiftCardAmount.ReadOnly = true;
            this.colGiftCardAmount.Width = 90;
            // 
            // colCashAmount
            // 
            this.colCashAmount.DataPropertyName = "CashAmount";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colCashAmount.DefaultCellStyle = dataGridViewCellStyle22;
            this.colCashAmount.HeaderText = "Cash Amount";
            this.colCashAmount.Name = "colCashAmount";
            // 
            // colViewDetail
            // 
            this.colViewDetail.HeaderText = "";
            this.colViewDetail.Name = "colViewDetail";
            this.colViewDetail.Text = "View Detail";
            this.colViewDetail.UseColumnTextForLinkValue = true;
            // 
            // GiftCardTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 612);
            this.Controls.Add(this.lblTotalGiftCardAmt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGiftTransactionList);
            this.Name = "GiftCardTransactionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Card Transaction Hisotry";
            this.Load += new System.EventHandler(this.GiftCardTransactionHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiftTransactionList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGiftTransactionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalGiftCardAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiftCardAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCashAmount;
        private System.Windows.Forms.DataGridViewLinkColumn colViewDetail;
    }
}