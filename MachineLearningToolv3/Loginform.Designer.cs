namespace MachineLearningToolv3
{
    partial class Loginform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginform));
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.usernameans = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.passwordans = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.loginbutton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logincred = new System.Windows.Forms.Label();
            this.loginerror = new System.Windows.Forms.Label();
            this.cancelbutton = new Bunifu.Framework.UI.BunifuThinButton2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(104, 260);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(99, 28);
            this.username.TabIndex = 0;
            this.username.Text = "Username";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(104, 337);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(93, 28);
            this.password.TabIndex = 1;
            this.password.Text = "Password";
            // 
            // usernameans
            // 
            this.usernameans.BorderColor = System.Drawing.Color.SeaGreen;
            this.usernameans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameans.Location = new System.Drawing.Point(103, 297);
            this.usernameans.Name = "usernameans";
            this.usernameans.Size = new System.Drawing.Size(358, 27);
            this.usernameans.TabIndex = 2;
            this.usernameans.TabStop = false;
            this.usernameans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameans_KeyDown);
            // 
            // passwordans
            // 
            this.passwordans.BorderColor = System.Drawing.Color.SeaGreen;
            this.passwordans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordans.Location = new System.Drawing.Point(103, 368);
            this.passwordans.Name = "passwordans";
            this.passwordans.Size = new System.Drawing.Size(358, 27);
            this.passwordans.TabIndex = 3;
            this.passwordans.TabStop = false;
            this.passwordans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordans_KeyDown);
            // 
            // loginbutton
            // 
            this.loginbutton.ActiveBorderThickness = 3;
            this.loginbutton.ActiveCornerRadius = 30;
            this.loginbutton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.loginbutton.ActiveForecolor = System.Drawing.Color.White;
            this.loginbutton.ActiveLineColor = System.Drawing.Color.White;
            this.loginbutton.AllowDrop = true;
            this.loginbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.loginbutton.BackColor = System.Drawing.SystemColors.Control;
            this.loginbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loginbutton.BackgroundImage")));
            this.loginbutton.ButtonText = "Login";
            this.loginbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginbutton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbutton.ForeColor = System.Drawing.Color.Black;
            this.loginbutton.IdleBorderThickness = 3;
            this.loginbutton.IdleCornerRadius = 30;
            this.loginbutton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.loginbutton.IdleForecolor = System.Drawing.Color.White;
            this.loginbutton.IdleLineColor = System.Drawing.Color.White;
            this.loginbutton.Location = new System.Drawing.Point(94, 435);
            this.loginbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(179, 65);
            this.loginbutton.TabIndex = 25;
            this.loginbutton.TabStop = false;
            this.loginbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(199, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // logincred
            // 
            this.logincred.AutoSize = true;
            this.logincred.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logincred.Location = new System.Drawing.Point(161, 194);
            this.logincred.Name = "logincred";
            this.logincred.Size = new System.Drawing.Size(231, 38);
            this.logincred.TabIndex = 27;
            this.logincred.Text = "Login Credentials";
            // 
            // loginerror
            // 
            this.loginerror.AutoSize = true;
            this.loginerror.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginerror.ForeColor = System.Drawing.Color.Red;
            this.loginerror.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loginerror.Location = new System.Drawing.Point(133, 410);
            this.loginerror.Name = "loginerror";
            this.loginerror.Size = new System.Drawing.Size(14, 23);
            this.loginerror.TabIndex = 28;
            this.loginerror.Text = "l";
            // 
            // cancelbutton
            // 
            this.cancelbutton.ActiveBorderThickness = 3;
            this.cancelbutton.ActiveCornerRadius = 30;
            this.cancelbutton.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.cancelbutton.ActiveForecolor = System.Drawing.Color.White;
            this.cancelbutton.ActiveLineColor = System.Drawing.Color.White;
            this.cancelbutton.AllowDrop = true;
            this.cancelbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cancelbutton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelbutton.BackgroundImage")));
            this.cancelbutton.ButtonText = "Cancel";
            this.cancelbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelbutton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbutton.ForeColor = System.Drawing.Color.Black;
            this.cancelbutton.IdleBorderThickness = 3;
            this.cancelbutton.IdleCornerRadius = 30;
            this.cancelbutton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.cancelbutton.IdleForecolor = System.Drawing.Color.White;
            this.cancelbutton.IdleLineColor = System.Drawing.Color.White;
            this.cancelbutton.Location = new System.Drawing.Point(289, 435);
            this.cancelbutton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(179, 65);
            this.cancelbutton.TabIndex = 29;
            this.cancelbutton.TabStop = false;
            this.cancelbutton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // Loginform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 546);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.loginerror);
            this.Controls.Add(this.logincred);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.passwordans);
            this.Controls.Add(this.usernameans);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loginform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login credentials";
            this.Load += new System.EventHandler(this.Loginform_Load);
            this.VisibleChanged += new System.EventHandler(this.Loginform_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox usernameans;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox passwordans;
        private Bunifu.Framework.UI.BunifuThinButton2 loginbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label logincred;
        private System.Windows.Forms.Label loginerror;
        private Bunifu.Framework.UI.BunifuThinButton2 cancelbutton;
    }
}