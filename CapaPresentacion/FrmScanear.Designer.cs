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
            this.siticonePictureBox1 = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).BeginInit();
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
            this.lblScanear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblScanear.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanear.Location = new System.Drawing.Point(511, 120);
            this.lblScanear.Name = "lblScanear";
            this.lblScanear.Size = new System.Drawing.Size(334, 110);
            this.lblScanear.TabIndex = 21;
            this.lblScanear.Text = "Scanea el Código de barras";
            this.lblScanear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanear.MouseEnter += new System.EventHandler(this.pictureBoxCamera_MouseEnter);
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxCamera.Location = new System.Drawing.Point(990, 233);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(233, 170);
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
            // siticonePictureBox1
            // 
            this.siticonePictureBox1.BorderRadius = 15;
            this.siticonePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("siticonePictureBox1.Image")));
            this.siticonePictureBox1.ImageRotate = 0F;
            this.siticonePictureBox1.Location = new System.Drawing.Point(448, 233);
            this.siticonePictureBox1.Name = "siticonePictureBox1";
            this.siticonePictureBox1.Size = new System.Drawing.Size(499, 425);
            this.siticonePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.siticonePictureBox1.TabIndex = 26;
            this.siticonePictureBox1.TabStop = false;
            // 
            // FrmScanear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1573, 838);
            this.Controls.Add(this.siticonePictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.pictureBoxCamera);
            this.Controls.Add(this.lblScanear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmScanear";
            this.Text = "FrmScanear";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmScanear_Activated_1);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScanear_FormClosing);
            this.Load += new System.EventHandler(this.FrmScanear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.siticonePictureBox1)).EndInit();
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
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox siticonePictureBox1;
    }
}