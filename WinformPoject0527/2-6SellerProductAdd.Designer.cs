namespace WinformPoject0527
{
    partial class SellerProductAdd
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
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuantity = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductQuantity = new System.Windows.Forms.TextBox();
            this.btnproductsetting = new System.Windows.Forms.Button();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(148, 370);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 25);
            this.txtTotal.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 40;
            this.label6.Text = "商品庫存量";
            // 
            // btnQuantity
            // 
            this.btnQuantity.Location = new System.Drawing.Point(281, 395);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.Size = new System.Drawing.Size(125, 42);
            this.btnQuantity.TabIndex = 38;
            this.btnQuantity.Text = "商品進貨";
            this.btnQuantity.UseVisualStyleBackColor = true;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "進貨數量";
            this.label7.Visible = false;
            // 
            // txtProductQuantity
            // 
            this.txtProductQuantity.Location = new System.Drawing.Point(148, 412);
            this.txtProductQuantity.Name = "txtProductQuantity";
            this.txtProductQuantity.Size = new System.Drawing.Size(100, 25);
            this.txtProductQuantity.TabIndex = 28;
            this.txtProductQuantity.Visible = false;
            // 
            // btnproductsetting
            // 
            this.btnproductsetting.Location = new System.Drawing.Point(630, 395);
            this.btnproductsetting.Name = "btnproductsetting";
            this.btnproductsetting.Size = new System.Drawing.Size(125, 42);
            this.btnproductsetting.TabIndex = 30;
            this.btnproductsetting.Text = "商品設定";
            this.btnproductsetting.UseVisualStyleBackColor = true;
            this.btnproductsetting.Click += new System.EventHandler(this.btnproductsetting_Click);
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(148, 68);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(100, 25);
            this.txtProductId.TabIndex = 36;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(148, 224);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(100, 25);
            this.txtProductPrice.TabIndex = 27;
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.Location = new System.Drawing.Point(383, 68);
            this.txtProductDescription.Multiline = true;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(372, 302);
            this.txtProductDescription.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "商品編號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 32;
            this.label4.Text = "商品價格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "商品說明";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(148, 174);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(100, 25);
            this.txtCategoryId.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 34;
            this.label2.Text = "商品分類";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(148, 121);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(100, 25);
            this.txtProductName.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "商品名稱";
            // 
            // SellerProductAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProductQuantity);
            this.Controls.Add(this.btnproductsetting);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.txtProductPrice);
            this.Controls.Add(this.txtProductDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.label1);
            this.Name = "SellerProductAdd";
            this.Text = "SellerProductAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductQuantity;
        private System.Windows.Forms.Button btnproductsetting;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label1;
    }
}