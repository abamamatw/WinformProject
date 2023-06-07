namespace WinformPoject0527
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonuser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonseller = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonexit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonuser,
            this.toolStripButtonseller,
            this.toolStripButtonexit});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(800, 39);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonuser
            // 
            this.toolStripButtonuser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonuser.Image")));
            this.toolStripButtonuser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonuser.Name = "toolStripButtonuser";
            this.toolStripButtonuser.Size = new System.Drawing.Size(105, 36);
            this.toolStripButtonuser.Text = "我是買家";
            this.toolStripButtonuser.Click += new System.EventHandler(this.toolStripButtonuser_Click);
            // 
            // toolStripButtonseller
            // 
            this.toolStripButtonseller.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonseller.Image")));
            this.toolStripButtonseller.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonseller.Name = "toolStripButtonseller";
            this.toolStripButtonseller.Size = new System.Drawing.Size(105, 36);
            this.toolStripButtonseller.Text = "我是賣家";
            this.toolStripButtonseller.Click += new System.EventHandler(this.toolStripButtonseller_Click);
            // 
            // toolStripButtonexit
            // 
            this.toolStripButtonexit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonexit.Image")));
            this.toolStripButtonexit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonexit.Name = "toolStripButtonexit";
            this.toolStripButtonexit.Size = new System.Drawing.Size(75, 36);
            this.toolStripButtonexit.Text = "離開";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip2);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonuser;
        private System.Windows.Forms.ToolStripButton toolStripButtonseller;
        private System.Windows.Forms.ToolStripButton toolStripButtonexit;
    }
}