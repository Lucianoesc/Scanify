namespace CapaPresentacion
{
    partial class FrmPantallaPrincipalClientes
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
            this.timerCarrusel = new System.Windows.Forms.Timer(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.picNegocio = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.lblNegocio = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picOfertas = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.siticoneAnimateWindow1 = new Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow(this.components);
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNegocio)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOfertas)).BeginInit();
            this.SuspendLayout();
            // 
            // timerCarrusel
            // 
            this.timerCarrusel.Tick += new System.EventHandler(this.timerCarrusel_Tick);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.picNegocio);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1920, 140);
            this.panel8.TabIndex = 7;
            // 
            // picNegocio
            // 
            this.picNegocio.BorderRadius = 20;
            this.picNegocio.FillColor = System.Drawing.Color.Transparent;
            this.picNegocio.ImageRotate = 0F;
            this.picNegocio.Location = new System.Drawing.Point(311, 0);
            this.picNegocio.Name = "picNegocio";
            this.picNegocio.Size = new System.Drawing.Size(230, 128);
            this.picNegocio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNegocio.TabIndex = 5;
            this.picNegocio.TabStop = false;
            // 
            // lblNegocio
            // 
            this.lblNegocio.AutoSize = true;
            this.lblNegocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNegocio.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblNegocio.Location = new System.Drawing.Point(665, 49);
            this.lblNegocio.Name = "lblNegocio";
            this.lblNegocio.Size = new System.Drawing.Size(0, 55);
            this.lblNegocio.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 140);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(88, 940);
            this.panel7.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(420, 584);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 100);
            this.panel9.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(1839, 140);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(81, 940);
            this.panel10.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(99)))), ((int)(((byte)(146)))));
            this.panel3.Controls.Add(this.siticoneButton1);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(88, 954);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1751, 126);
            this.panel3.TabIndex = 1;
            this.panel3.Click += new System.EventHandler(this.siticoneTextBox1_Click);
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.BorderRadius = 15;
            this.siticoneButton1.DefaultAutoSize = true;
            this.siticoneButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siticoneButton1.FillColor = System.Drawing.Color.White;
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI Emoji", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(117)))), ((int)(((byte)(74)))));
            this.siticoneButton1.Location = new System.Drawing.Point(23, 27);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.Size = new System.Drawing.Size(1703, 78);
            this.siticoneButton1.TabIndex = 5;
            this.siticoneButton1.Text = ">>> PRESIONE PARA COMENZAR <<<";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(23, 105);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1703, 21);
            this.panel6.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(99)))), ((int)(((byte)(146)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(23, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1703, 27);
            this.panel5.TabIndex = 3;
            this.panel5.Click += new System.EventHandler(this.picOfertas_Click_2);
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1726, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(25, 126);
            this.panel4.TabIndex = 2;
            this.panel4.Click += new System.EventHandler(this.siticoneTextBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(99)))), ((int)(((byte)(146)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(23, 126);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(99)))), ((int)(((byte)(146)))));
            this.panel1.Controls.Add(this.picOfertas);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.lblNegocio);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1080);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.picOfertas_Click_2);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picOfertas
            // 
            this.picOfertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(99)))), ((int)(((byte)(146)))));
            this.picOfertas.BorderRadius = 20;
            this.picOfertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOfertas.FillColor = System.Drawing.Color.Transparent;
            this.picOfertas.ImageRotate = 0F;
            this.picOfertas.Location = new System.Drawing.Point(88, 140);
            this.picOfertas.Name = "picOfertas";
            this.picOfertas.Size = new System.Drawing.Size(1751, 814);
            this.picOfertas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOfertas.TabIndex = 4;
            this.picOfertas.TabStop = false;
            this.picOfertas.Click += new System.EventHandler(this.picOfertas_Click_2);
            // 
            // FrmPantallaPrincipalClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPantallaPrincipalClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPantallaPrincipalClientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPantallaPrincipalClientes_FormClosing);
            this.Load += new System.EventHandler(this.FrmPantallaPrincipalClientes_Load);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNegocio)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOfertas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerCarrusel;
        private System.Windows.Forms.Panel panel8;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox picNegocio;
        private System.Windows.Forms.Label lblNegocio;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox picOfertas;
        private Siticone.Desktop.UI.WinForms.SiticoneAnimateWindow siticoneAnimateWindow1;
    }
}