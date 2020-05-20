namespace MachineLearningToolv3
{
    partial class web_cam_select
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(web_cam_select));
            this.camdropdown = new System.Windows.Forms.ComboBox();
            this.cam = new System.Windows.Forms.PictureBox();
            this.capturepic = new System.Windows.Forms.PictureBox();
            this.Start = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Capture = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturepic)).BeginInit();
            this.SuspendLayout();
            // 
            // camdropdown
            // 
            this.camdropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camdropdown.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camdropdown.FormattingEnabled = true;
            this.camdropdown.Location = new System.Drawing.Point(380, 53);
            this.camdropdown.Name = "camdropdown";
            this.camdropdown.Size = new System.Drawing.Size(191, 31);
            this.camdropdown.TabIndex = 1;
            this.camdropdown.TabStop = false;
            this.camdropdown.SelectedIndexChanged += new System.EventHandler(this.drivedropdown_SelectedIndexChanged);
            // 
            // cam
            // 
            this.cam.BackColor = System.Drawing.Color.Transparent;
            this.cam.Location = new System.Drawing.Point(46, 99);
            this.cam.Name = "cam";
            this.cam.Size = new System.Drawing.Size(712, 410);
            this.cam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cam.TabIndex = 12;
            this.cam.TabStop = false;
            // 
            // capturepic
            // 
            this.capturepic.Location = new System.Drawing.Point(46, 550);
            this.capturepic.Name = "capturepic";
            this.capturepic.Size = new System.Drawing.Size(67, 55);
            this.capturepic.TabIndex = 14;
            this.capturepic.TabStop = false;
            // 
            // Start
            // 
            this.Start.ActiveBorderThickness = 3;
            this.Start.ActiveCornerRadius = 40;
            this.Start.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.Start.ActiveForecolor = System.Drawing.Color.White;
            this.Start.ActiveLineColor = System.Drawing.Color.White;
            this.Start.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Start.BackColor = System.Drawing.SystemColors.Control;
            this.Start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Start.BackgroundImage")));
            this.Start.ButtonText = "Start";
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.Black;
            this.Start.IdleBorderThickness = 3;
            this.Start.IdleCornerRadius = 40;
            this.Start.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.Start.IdleForecolor = System.Drawing.Color.White;
            this.Start.IdleLineColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(204, 516);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(201, 82);
            this.Start.TabIndex = 15;
            this.Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Capture
            // 
            this.Capture.ActiveBorderThickness = 3;
            this.Capture.ActiveCornerRadius = 40;
            this.Capture.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.Capture.ActiveForecolor = System.Drawing.Color.White;
            this.Capture.ActiveLineColor = System.Drawing.Color.White;
            this.Capture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Capture.BackColor = System.Drawing.SystemColors.Control;
            this.Capture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Capture.BackgroundImage")));
            this.Capture.ButtonText = "Capture";
            this.Capture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Capture.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Capture.ForeColor = System.Drawing.Color.Black;
            this.Capture.IdleBorderThickness = 3;
            this.Capture.IdleCornerRadius = 40;
            this.Capture.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(70)))), ((int)(((byte)(107)))));
            this.Capture.IdleForecolor = System.Drawing.Color.White;
            this.Capture.IdleLineColor = System.Drawing.Color.White;
            this.Capture.Location = new System.Drawing.Point(424, 516);
            this.Capture.Margin = new System.Windows.Forms.Padding(4);
            this.Capture.Name = "Capture";
            this.Capture.Size = new System.Drawing.Size(201, 82);
            this.Capture.TabIndex = 16;
            this.Capture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Capture.Click += new System.EventHandler(this.Capture_Click_1);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(204, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 36);
            this.label5.TabIndex = 32;
            this.label5.Text = "Select Camera";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.UseCompatibleTextRendering = true;
            // 
            // web_cam_select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(808, 617);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Capture);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.capturepic);
            this.Controls.Add(this.cam);
            this.Controls.Add(this.camdropdown);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "web_cam_select";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.web_cam_select_FormClosing);
            this.Load += new System.EventHandler(this.web_cam_select_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capturepic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox camdropdown;
        public System.Windows.Forms.PictureBox cam;
        public System.Windows.Forms.PictureBox capturepic;
        private Bunifu.Framework.UI.BunifuThinButton2 Start;
        private Bunifu.Framework.UI.BunifuThinButton2 Capture;
        private System.Windows.Forms.Label label5;
    }
}