﻿namespace POS
{
    partial class RefundList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefundList));
            this.dgvRefundList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefundList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRefundList
            // 
            this.dgvRefundList.AllowUserToAddRows = false;
            this.dgvRefundList.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRefundList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRefundList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefundList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.colDelete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRefundList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRefundList.Location = new System.Drawing.Point(3, 56);
            this.dgvRefundList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRefundList.Name = "dgvRefundList";
            this.dgvRefundList.RowHeadersVisible = false;
            this.dgvRefundList.Size = new System.Drawing.Size(830, 571);
            this.dgvRefundList.TabIndex = 9;
            this.dgvRefundList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefundList_CellClick);
            this.dgvRefundList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRefundList_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Refund Id";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Time";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Sale Person";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Amount";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Text = "View Detail";
            this.Column7.UseColumnTextForLinkValue = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForLinkValue = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(389, 21);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 27);
            this.dtpTo.TabIndex = 8;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(350, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(61, 21);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 27);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Zawgyi-One", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // RefundList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(836, 632);
            this.Controls.Add(this.dgvRefundList);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Zawgyi-One", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RefundList";
            this.Text = "Refund List";
            this.Load += new System.EventHandler(this.RefundList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefundList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRefundList;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn colDelete;
    }
}