namespace POS
{
    partial class DamageFrm
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtDamageQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResponsiblePerson = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDamageDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDamage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.cboProduct = new System.Windows.Forms.ComboBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "* Unit Price  :";
            // 
            // txtDamageQty
            // 
            this.txtDamageQty.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.txtDamageQty.Location = new System.Drawing.Point(166, 73);
            this.txtDamageQty.Name = "txtDamageQty";
            this.txtDamageQty.Size = new System.Drawing.Size(116, 27);
            this.txtDamageQty.TabIndex = 5;
            this.txtDamageQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "* Damage Qty:";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.txtReason.Location = new System.Drawing.Point(166, 178);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(515, 89);
            this.txtReason.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label6.Location = new System.Drawing.Point(3, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "* Responsible Person";
            // 
            // txtResponsiblePerson
            // 
            this.txtResponsiblePerson.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.txtResponsiblePerson.Location = new System.Drawing.Point(166, 143);
            this.txtResponsiblePerson.Multiline = true;
            this.txtResponsiblePerson.Name = "txtResponsiblePerson";
            this.txtResponsiblePerson.Size = new System.Drawing.Size(320, 27);
            this.txtResponsiblePerson.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label7.Location = new System.Drawing.Point(3, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "  Reason";
            // 
            // dtpDamageDate
            // 
            this.dtpDamageDate.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.dtpDamageDate.Location = new System.Drawing.Point(166, 108);
            this.dtpDamageDate.Name = "dtpDamageDate";
            this.dtpDamageDate.Size = new System.Drawing.Size(243, 27);
            this.dtpDamageDate.TabIndex = 7;
            this.dtpDamageDate.Value = new System.DateTime(2014, 11, 4, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label8.Location = new System.Drawing.Point(3, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "* Damage Date";
            // 
            // btnDamage
            // 
            this.btnDamage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnDamage.FlatAppearance.BorderSize = 0;
            this.btnDamage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDamage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDamage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDamage.Image = global::POS.Properties.Resources.save_big;
            this.btnDamage.Location = new System.Drawing.Point(478, 307);
            this.btnDamage.Name = "btnDamage";
            this.btnDamage.Size = new System.Drawing.Size(114, 33);
            this.btnDamage.TabIndex = 1;
            this.btnDamage.UseVisualStyleBackColor = true;
            this.btnDamage.Click += new System.EventHandler(this.btnDamage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(202)))), ((int)(((byte)(125)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::POS.Properties.Resources.cancel_big;
            this.btnCancel.Location = new System.Drawing.Point(584, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 33);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.83041F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.16959F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboProduct, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUnitPrice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDamageQty, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtResponsiblePerson, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtpDamageDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtReason, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.98371F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.98643F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.98643F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.98643F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.98643F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.07058F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 270);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "* Product Name :";
            // 
            // cboProduct
            // 
            this.cboProduct.DropDownWidth = 400;
            this.cboProduct.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(166, 5);
            this.cboProduct.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(320, 28);
            this.cboProduct.TabIndex = 1;
            this.cboProduct.SelectedValueChanged += new System.EventHandler(this.cboProduct_SelectedValueChanged);
            this.cboProduct.Leave += new System.EventHandler(this.cboProduct_Leave);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Enabled = false;
            this.txtUnitPrice.Font = new System.Drawing.Font("Zawgyi-One", 9F);
            this.txtUnitPrice.Location = new System.Drawing.Point(166, 38);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(116, 27);
            this.txtUnitPrice.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(18, 317);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "* Mandatory Fileds";
            // 
            // DamageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(714, 348);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDamage);
            this.Name = "DamageFrm";
            this.Text = "Damage";
            this.Load += new System.EventHandler(this.DamageFrm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DamageFrm_MouseMove);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDamageQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResponsiblePerson;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDamageDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDamage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboProduct;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label label13;
    }
}