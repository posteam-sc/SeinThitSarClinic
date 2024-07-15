namespace POS
{
    partial class DamageListFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDamagelist = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamageQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamageDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsibleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.GpDamageList = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpk_fromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.GpSearchByPeriod = new System.Windows.Forms.GroupBox();
            this.dtpk_toDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBrand = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdNonConsignment = new System.Windows.Forms.RadioButton();
            this.rdConsignment = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamagelist)).BeginInit();
            this.GpDamageList.SuspendLayout();
            this.GpSearchByPeriod.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDamagelist
            // 
            this.dgvDamagelist.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDamagelist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDamagelist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDamagelist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column3,
            this.Column1,
            this.colName,
            this.Price,
            this.DamageQty,
            this.TotalCost,
            this.DamageDateTime,
            this.ResponsibleName,
            this.Column2,
            this.Delete});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDamagelist.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDamagelist.Location = new System.Drawing.Point(12, 26);
            this.dgvDamagelist.Name = "dgvDamagelist";
            this.dgvDamagelist.ReadOnly = true;
            this.dgvDamagelist.RowHeadersVisible = false;
            this.dgvDamagelist.Size = new System.Drawing.Size(1151, 500);
            this.dgvDamagelist.TabIndex = 0;
            this.dgvDamagelist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDamagelist_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ProductId";
            this.Column3.HeaderText = "ProductId";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ProductCode";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Product Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colName.HeaderText = "Product Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 300;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // DamageQty
            // 
            this.DamageQty.DataPropertyName = "DamageQty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DamageQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.DamageQty.HeaderText = "Qty";
            this.DamageQty.Name = "DamageQty";
            this.DamageQty.ReadOnly = true;
            this.DamageQty.Width = 50;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "TotalCost";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalCost.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalCost.HeaderText = "Total Cost";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // DamageDateTime
            // 
            this.DamageDateTime.DataPropertyName = "DamageDateTime";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.NullValue = null;
            this.DamageDateTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.DamageDateTime.HeaderText = "Damage Date";
            this.DamageDateTime.Name = "DamageDateTime";
            this.DamageDateTime.ReadOnly = true;
            // 
            // ResponsibleName
            // 
            this.ResponsibleName.DataPropertyName = "ResponsibleName";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ResponsibleName.DefaultCellStyle = dataGridViewCellStyle8;
            this.ResponsibleName.HeaderText = "Respon:Person";
            this.ResponsibleName.Name = "ResponsibleName";
            this.ResponsibleName.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Reason";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column2.HeaderText = "Reason";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForLinkValue = true;
            this.Delete.Width = 50;
            // 
            // GpDamageList
            // 
            this.GpDamageList.Controls.Add(this.dgvDamagelist);
            this.GpDamageList.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpDamageList.Location = new System.Drawing.Point(9, 136);
            this.GpDamageList.Name = "GpDamageList";
            this.GpDamageList.Size = new System.Drawing.Size(1170, 538);
            this.GpDamageList.TabIndex = 3;
            this.GpDamageList.TabStop = false;
            this.GpDamageList.Text = "Damage List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // dtpk_fromDate
            // 
            this.dtpk_fromDate.Location = new System.Drawing.Point(119, 19);
            this.dtpk_fromDate.Name = "dtpk_fromDate";
            this.dtpk_fromDate.Size = new System.Drawing.Size(236, 27);
            this.dtpk_fromDate.TabIndex = 1;
            this.dtpk_fromDate.ValueChanged += new System.EventHandler(this.dtpk_fromDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "To:";
            // 
            // GpSearchByPeriod
            // 
            this.GpSearchByPeriod.Controls.Add(this.dtpk_toDate);
            this.GpSearchByPeriod.Controls.Add(this.label1);
            this.GpSearchByPeriod.Controls.Add(this.dtpk_fromDate);
            this.GpSearchByPeriod.Controls.Add(this.label2);
            this.GpSearchByPeriod.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GpSearchByPeriod.Location = new System.Drawing.Point(9, 16);
            this.GpSearchByPeriod.Name = "GpSearchByPeriod";
            this.GpSearchByPeriod.Size = new System.Drawing.Size(945, 57);
            this.GpSearchByPeriod.TabIndex = 0;
            this.GpSearchByPeriod.TabStop = false;
            this.GpSearchByPeriod.Text = "Search By Period";
            // 
            // dtpk_toDate
            // 
            this.dtpk_toDate.Location = new System.Drawing.Point(469, 19);
            this.dtpk_toDate.Name = "dtpk_toDate";
            this.dtpk_toDate.Size = new System.Drawing.Size(236, 27);
            this.dtpk_toDate.TabIndex = 3;
            this.dtpk_toDate.Value = new System.DateTime(2014, 11, 12, 16, 22, 45, 0);
            this.dtpk_toDate.ValueChanged += new System.EventHandler(this.dtpk_toDate_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cboBrand);
            this.groupBox4.Location = new System.Drawing.Point(482, 79);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAll);
            this.groupBox2.Controls.Add(this.rdNonConsignment);
            this.groupBox2.Controls.Add(this.rdConsignment);
            this.groupBox2.Location = new System.Drawing.Point(9, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Counter";
            // 
            // rdNonConsignment
            // 
            this.rdNonConsignment.AutoSize = true;
            this.rdNonConsignment.Checked = true;
            this.rdNonConsignment.Location = new System.Drawing.Point(119, 24);
            this.rdNonConsignment.Name = "rdNonConsignment";
            this.rdNonConsignment.Size = new System.Drawing.Size(149, 17);
            this.rdNonConsignment.TabIndex = 1;
            this.rdNonConsignment.TabStop = true;
            this.rdNonConsignment.Text = "Non-Consignment Counter";
            this.rdNonConsignment.UseVisualStyleBackColor = true;
            this.rdNonConsignment.CheckedChanged += new System.EventHandler(this.rdConsignment_CheckedChanged);
            // 
            // rdConsignment
            // 
            this.rdConsignment.AutoSize = true;
            this.rdConsignment.Location = new System.Drawing.Point(323, 24);
            this.rdConsignment.Name = "rdConsignment";
            this.rdConsignment.Size = new System.Drawing.Size(126, 17);
            this.rdConsignment.TabIndex = 0;
            this.rdConsignment.Text = "Consignment Counter";
            this.rdConsignment.UseVisualStyleBackColor = true;
            this.rdConsignment.CheckedChanged += new System.EventHandler(this.rdConsignment_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = true;
            this.rdoAll.Location = new System.Drawing.Point(12, 24);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 2;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // DamageListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 676);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GpDamageList);
            this.Controls.Add(this.GpSearchByPeriod);
            this.Name = "DamageListFrm";
            this.Text = "Damage List";
            this.Load += new System.EventHandler(this.DamageListFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDamagelist)).EndInit();
            this.GpDamageList.ResumeLayout(false);
            this.GpSearchByPeriod.ResumeLayout(false);
            this.GpSearchByPeriod.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDamagelist;
        private System.Windows.Forms.GroupBox GpDamageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpk_fromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GpSearchByPeriod;
        private System.Windows.Forms.DateTimePicker dtpk_toDate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBrand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdNonConsignment;
        private System.Windows.Forms.RadioButton rdConsignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamageQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamageDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsibleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.RadioButton rdoAll;

    }
}