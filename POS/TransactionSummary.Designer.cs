namespace POS
{
    partial class TransactionSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionSummary));
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
            this.groupBox2.SuspendLayout();
            this.gbTransactionList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(668, 52);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time Period";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(357, 25);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 7;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(101, 25);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 5;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 31);
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
            this.gbTransactionList.Location = new System.Drawing.Point(7, 70);
            this.gbTransactionList.Name = "gbTransactionList";
            this.gbTransactionList.Size = new System.Drawing.Size(668, 603);
            this.gbTransactionList.TabIndex = 8;
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
            this.reportViewer1.Size = new System.Drawing.Size(656, 525);
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
            this.btnPrint.Location = new System.Drawing.Point(551, 566);
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
            // TransactionSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(678, 676);
            this.Controls.Add(this.gbTransactionList);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransactionSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction Summary Report";
            this.Load += new System.EventHandler(this.TransactionSummary_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbTransactionList.ResumeLayout(false);
            this.gbTransactionList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTransactionList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblPeriod;
    }
}