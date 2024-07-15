﻿namespace POS
{
    partial class ProfitAndLoss_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfitAndLoss_frm));
            this.gbPeriod = new System.Windows.Forms.GroupBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboProductName = new System.Windows.Forms.ComboBox();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.rdoProduct = new System.Windows.Forms.RadioButton();
            this.rdoBrand = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboCounter = new System.Windows.Forms.ComboBox();
            this.rdoCounterName = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbPeriod.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPeriod
            // 
            this.gbPeriod.Controls.Add(this.dtFrom);
            this.gbPeriod.Controls.Add(this.label3);
            this.gbPeriod.Controls.Add(this.label2);
            this.gbPeriod.Controls.Add(this.dtTo);
            this.gbPeriod.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPeriod.Location = new System.Drawing.Point(4, 1);
            this.gbPeriod.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPeriod.Name = "gbPeriod";
            this.gbPeriod.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPeriod.Size = new System.Drawing.Size(766, 56);
            this.gbPeriod.TabIndex = 13;
            this.gbPeriod.TabStop = false;
            this.gbPeriod.Text = "By Period";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(175, 20);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(181, 27);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(545, 20);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(181, 27);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboProductName);
            this.groupBox3.Controls.Add(this.cboBrand);
            this.groupBox3.Controls.Add(this.rdoProduct);
            this.groupBox3.Controls.Add(this.rdoBrand);
            this.groupBox3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(4, 65);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(766, 61);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selecet One";
            // 
            // cboProductName
            // 
            this.cboProductName.FormattingEnabled = true;
            this.cboProductName.Location = new System.Drawing.Point(545, 21);
            this.cboProductName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProductName.Name = "cboProductName";
            this.cboProductName.Size = new System.Drawing.Size(181, 28);
            this.cboProductName.TabIndex = 4;
            this.cboProductName.SelectedValueChanged += new System.EventHandler(this.cboProductName_SelectedValueChanged);
            // 
            // cboBrand
            // 
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(175, 21);
            this.cboBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(181, 28);
            this.cboBrand.TabIndex = 6;
            this.cboBrand.SelectedValueChanged += new System.EventHandler(this.cboBrand_SelectedValueChanged);
            // 
            // rdoProduct
            // 
            this.rdoProduct.AutoSize = true;
            this.rdoProduct.Location = new System.Drawing.Point(434, 21);
            this.rdoProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoProduct.Name = "rdoProduct";
            this.rdoProduct.Size = new System.Drawing.Size(105, 24);
            this.rdoProduct.TabIndex = 7;
            this.rdoProduct.TabStop = true;
            this.rdoProduct.Text = "Product Name";
            this.rdoProduct.UseVisualStyleBackColor = true;
            this.rdoProduct.CheckedChanged += new System.EventHandler(this.rdoProduct_CheckedChanged);
            // 
            // rdoBrand
            // 
            this.rdoBrand.AutoSize = true;
            this.rdoBrand.Location = new System.Drawing.Point(52, 21);
            this.rdoBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoBrand.Name = "rdoBrand";
            this.rdoBrand.Size = new System.Drawing.Size(93, 24);
            this.rdoBrand.TabIndex = 7;
            this.rdoBrand.TabStop = true;
            this.rdoBrand.Text = "Brand Name";
            this.rdoBrand.UseVisualStyleBackColor = true;
            this.rdoBrand.CheckedChanged += new System.EventHandler(this.rdoBrand_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(434, 20);
            this.rdoAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(39, 24);
            this.rdoAll.TabIndex = 7;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reportViewer1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 225);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(766, 448);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gross Profit / Loss List";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(8, 21);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(751, 419);
            this.reportViewer1.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::POS.Properties.Resources.refresh_small;
            this.btnRefresh.Location = new System.Drawing.Point(678, 194);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 27);
            this.btnRefresh.TabIndex = 23;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboCounter
            // 
            this.cboCounter.FormattingEnabled = true;
            this.cboCounter.Location = new System.Drawing.Point(175, 20);
            this.cboCounter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboCounter.Name = "cboCounter";
            this.cboCounter.Size = new System.Drawing.Size(181, 28);
            this.cboCounter.TabIndex = 9;
            this.cboCounter.SelectedValueChanged += new System.EventHandler(this.cboCounter_SelectedValueChanged);
            // 
            // rdoCounterName
            // 
            this.rdoCounterName.AutoSize = true;
            this.rdoCounterName.Location = new System.Drawing.Point(52, 19);
            this.rdoCounterName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoCounterName.Name = "rdoCounterName";
            this.rdoCounterName.Size = new System.Drawing.Size(106, 24);
            this.rdoCounterName.TabIndex = 7;
            this.rdoCounterName.TabStop = true;
            this.rdoCounterName.Text = "Counter Name";
            this.rdoCounterName.UseVisualStyleBackColor = true;
            this.rdoCounterName.CheckedChanged += new System.EventHandler(this.rdoCounterName_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCounter);
            this.groupBox1.Controls.Add(this.rdoCounterName);
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(4, 134);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(766, 52);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecet One";
            // 
            // ProfitAndLoss_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 676);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbPeriod);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProfitAndLoss_frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gross Profit / Loss Report";
            this.Load += new System.EventHandler(this.ProfitAndLoss_frm_Load);
            this.gbPeriod.ResumeLayout(false);
            this.gbPeriod.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPeriod;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RadioButton rdoProduct;
        private System.Windows.Forms.RadioButton rdoBrand;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.ComboBox cboProductName;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.ComboBox cboCounter;
        private System.Windows.Forms.RadioButton rdoCounterName;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}