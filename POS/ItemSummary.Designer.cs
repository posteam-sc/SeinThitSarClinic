﻿namespace POS
{
    partial class ItemSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSummary));
            this.gbList = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbRefund = new System.Windows.Forms.RadioButton();
            this.rdbSale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rdoFOC = new System.Windows.Forms.RadioButton();
            this.gbList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.reportViewer1);
            this.gbList.Location = new System.Drawing.Point(6, 140);
            this.gbList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbList.Name = "gbList";
            this.gbList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbList.Size = new System.Drawing.Size(641, 488);
            this.gbList.TabIndex = 0;
            this.gbList.TabStop = false;
            this.gbList.Text = "Item Sale Report";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(6, 26);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(629, 452);
            this.reportViewer1.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::POS.Properties.Resources.print_big;
            this.btnPrint.Location = new System.Drawing.Point(526, 626);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 44);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoFOC);
            this.groupBox2.Controls.Add(this.rdbRefund);
            this.groupBox2.Controls.Add(this.rdbSale);
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(260, 58);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Category";
            // 
            // rdbRefund
            // 
            this.rdbRefund.AutoSize = true;
            this.rdbRefund.Location = new System.Drawing.Point(160, 26);
            this.rdbRefund.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbRefund.Name = "rdbRefund";
            this.rdbRefund.Size = new System.Drawing.Size(61, 22);
            this.rdbRefund.TabIndex = 2;
            this.rdbRefund.Text = "Refund";
            this.rdbRefund.UseVisualStyleBackColor = true;
            this.rdbRefund.CheckedChanged += new System.EventHandler(this.rdbRefund_CheckedChanged);
            // 
            // rdbSale
            // 
            this.rdbSale.AutoSize = true;
            this.rdbSale.Checked = true;
            this.rdbSale.Location = new System.Drawing.Point(6, 26);
            this.rdbSale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbSale.Name = "rdbSale";
            this.rdbSale.Size = new System.Drawing.Size(46, 22);
            this.rdbSale.TabIndex = 0;
            this.rdbSale.TabStop = true;
            this.rdbSale.Text = "Sale";
            this.rdbSale.UseVisualStyleBackColor = true;
            this.rdbSale.CheckedChanged += new System.EventHandler(this.rdbSale_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(269, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(378, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Period";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(257, 23);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(111, 25);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(69, 23);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(111, 25);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboProductName);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(6, 62);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(454, 70);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "By Product Name";
            // 
            // cboProductName
            // 
            this.cboProductName.DropDownWidth = 400;
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(63, 26);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(380, 26);
            this.cboProductName.TabIndex = 11;
            this.cboProductName.SelectedIndexChanged += new System.EventHandler(this.cboProductName_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "&Name :";
            // 
            // rdoFOC
            // 
            this.rdoFOC.AutoSize = true;
            this.rdoFOC.Location = new System.Drawing.Point(86, 26);
            this.rdoFOC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoFOC.Name = "rdoFOC";
            this.rdoFOC.Size = new System.Drawing.Size(47, 22);
            this.rdoFOC.TabIndex = 1;
            this.rdoFOC.Text = "FOC";
            this.rdoFOC.UseVisualStyleBackColor = true;
            this.rdoFOC.CheckedChanged += new System.EventHandler(this.rdoFOC_CheckedChanged);
            // 
            // ItemSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(649, 676);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbList);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItemSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item  Sale Summary Report";
            this.Load += new System.EventHandler(this.ItemSummary_Load);
            this.gbList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdbRefund;
        private System.Windows.Forms.RadioButton rdbSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rdoFOC;
    }
}