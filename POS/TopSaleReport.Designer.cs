namespace POS
{
    partial class TopSaleReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopSaleReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAmount = new System.Windows.Forms.RadioButton();
            this.rdbQty = new System.Windows.Forms.RadioButton();
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
            this.txtRow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbTransactionList.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAmount);
            this.groupBox1.Controls.Add(this.rdbQty);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(367, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Type";
            // 
            // rdbAmount
            // 
            this.rdbAmount.AutoSize = true;
            this.rdbAmount.Location = new System.Drawing.Point(277, 37);
            this.rdbAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbAmount.Name = "rdbAmount";
            this.rdbAmount.Size = new System.Drawing.Size(78, 22);
            this.rdbAmount.TabIndex = 1;
            this.rdbAmount.TabStop = true;
            this.rdbAmount.Text = "By Amount";
            this.rdbAmount.UseVisualStyleBackColor = true;
            this.rdbAmount.CheckedChanged += new System.EventHandler(this.rdbAmount_CheckedChanged);
            // 
            // rdbQty
            // 
            this.rdbQty.AutoSize = true;
            this.rdbQty.Location = new System.Drawing.Point(80, 37);
            this.rdbQty.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbQty.Name = "rdbQty";
            this.rdbQty.Size = new System.Drawing.Size(83, 22);
            this.rdbQty.TabIndex = 0;
            this.rdbQty.TabStop = true;
            this.rdbQty.Text = "By Quantity";
            this.rdbQty.UseVisualStyleBackColor = true;
            this.rdbQty.CheckedChanged += new System.EventHandler(this.rdbQty_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 79);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(668, 79);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Period";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(367, 30);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 25);
            this.dtpTo.TabIndex = 11;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(111, 30);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 25);
            this.dtpFrom.TabIndex = 9;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "From";
            // 
            // gbTransactionList
            // 
            this.gbTransactionList.Controls.Add(this.reportViewer1);
            this.gbTransactionList.Controls.Add(this.label3);
            this.gbTransactionList.Controls.Add(this.btnPrint);
            this.gbTransactionList.Controls.Add(this.lblPeriod);
            this.gbTransactionList.Location = new System.Drawing.Point(6, 166);
            this.gbTransactionList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTransactionList.Name = "gbTransactionList";
            this.gbTransactionList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTransactionList.Size = new System.Drawing.Size(931, 509);
            this.gbTransactionList.TabIndex = 3;
            this.gbTransactionList.TabStop = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS.Reports.TransactionReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 48);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(917, 416);
            this.reportViewer1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
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
            this.btnPrint.Location = new System.Drawing.Point(817, 464);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 37);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(408, 26);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(12, 18);
            this.lblPeriod.TabIndex = 1;
            this.lblPeriod.Text = "-";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRow);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(379, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(295, 71);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(114, 36);
            this.txtRow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(104, 25);
            this.txtRow.TabIndex = 1;
            this.txtRow.TextChanged += new System.EventHandler(this.txtRow_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Row :";
            // 
            // TopSaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(941, 676);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbTransactionList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TopSaleReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Best Seller Report";
            this.Load += new System.EventHandler(this.TopSaleReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbTransactionList.ResumeLayout(false);
            this.gbTransactionList.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAmount;
        private System.Windows.Forms.RadioButton rdbQty;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.Label label4;
    }
}