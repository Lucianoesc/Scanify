namespace CapaPresentacion
{
    partial class FrmScanear
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScanear));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblScanear = new System.Windows.Forms.Label();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.siticonePictureBox1 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.siticonePictureBox3 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.siticonePictureBox4 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.siticonePictureBox5 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.siticonePictureBox6 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(105, 77);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lblScanear
            // 
            this.lblScanear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScanear.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanear.ForeColor = System.Drawing.Color.White;
            this.lblScanear.Location = new System.Drawing.Point(519, 339);
            this.lblScanear.Name = "lblScanear";
            this.lblScanear.Size = new System.Drawing.Size(544, 110);
            this.lblScanear.TabIndex = 21;
            this.lblScanear.Text = "Scanea el Código de barras";
            this.lblScanear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanear.Click += new System.EventHandler(this.lblScanear_Click);
            this.lblScanear.MouseEnter += new System.EventHandler(this.pictureBoxCamera_MouseEnter);
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCamera.Location = new System.Drawing.Point(655, 92);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(232, 242);
            this.pictureBoxCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCamera.TabIndex = 22;
            this.pictureBoxCamera.TabStop = false;
            this.pictureBoxCamera.MouseEnter += new System.EventHandler(this.pictureBoxCamera_MouseEnter);
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(1386, 788);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoBarras.TabIndex = 24;
            this.txtCodigoBarras.Visible = false;
            this.txtCodigoBarras.TextChanged += new System.EventHandler(this.txtCodigoBarras_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 761);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1573, 77);
            this.panel1.TabIndex = 25;
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            // 
            // siticonePictureBox1
            // 
            this.siticonePictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.siticonePictureBox1.BorderRadius = 20;
            this.siticonePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox1.Image")));
            this.siticonePictureBox1.ImageRotate = 0F;
            this.siticonePictureBox1.Location = new System.Drawing.Point(593, 391);
            this.siticonePictureBox1.Name = "siticonePictureBox1";
            this.siticonePictureBox1.Size = new System.Drawing.Size(375, 410);
            this.siticonePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox1.TabIndex = 26;
            this.siticonePictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(620, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 89);
            this.label1.TabIndex = 27;
            this.label1.Text = "Scanify";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // siticonePictureBox3
            // 
            this.siticonePictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.siticonePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox3.Image")));
            this.siticonePictureBox3.ImageFlip = Siticone.Desktop.UI.WinForms.Enums.FlipOrientation.Horizontal;
            this.siticonePictureBox3.ImageRotate = 0F;
            this.siticonePictureBox3.Location = new System.Drawing.Point(260, 590);
            this.siticonePictureBox3.Name = "siticonePictureBox3";
            this.siticonePictureBox3.Size = new System.Drawing.Size(425, 210);
            this.siticonePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox3.TabIndex = 29;
            this.siticonePictureBox3.TabStop = false;
            this.siticonePictureBox3.Click += new System.EventHandler(this.siticonePictureBox3_Click_1);
            // 
            // siticonePictureBox4
            // 
            this.siticonePictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.siticonePictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox4.Image")));
            this.siticonePictureBox4.ImageRotate = 0F;
            this.siticonePictureBox4.Location = new System.Drawing.Point(901, 590);
            this.siticonePictureBox4.Name = "siticonePictureBox4";
            this.siticonePictureBox4.Size = new System.Drawing.Size(425, 210);
            this.siticonePictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox4.TabIndex = 30;
            this.siticonePictureBox4.TabStop = false;
            // 
            // siticonePictureBox5
            // 
            this.siticonePictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox5.Image")));
            this.siticonePictureBox5.ImageRotate = 0F;
            this.siticonePictureBox5.Location = new System.Drawing.Point(260, 92);
            this.siticonePictureBox5.Name = "siticonePictureBox5";
            this.siticonePictureBox5.Size = new System.Drawing.Size(425, 210);
            this.siticonePictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox5.TabIndex = 31;
            this.siticonePictureBox5.TabStop = false;
            // 
            // siticonePictureBox6
            // 
            this.siticonePictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siticonePictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox6.Image")));
            this.siticonePictureBox6.ImageFlip = Siticone.Desktop.UI.WinForms.Enums.FlipOrientation.Vertical;
            this.siticonePictureBox6.ImageRotate = 0F;
            this.siticonePictureBox6.Location = new System.Drawing.Point(901, 96);
            this.siticonePictureBox6.Name = "siticonePictureBox6";
            this.siticonePictureBox6.Size = new System.Drawing.Size(425, 210);
            this.siticonePictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.siticonePictureBox6.TabIndex = 32;
            this.siticonePictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(526, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(489, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // FrmScanear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(192)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(1573, 838);
            this.Controls.Add(this.pictureBoxCamera);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.siticonePictureBox1);
            this.Controls.Add(this.siticonePictureBox4);
            this.Controls.Add(this.siticonePictureBox3);
            this.Controls.Add(this.siticonePictureBox6);
            this.Controls.Add(this.siticonePictureBox5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.lblScanear);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScanear";
            this.Text = "FrmScanear";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmScanear_Activated_1);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScanear_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmScanear_FormClosed);
            this.Load += new System.EventHandler(this.FrmScanear_Load);
            this.Click += new System.EventHandler(this.FrmScanear_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblScanear;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer2;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox1;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox3;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox4;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox5;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}