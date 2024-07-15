﻿namespace POS
{
    partial class Transaction_Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transaction_Reports));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbSummary = new System.Windows.Forms.RadioButton();
            this.rdbDebt = new System.Windows.Forms.RadioButton();
            this.rdbRefund = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTransactionList = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkCounter = new System.Windows.Forms.CheckBox();
            this.chkCashier = new System.Windows.Forms.CheckBox();
            this.lblCounterName = new System.Windows.Forms.Label();
            this.lblCashierName = new System.Windows.Forms.Label();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.cboCashier = new System.Windows.Forms.ComboBox();
            this.gbPaymentType = new System.Windows.Forms.GroupBox();
            this.chkCredit = new System.Windows.Forms.CheckBox();
            this.chkGiftCard = new System.Windows.Forms.CheckBox();
            this.chkCash = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbTransactionList.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPaymentType.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSummary);
            this.groupBox1.Controls.Add(this.rdbDebt);
            this.groupBox1.Controls.Add(this.rdbRefund);
            this.groupBox1.Controls.Add(this.rdbSale);
            this.groupBox1.Location = new System.Drawing.Point(29, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 38);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Category";
            // 
            // rdbSummary
            // 
            this.rdbSummary.AutoSize = true;
            this.rdbSummary.Checked = true;
            this.rdbSummary.Location = new System.Drawing.Point(58, 17);
            this.rdbSummary.Name = "rdbSummary";
            this.rdbSummary.Size = new System.Drawing.Size(68, 17);
            this.rdbSummary.TabIndex = 3;
            this.rdbSummary.TabStop = true;
            this.rdbSummary.Text = "Summary";
            this.rdbSummary.UseVisualStyleBackColor = true;
            this.rdbSummary.CheckedChanged += new System.EventHandler(this.rdbSummary_CheckedChanged);
            // 
            // rdbDebt
            // 
            this.rdbDebt.AutoSize = true;
            this.rdbDebt.Location = new System.Drawing.Point(552, 17);
            this.rdbDebt.Name = "rdbDebt";
            this.rdbDebt.Size = new System.Drawing.Size(78, 17);
            this.rdbDebt.TabIndex = 2;
            this.rdbDebt.Text = "Settlement ";
            this.rdbDebt.UseVisualStyleBackColor = true;
            this.rdbDebt.CheckedChanged += new System.EventHandler(this.rdbDebt_CheckedChanged);
            // 
            // rdbRefund
            // 
            this.rdbRefund.AutoSize = true;
            this.rdbRefund.Location = new System.Drawing.Point(373, 17);
            this.rdbRefund.Name = "rdbRefund";
            this.rdbRefund.Size = new System.Drawing.Size(60, 17);
            this.rdbRefund.TabIndex = 1;
            this.rdbRefund.Text = "Refund";
            this.rdbRefund.UseVisualStyleBackColor = true;
            this.rdbRefund.CheckedChanged += new System.EventHandler(this.rdbRefund_CheckedChanged);
            // 
            // rdbSale
            // 
            this.rdbSale.AutoSize = true;
            this.rdbSale.Location = new System.Drawing.Point(239, 17);
            this.rdbSale.Name = "rdbSale";
            this.rdbSale.Size = new System.Drawing.Size(46, 17);
            this.rdbSale.TabIndex = 0;
            this.rdbSale.Text = "Sale";
            this.rdbSale.UseVisualStyleBackColor = true;
            this.rdbSale.CheckedChanged += new System.EventHandler(this.rdbSale_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(29, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Period";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(424, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 7;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(168, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 5;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // gbTransactionList
            // 
            this.gbTransactionList.Controls.Add(this.reportViewer1);
            this.gbTransactionList.Controls.Add(this.label3);
            this.gbTransactionList.Controls.Add(this.btnPrint);
            this.gbTransactionList.Controls.Add(this.lblPeriod);
            this.gbTransactionList.Location = new System.Drawing.Point(29, 286);
            this.gbTransactionList.Name = "gbTransactionList";
            this.gbTransactionList.Size = new System.Drawing.Size(668, 385);
            this.gbTransactionList.TabIndex = 2;
            this.gbTransactionList.TabStop = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.TransactionReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 43);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(656, 292);
            this.reportViewer1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Period";
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::POS.Properties.Resources.print_big;
            this.btnPrint.Location = new System.Drawing.Point(545, 341);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 37);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(408, 16);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(10, 13);
            this.lblPeriod.TabIndex = 1;
            this.lblPeriod.Text = "-";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkCounter);
            this.groupBox3.Controls.Add(this.chkCashier);
            this.groupBox3.Controls.Add(this.lblCounterName);
            this.groupBox3.Controls.Add(this.lblCashierName);
            this.groupBox3.Controls.Add(this.cboCounter);
            this.groupBox3.Controls.Add(this.cboCashier);
            this.groupBox3.Location = new System.Drawing.Point(29, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 98);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "By Cashier or Counter";
            // 
            // chkCounter
            // 
            this.chkCounter.AutoSize = true;
            this.chkCounter.Location = new System.Drawing.Point(373, 19);
            this.chkCounter.Name = "chkCounter";
            this.chkCounter.Size = new System.Drawing.Size(75, 17);
            this.chkCounter.TabIndex = 7;
            this.chkCounter.Text = "ByCounter";
            this.chkCounter.UseVisualStyleBackColor = true;
            this.chkCounter.CheckedChanged += new System.EventHandler(this.chkCounter_CheckedChanged);
            // 
            // chkCashier
            // 
            this.chkCashier.AutoSize = true;
            this.chkCashier.Location = new System.Drawing.Point(58, 19);
            this.chkCashier.Name = "chkCashier";
            this.chkCashier.Size = new System.Drawing.Size(73, 17);
            this.chkCashier.TabIndex = 6;
            this.chkCashier.Text = "ByCashier";
            this.chkCashier.UseVisualStyleBackColor = true;
            this.chkCashier.CheckedChanged += new System.EventHandler(this.chkCashier_CheckedChanged);
            // 
            // lblCounterName
            // 
            this.lblCounterName.AutoSize = true;
            this.lblCounterName.Enabled = false;
            this.lblCounterName.Location = new System.Drawing.Point(373, 44);
            this.lblCounterName.Name = "lblCounterName";
            this.lblCounterName.Size = new System.Drawing.Size(75, 13);
            this.lblCounterName.TabIndex = 5;
            this.lblCounterName.Text = "Counter Name";
            // 
            // lblCashierName
            // 
            this.lblCashierName.AutoSize = true;
            this.lblCashierName.Enabled = false;
            this.lblCashierName.Location = new System.Drawing.Point(55, 44);
            this.lblCashierName.Name = "lblCashierName";
            this.lblCashierName.Size = new System.Drawing.Size(73, 13);
            this.lblCashierName.TabIndex = 4;
            this.lblCashierName.Text = "Cashier Name";
            // 
            // cboCounter
            // 
            this.cboCounter.Enabled = false;
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(373, 69);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(227, 21);
            this.cboCounter.TabIndex = 3;
            this.cboCounter.SelectedIndexChanged += new System.EventHandler(this.cboCounter_SelectedIndexChanged);
            // 
            // cboCashier
            // 
            this.cboCashier.Enabled = false;
            this.cboCashier.FormattingEnabled = true;
            this.cboCashier.Location = new System.Drawing.Point(58, 69);
            this.cboCashier.Name = "cboCashier";
            this.cboCashier.Size = new System.Drawing.Size(227, 21);
            this.cboCashier.TabIndex = 2;
            this.cboCashier.SelectedIndexChanged += new System.EventHandler(this.cboCashier_SelectedIndexChanged);
            // 
            // gbPaymentType
            // 
            this.gbPaymentType.Controls.Add(this.chkCredit);
            this.gbPaymentType.Controls.Add(this.chkGiftCard);
            this.gbPaymentType.Controls.Add(this.chkCash);
            this.gbPaymentType.Location = new System.Drawing.Point(29, 228);
            this.gbPaymentType.Name = "gbPaymentType";
            this.gbPaymentType.Size = new System.Drawing.Size(668, 52);
            this.gbPaymentType.TabIndex = 4;
            this.gbPaymentType.TabStop = false;
            this.gbPaymentType.Text = "Report Payment Type";
            // 
            // chkCredit
            // 
            this.chkCredit.AutoSize = true;
            this.chkCredit.Checked = true;
            this.chkCredit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCredit.Location = new System.Drawing.Point(490, 20);
            this.chkCredit.Name = "chkCredit";
            this.chkCredit.Size = new System.Drawing.Size(53, 17);
            this.chkCredit.TabIndex = 2;
            this.chkCredit.Text = "Credit";
            this.chkCredit.UseVisualStyleBackColor = true;
            this.chkCredit.CheckedChanged += new System.EventHandler(this.chkCredit_CheckedChanged);
            // 
            // chkGiftCard
            // 
            this.chkGiftCard.AutoSize = true;
            this.chkGiftCard.Checked = true;
            this.chkGiftCard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGiftCard.Location = new System.Drawing.Point(279, 20);
            this.chkGiftCard.Name = "chkGiftCard";
            this.chkGiftCard.Size = new System.Drawing.Size(67, 17);
            this.chkGiftCard.TabIndex = 1;
            this.chkGiftCard.Text = "Gift Card";
            this.chkGiftCard.UseVisualStyleBackColor = true;
            this.chkGiftCard.CheckedChanged += new System.EventHandler(this.chkGiftCard_CheckedChanged);
            // 
            // chkCash
            // 
            this.chkCash.AutoSize = true;
            this.chkCash.Checked = true;
            this.chkCash.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCash.Location = new System.Drawing.Point(58, 20);
            this.chkCash.Name = "chkCash";
            this.chkCash.Size = new System.Drawing.Size(50, 17);
            this.chkCash.TabIndex = 0;
            this.chkCash.Text = "Cash";
            this.chkCash.UseVisualStyleBackColor = true;
            this.chkCash.CheckedChanged += new System.EventHandler(this.chkCash_CheckedChanged);
            // 
            // Transaction_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 692);
            this.Controls.Add(this.gbPaymentType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbTransactionList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transaction_Reports";
            this.Text = " Transaction Report";
            this.Load += new System.EventHandler(this.Transaction_Reports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbTransactionList.ResumeLayout(false);
            this.gbTransactionList.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbPaymentType.ResumeLayout(false);
            this.gbPaymentType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbRefund;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbTransactionList;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCounterName;
        private System.Windows.Forms.Label lblCashierName;
        private System.Windows.Forms.ComboBox cboCounter;
        private System.Windows.Forms.ComboBox cboCashier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkCounter;
        private System.Windows.Forms.CheckBox chkCashier;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox gbPaymentType;
        private System.Windows.Forms.CheckBox chkCredit;
        private System.Windows.Forms.CheckBox chkGiftCard;
        private System.Windows.Forms.CheckBox chkCash;
        private System.Windows.Forms.RadioButton rdbDebt;
        private System.Windows.Forms.RadioButton rdbSummary;
    }
}