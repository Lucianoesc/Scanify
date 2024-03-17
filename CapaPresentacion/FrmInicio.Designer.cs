namespace CapaPresentacion
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.timConsumidor = new System.Windows.Forms.Timer(this.components);
            this.timEmpleados = new System.Windows.Forms.Timer(this.components);
            this.timAyuda = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picAyuda = new System.Windows.Forms.PictureBox();
            this.picEmpleado = new System.Windows.Forms.PictureBox();
            this.picConsumidor = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAyuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConsumidor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // timConsumidor
            // 
            this.timConsumidor.Interval = 10;
            this.timConsumidor.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timEmpleados
            // 
            this.timEmpleados.Interval = 10;
            this.timEmpleados.Tick += new System.EventHandler(this.timEmpleados_Tick);
            // 
            // timAyuda
            // 
            this.timAyuda.Interval = 10;
            this.timAyuda.Tick += new System.EventHandler(this.timAyuda_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.LogoOriginalScanify;
            this.pictureBox2.Location = new System.Drawing.Point(0, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1386, 140);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // picAyuda
            // 
            this.picAyuda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picAyuda.Image = global::CapaPresentacion.Properties.Resources.BtnAyuda;
            this.picAyuda.Location = new System.Drawing.Point(953, 242);
            this.picAyuda.Name = "picAyuda";
            this.picAyuda.Size = new System.Drawing.Size(441, 335);
            this.picAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAyuda.TabIndex = 2;
            this.picAyuda.TabStop = false;
            this.picAyuda.Click += new System.EventHandler(this.picAyuda_Click);
            this.picAyuda.MouseEnter += new System.EventHandler(this.picAyuda_MouseEnter);
            this.picAyuda.MouseLeave += new System.EventHandler(this.picAyuda_MouseLeave);
            // 
            // picEmpleado
            // 
            this.picEmpleado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picEmpleado.Image = global::CapaPresentacion.Properties.Resources.BtnEmpleados;
            this.picEmpleado.Location = new System.Drawing.Point(492, 242);
            this.picEmpleado.Name = "picEmpleado";
            this.picEmpleado.Size = new System.Drawing.Size(435, 335);
            this.picEmpleado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEmpleado.TabIndex = 1;
            this.picEmpleado.TabStop = false;
            this.picEmpleado.DoubleClick += new System.EventHandler(this.picEmpleado_DoubleClick);
            this.picEmpleado.MouseEnter += new System.EventHandler(this.picEmpleado_MouseEnter);
            this.picEmpleado.MouseLeave += new System.EventHandler(this.picEmpleado_MouseLeave);
            // 
            // picConsumidor
            // 
            this.picConsumidor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picConsumidor.Image = global::CapaPresentacion.Properties.Resources.BtnConsumidores;
            this.picConsumidor.Location = new System.Drawing.Point(12, 199);
            this.picConsumidor.Name = "picConsumidor";
            this.picConsumidor.Size = new System.Drawing.Size(456, 427);
            this.picConsumidor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picConsumidor.TabIndex = 0;
            this.picConsumidor.TabStop = false;
            this.picConsumidor.Click += new System.EventHandler(this.picConsumidor_Click);
            this.picConsumidor.DoubleClick += new System.EventHandler(this.picConsumidor_DoubleClick);
            this.picConsumidor.MouseEnter += new System.EventHandler(this.picConsumidor_MouseEnter);
            this.picConsumidor.MouseLeave += new System.EventHandler(this.picConsumidor_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 14);
            this.panel1.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageRotate = 0F;
            this.btnSalir.Location = new System.Drawing.Point(1349, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(37, 46);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalir.TabIndex = 5;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.siticonePictureBox1_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1386, 650);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picConsumidor);
            this.Controls.Add(this.picAyuda);
            this.Controls.Add(this.picEmpleado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInicio_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInicio_FormClosed);
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAyuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConsumidor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picConsumidor;
        private System.Windows.Forms.PictureBox picEmpleado;
        private System.Windows.Forms.PictureBox picAyuda;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timConsumidor;
        private System.Windows.Forms.Timer timEmpleados;
        private System.Windows.Forms.Timer timAyuda;
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox btnSalir;
    }
}