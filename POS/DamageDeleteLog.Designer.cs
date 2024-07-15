namespace POS
{
    partial class DamageDeleteLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DamageDeleteLog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDamageDeleteLog = new System.Windows.Forms.DataGridView();
            this.colDamageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDamageQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsibleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageDeleteLog)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(736, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "By Period";
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(265, 25);
            this.dtTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(111, 25);
            this.dtTo.TabIndex = 3;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(58, 26);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(111, 25);
            this.dtFrom.TabIndex = 1;
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDamageDeleteLog);
            this.groupBox2.Location = new System.Drawing.Point(5, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(996, 555);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Damage Delete";
            // 
            // dgvDamageDeleteLog
            // 
            this.dgvDamageDeleteLog.AllowUserToAddRows = false;
            this.dgvDamageDeleteLog.AllowUserToDeleteRows = false;
            this.dgvDamageDeleteLog.AllowUserToResizeColumns = false;
            this.dgvDamageDeleteLog.AllowUserToResizeRows = false;
            this.dgvDamageDeleteLog.BackgroundColor = System.Drawing.Color.White;
            this.dgvDamageDeleteLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDamageDeleteLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamageDeleteLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDamageId,
            this.Column1,
            this.Column2,
            this.colProductName,
            this.colDamageQty,
            this.colUnitPrice,
            this.colTotalCost,
            this.colResponsibleName,
            this.colReason});
            this.dgvDamageDeleteLog.Location = new System.Drawing.Point(6, 21);
            this.dgvDamageDeleteLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDamageDeleteLog.Name = "dgvDamageDeleteLog";
            this.dgvDamageDeleteLog.RowHeadersVisible = false;
            this.dgvDamageDeleteLog.Size = new System.Drawing.Size(983, 525);
            this.dgvDamageDeleteLog.TabIndex = 0;
            // 
            // colDamageId
            // 
            this.colDamageId.DataPropertyName = "DamageId";
            this.colDamageId.HeaderText = "Damage ID";
            this.colDamageId.Name = "colDamageId";
            this.colDamageId.ReadOnly = true;
            this.colDamageId.Visible = false;
            this.colDamageId.Width = 120;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DeletedDate";
            this.Column1.HeaderText = "Deleted Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DeletedUser";
            this.Column2.HeaderText = "Delete User";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 250;
            // 
            // colDamageQty
            // 
            this.colDamageQty.DataPropertyName = "DamageQty";
            this.colDamageQty.HeaderText = "Damage Qty";
            this.colDamageQty.Name = "colDamageQty";
            this.colDamageQty.ReadOnly = true;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colTotalCost
            // 
            this.colTotalCost.DataPropertyName = "TotalCost";
            this.colTotalCost.HeaderText = "Total Cost";
            this.colTotalCost.Name = "colTotalCost";
            this.colTotalCost.ReadOnly = true;
            // 
            // colResponsibleName
            // 
            this.colResponsibleName.DataPropertyName = "ResponsibleName";
            this.colResponsibleName.HeaderText = "Responsible Name";
            this.colResponsibleName.Name = "colResponsibleName";
            this.colResponsibleName.ReadOnly = true;
            // 
            // colReason
            // 
            this.colReason.DataPropertyName = "Reason";
            this.colReason.HeaderText = "Reason";
            this.colReason.Name = "colReason";
            this.colReason.ReadOnly = true;
            // 
            // DamageDeleteLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1006, 632);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DamageDeleteLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Damage Delete Log";
            this.Load += new System.EventHandler(this.DamageDeleteLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamageDeleteLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDamageDeleteLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDamageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDamageQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsibleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReason;
    }
}