﻿namespace POS
{
    partial class UnitConversionListfrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvConversionList = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpConversionDate = new System.Windows.Forms.DateTimePicker();
            this.cboMaxProduct = new System.Windows.Forms.ComboBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConversionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaximumProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNormalProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaximumConvertedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiecesPerPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalConvertedNormalQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNormalUnitPurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversionList)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConversionList
            // 
            this.dgvConversionList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConversionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvConversionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConversionList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colConversionDate,
            this.colMaximumProduct,
            this.colNormalProduct,
            this.colMaximumConvertedQty,
            this.colPiecesPerPack,
            this.colTotalConvertedNormalQty,
            this.colNormalUnitPurchasePrice});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConversionList.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvConversionList.Location = new System.Drawing.Point(3, 64);
            this.dgvConversionList.Name = "dgvConversionList";
            this.dgvConversionList.ReadOnly = true;
            this.dgvConversionList.RowHeadersVisible = false;
            this.dgvConversionList.Size = new System.Drawing.Size(915, 613);
            this.dgvConversionList.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboMaxProduct);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.dtpConversionDate);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(3, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(742, 51);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search By :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label7.Location = new System.Drawing.Point(351, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Maximum Product    :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conversion Date :";
            // 
            // dtpConversionDate
            // 
            this.dtpConversionDate.CustomFormat = "dd - MMM - yyyy";
            this.dtpConversionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConversionDate.Location = new System.Drawing.Point(118, 20);
            this.dtpConversionDate.Name = "dtpConversionDate";
            this.dtpConversionDate.Size = new System.Drawing.Size(126, 20);
            this.dtpConversionDate.TabIndex = 1;
            this.dtpConversionDate.ValueChanged += new System.EventHandler(this.dtpConversionDate_ValueChanged);
            // 
            // cboMaxProduct
            // 
            this.cboMaxProduct.FormattingEnabled = true;
            this.cboMaxProduct.Location = new System.Drawing.Point(483, 18);
            this.cboMaxProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboMaxProduct.Name = "cboMaxProduct";
            this.cboMaxProduct.Size = new System.Drawing.Size(211, 21);
            this.cboMaxProduct.TabIndex = 3;
            this.cboMaxProduct.SelectedIndexChanged += new System.EventHandler(this.cboMaxProduct_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // colConversionDate
            // 
            this.colConversionDate.DataPropertyName = "ConversionDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.Format = "dd - MMM - yyyy";
            dataGridViewCellStyle2.NullValue = null;
            this.colConversionDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colConversionDate.HeaderText = "Conversion Date";
            this.colConversionDate.Name = "colConversionDate";
            this.colConversionDate.ReadOnly = true;
            // 
            // colMaximumProduct
            // 
            this.colMaximumProduct.DataPropertyName = "MaximumProduct";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.colMaximumProduct.DefaultCellStyle = dataGridViewCellStyle3;
            this.colMaximumProduct.HeaderText = "Maximum Product";
            this.colMaximumProduct.Name = "colMaximumProduct";
            this.colMaximumProduct.ReadOnly = true;
            this.colMaximumProduct.Width = 200;
            // 
            // colNormalProduct
            // 
            this.colNormalProduct.DataPropertyName = "NormalProduct";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.colNormalProduct.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNormalProduct.HeaderText = "Normal Product";
            this.colNormalProduct.Name = "colNormalProduct";
            this.colNormalProduct.ReadOnly = true;
            this.colNormalProduct.Width = 200;
            // 
            // colMaximumConvertedQty
            // 
            this.colMaximumConvertedQty.DataPropertyName = "MaximumConvertedQty";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.colMaximumConvertedQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.colMaximumConvertedQty.HeaderText = "Maximum Converted Qty";
            this.colMaximumConvertedQty.Name = "colMaximumConvertedQty";
            this.colMaximumConvertedQty.ReadOnly = true;
            // 
            // colPiecesPerPack
            // 
            this.colPiecesPerPack.DataPropertyName = "PiecesPerPack";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle6.Format = "N0";
            this.colPiecesPerPack.DefaultCellStyle = dataGridViewCellStyle6;
            this.colPiecesPerPack.HeaderText = "Pieces Per Pack";
            this.colPiecesPerPack.Name = "colPiecesPerPack";
            this.colPiecesPerPack.ReadOnly = true;
            // 
            // colTotalConvertedNormalQty
            // 
            this.colTotalConvertedNormalQty.DataPropertyName = "TotalConvertedNormalQty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle7.Format = "N0";
            this.colTotalConvertedNormalQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTotalConvertedNormalQty.HeaderText = "Total Converted Normal Qty";
            this.colTotalConvertedNormalQty.Name = "colTotalConvertedNormalQty";
            this.colTotalConvertedNormalQty.ReadOnly = true;
            // 
            // colNormalUnitPurchasePrice
            // 
            this.colNormalUnitPurchasePrice.DataPropertyName = "NormalUnitPurPrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNormalUnitPurchasePrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.colNormalUnitPurchasePrice.HeaderText = "Normal Unit Purchase Price";
            this.colNormalUnitPurchasePrice.Name = "colNormalUnitPurchasePrice";
            this.colNormalUnitPurchasePrice.ReadOnly = true;
            // 
            // UnitConversionListfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 680);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgvConversionList);
            this.Name = "UnitConversionListfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Unit Conversion List";
            this.Load += new System.EventHandler(this.UnitConversionListfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConversionList)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConversionList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpConversionDate;
        private System.Windows.Forms.ComboBox cboMaxProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConversionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaximumProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaximumConvertedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiecesPerPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalConvertedNormalQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalUnitPurchasePrice;
    }
}