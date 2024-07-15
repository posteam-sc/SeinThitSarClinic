namespace POS
{
    partial class DamageRpt
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdNonConsignment = new System.Windows.Forms.RadioButton();
            this.rdConsignment = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.reportViewer1);
            this.groupBox3.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 139);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1197, 534);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Damage Report";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(9, 26);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(1182, 502);
            this.reportViewer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1089, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select By Period";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(466, 31);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(241, 27);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(98, 31);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(237, 27);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAll);
            this.groupBox2.Controls.Add(this.rdNonConsignment);
            this.groupBox2.Controls.Add(this.rdConsignment);
            this.groupBox2.Location = new System.Drawing.Point(5, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Counter";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(9, 21);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdNonConsignment
            // 
            this.rdNonConsignment.AutoSize = true;
            this.rdNonConsignment.Location = new System.Drawing.Point(298, 21);
            this.rdNonConsignment.Name = "rdNonConsignment";
            this.rdNonConsignment.Size = new System.Drawing.Size(149, 17);
            this.rdNonConsignment.TabIndex = 2;
            this.rdNonConsignment.Text = "Non-Consignment Counter";
            this.rdNonConsignment.UseVisualStyleBackColor = true;
            this.rdNonConsignment.CheckedChanged += new System.EventHandler(this.rdConsignment_CheckedChanged);
            // 
            // rdConsignment
            // 
            this.rdConsignment.AutoSize = true;
            this.rdConsignment.Checked = true;
            this.rdConsignment.Location = new System.Drawing.Point(111, 21);
            this.rdConsignment.Name = "rdConsignment";
            this.rdConsignment.Size = new System.Drawing.Size(126, 17);
            this.rdConsignment.TabIndex = 1;
            this.rdConsignment.TabStop = true;
            this.rdConsignment.Text = "Consignment Counter";
            this.rdConsignment.UseVisualStyleBackColor = true;
            this.rdConsignment.CheckedChanged += new System.EventHandler(this.rdConsignment_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboBrand);
            this.groupBox4.Location = new System.Drawing.Point(478, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 57);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(29, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Brand :";
            // 
            // cboBrand
            // 
            this.cboBrand.FormattingEnabled = true;
            this.cboBrand.Location = new System.Drawing.Point(76, 20);
            this.cboBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboBrand.Name = "cboBrand";
            this.cboBrand.Size = new System.Drawing.Size(139, 21);
            this.cboBrand.TabIndex = 1;
            this.cboBrand.SelectedValueChanged += new System.EventHandler(this.rdConsignment_CheckedChanged);
            // 
            // DamageRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1204, 676);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "DamageRpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Damage Report";
            this.Load += new System.EventHandler(this.DamageRpt_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdNonConsignment;
        private System.Windows.Forms.RadioButton rdConsignment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.RadioButton rdoAll;

    }
}