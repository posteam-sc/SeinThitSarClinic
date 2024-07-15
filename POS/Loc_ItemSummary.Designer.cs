namespace POS
{
    partial class Loc_ItemSummary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loc_ItemSummary));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(666, 71);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Period";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(407, 32);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(111, 27);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(123, 32);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(110, 27);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "From";
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.reportViewer1);
            this.gbList.Controls.Add(this.btnPrint);
            this.gbList.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbList.Location = new System.Drawing.Point(7, 93);
            this.gbList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbList.Name = "gbList";
            this.gbList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbList.Size = new System.Drawing.Size(967, 578);
            this.gbList.TabIndex = 3;
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
            this.reportViewer1.Size = new System.Drawing.Size(955, 544);
            this.reportViewer1.TabIndex = 3;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(541, 475);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 44);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // Loc_ItemSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(977, 676);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbList);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Loc_ItemSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daily Summary Report";
            this.Load += new System.EventHandler(this.Loc_ItemSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbList;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnPrint;
    }
}