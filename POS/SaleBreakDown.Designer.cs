namespace POS
{
    partial class SaleBreakDown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleBreakDown));
            this.gbPeriod = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbSegment = new System.Windows.Forms.RadioButton();
            this.rdbRange = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbUnitPrice = new System.Windows.Forms.RadioButton();
            this.rdbSaleTrueValue = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbPeriod.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPeriod
            // 
            this.gbPeriod.Controls.Add(this.dtTo);
            this.gbPeriod.Controls.Add(this.dtFrom);
            this.gbPeriod.Controls.Add(this.label3);
            this.gbPeriod.Controls.Add(this.label2);
            this.gbPeriod.Location = new System.Drawing.Point(5, 2);
            this.gbPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPeriod.Name = "gbPeriod";
            this.gbPeriod.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPeriod.Size = new System.Drawing.Size(625, 49);
            this.gbPeriod.TabIndex = 11;
            this.gbPeriod.TabStop = false;
            this.gbPeriod.Text = "By Period";
            this.gbPeriod.Enter += new System.EventHandler(this.gbPeriod_Enter);
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(407, 18);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(111, 25);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(123, 18);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(110, 25);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbSegment);
            this.groupBox1.Controls.Add(this.rdbRange);
            this.groupBox1.Location = new System.Drawing.Point(5, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(625, 46);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select One";
            // 
            // rdbSegment
            // 
            this.rdbSegment.AutoSize = true;
            this.rdbSegment.Location = new System.Drawing.Point(407, 14);
            this.rdbSegment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbSegment.Name = "rdbSegment";
            this.rdbSegment.Size = new System.Drawing.Size(86, 22);
            this.rdbSegment.TabIndex = 1;
            this.rdbSegment.TabStop = true;
            this.rdbSegment.Text = "By Category";
            this.rdbSegment.UseVisualStyleBackColor = true;
            this.rdbSegment.CheckedChanged += new System.EventHandler(this.rdbSegment_CheckedChanged);
            // 
            // rdbRange
            // 
            this.rdbRange.AutoSize = true;
            this.rdbRange.Location = new System.Drawing.Point(123, 14);
            this.rdbRange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbRange.Name = "rdbRange";
            this.rdbRange.Size = new System.Drawing.Size(69, 22);
            this.rdbRange.TabIndex = 0;
            this.rdbRange.TabStop = true;
            this.rdbRange.Text = "By Brand";
            this.rdbRange.UseVisualStyleBackColor = true;
            this.rdbRange.CheckedChanged += new System.EventHandler(this.rdbRange_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbUnitPrice);
            this.groupBox2.Controls.Add(this.rdbSaleTrueValue);
            this.groupBox2.Location = new System.Drawing.Point(5, 105);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(625, 50);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "By Require Sale Value";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rdbUnitPrice
            // 
            this.rdbUnitPrice.AutoSize = true;
            this.rdbUnitPrice.Location = new System.Drawing.Point(407, 21);
            this.rdbUnitPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbUnitPrice.Name = "rdbUnitPrice";
            this.rdbUnitPrice.Size = new System.Drawing.Size(71, 22);
            this.rdbUnitPrice.TabIndex = 3;
            this.rdbUnitPrice.TabStop = true;
            this.rdbUnitPrice.Text = "Unit Price";
            this.rdbUnitPrice.UseVisualStyleBackColor = true;
            this.rdbUnitPrice.CheckedChanged += new System.EventHandler(this.rdbUnitPrice_CheckedChanged);
            // 
            // rdbSaleTrueValue
            // 
            this.rdbSaleTrueValue.AutoSize = true;
            this.rdbSaleTrueValue.Location = new System.Drawing.Point(123, 21);
            this.rdbSaleTrueValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbSaleTrueValue.Name = "rdbSaleTrueValue";
            this.rdbSaleTrueValue.Size = new System.Drawing.Size(97, 22);
            this.rdbSaleTrueValue.TabIndex = 2;
            this.rdbSaleTrueValue.TabStop = true;
            this.rdbSaleTrueValue.Text = "Sale True Price";
            this.rdbSaleTrueValue.UseVisualStyleBackColor = true;
            this.rdbSaleTrueValue.CheckedChanged += new System.EventHandler(this.rdbSaleTrueValue_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.reportViewer1);
            this.groupBox3.Location = new System.Drawing.Point(5, 163);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(799, 510);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sale List";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(7, 26);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(783, 476);
            this.reportViewer1.TabIndex = 4;
            // 
            // SaleBreakDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 676);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPeriod);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SaleBreakDown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sale Breakdown Report";
            this.Load += new System.EventHandler(this.SaleBreakDown_Load);
            this.gbPeriod.ResumeLayout(false);
            this.gbPeriod.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPeriod;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSegment;
        private System.Windows.Forms.RadioButton rdbRange;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbUnitPrice;
        private System.Windows.Forms.RadioButton rdbSaleTrueValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}