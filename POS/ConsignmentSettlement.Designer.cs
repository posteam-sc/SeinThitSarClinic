﻿namespace POS
{
    partial class ConsignmentSettlement
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboConsignor = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvConsingmentPaid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalConsignPaidAmt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPaidCash = new System.Windows.Forms.Button();
            this.txtTotalProfitAmt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsingmentPaid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label3.Location = new System.Drawing.Point(8, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Consignment Counter";
            // 
            // cboConsignor
            // 
            this.cboConsignor.FormattingEnabled = true;
            this.cboConsignor.Location = new System.Drawing.Point(162, 28);
            this.cboConsignor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboConsignor.Name = "cboConsignor";
            this.cboConsignor.Size = new System.Drawing.Size(227, 28);
            this.cboConsignor.TabIndex = 1;
            this.cboConsignor.SelectedIndexChanged += new System.EventHandler(this.cboCounter_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.groupBox2.Location = new System.Drawing.Point(422, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(428, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transaction Period :";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd - MMM - yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(290, 29);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(126, 27);
            this.dtpTo.TabIndex = 3;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "&To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd - MMM - yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(83, 29);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(126, 27);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "&From";
            // 
            // dgvConsingmentPaid
            // 
            this.dgvConsingmentPaid.AllowUserToAddRows = false;
            this.dgvConsingmentPaid.AllowUserToDeleteRows = false;
            this.dgvConsingmentPaid.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsingmentPaid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConsingmentPaid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsingmentPaid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colProductId,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvConsingmentPaid.Location = new System.Drawing.Point(12, 99);
            this.dgvConsingmentPaid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvConsingmentPaid.Name = "dgvConsingmentPaid";
            this.dgvConsingmentPaid.Size = new System.Drawing.Size(838, 407);
            this.dgvConsingmentPaid.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Item Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 250;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ConsignQty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Qty";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Selling Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ConsignmentPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle5.Format = "N0";
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Consignment Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TotalConsignmentPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle6.Format = "N0";
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.HeaderText = "Total Consignment Price";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TotalProfit";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle7.Format = "N0";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column6.HeaderText = "Total Profit Price";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(24, 637);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(271, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Total Consignment Settlement Amount :";
            // 
            // txtTotalConsignPaidAmt
            // 
            this.txtTotalConsignPaidAmt.AutoSize = true;
            this.txtTotalConsignPaidAmt.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalConsignPaidAmt.Location = new System.Drawing.Point(295, 637);
            this.txtTotalConsignPaidAmt.Name = "txtTotalConsignPaidAmt";
            this.txtTotalConsignPaidAmt.Size = new System.Drawing.Size(17, 20);
            this.txtTotalConsignPaidAmt.TabIndex = 8;
            this.txtTotalConsignPaidAmt.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboConsignor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Counter:";
            // 
            // btnPaidCash
            // 
            this.btnPaidCash.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPaidCash.FlatAppearance.BorderSize = 0;
            this.btnPaidCash.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPaidCash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPaidCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaidCash.ForeColor = System.Drawing.Color.Transparent;
            this.btnPaidCash.Image = global::POS.Properties.Resources.paid_big2;
            this.btnPaidCash.Location = new System.Drawing.Point(714, 612);
            this.btnPaidCash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPaidCash.Name = "btnPaidCash";
            this.btnPaidCash.Size = new System.Drawing.Size(136, 40);
            this.btnPaidCash.TabIndex = 9;
            this.btnPaidCash.UseVisualStyleBackColor = true;
            this.btnPaidCash.Click += new System.EventHandler(this.btnPaidCash_Click);
            // 
            // txtTotalProfitAmt
            // 
            this.txtTotalProfitAmt.AutoSize = true;
            this.txtTotalProfitAmt.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalProfitAmt.Location = new System.Drawing.Point(295, 609);
            this.txtTotalProfitAmt.Name = "txtTotalProfitAmt";
            this.txtTotalProfitAmt.Size = new System.Drawing.Size(17, 20);
            this.txtTotalProfitAmt.TabIndex = 6;
            this.txtTotalProfitAmt.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(24, 609);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Profit Amount     :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label4.Location = new System.Drawing.Point(24, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Co&mment   :";
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.txtComment.Location = new System.Drawing.Point(270, 513);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(580, 63);
            this.txtComment.TabIndex = 4;
            // 
            // ConsignmentSettlement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 663);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalProfitAmt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalConsignPaidAmt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPaidCash);
            this.Controls.Add(this.dgvConsingmentPaid);
            this.Controls.Add(this.groupBox2);
            this.Name = "ConsignmentSettlement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consignment Settlement";
            this.Load += new System.EventHandler(this.ConsignmentSettlement_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsingmentPaid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboConsignor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvConsingmentPaid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnPaidCash;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtTotalConsignPaidAmt;
        private System.Windows.Forms.Label txtTotalProfitAmt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}