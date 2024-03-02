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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timerCarrusel = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblNegocio = new System.Windows.Forms.Label();
            this.picOfertas = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.picNegocio = new Siticone.Desktop.UI.WinForms.SiticonePictureBox();
            this.siticoneButton1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOfertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNegocio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.picNegocio);
            this.panel1.Controls.Add(this.picOfertas);
            this.panel1.Controls.Add(this.lblNegocio);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 1080);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(117)))), ((int)(((byte)(74)))));
            this.panel3.Controls.Add(this.siticoneButton1);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 931);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1920, 149);
            this.panel3.TabIndex = 1;
            this.panel3.Click += new System.EventHandler(this.siticoneTextBox1_Click);
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // timerCarrusel
            // 
            this.timerCarrusel.Tick += new System.EventHandler(this.timerCarrusel_Tick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(141, 149);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1720, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 149);
            this.panel4.TabIndex = 2;
            this.panel4.Click += new System.EventHandler(this.siticoneTextBox1_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(117)))), ((int)(((byte)(74)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(141, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1579, 27);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(141, 128);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1579, 21);
            this.panel6.TabIndex = 4;
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
            // picOfertas
            // 
            this.picOfertas.BackColor = System.Drawing.Color.White;
            this.picOfertas.BorderRadius = 20;
            this.picOfertas.FillColor = System.Drawing.Color.Transparent;
            this.picOfertas.ImageRotate = 0F;
            this.picOfertas.Location = new System.Drawing.Point(241, 168);
            this.picOfertas.Name = "picOfertas";
            this.picOfertas.Size = new System.Drawing.Size(1558, 697);
            this.picOfertas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOfertas.TabIndex = 4;
            this.picOfertas.TabStop = false;
            this.picOfertas.Click += new System.EventHandler(this.picOfertas_Click_1);
            // 
            // picNegocio
            // 
            this.picNegocio.BorderRadius = 20;
            this.picNegocio.FillColor = System.Drawing.Color.Transparent;
            this.picNegocio.ImageRotate = 0F;
            this.picNegocio.Location = new System.Drawing.Point(394, 12);
            this.picNegocio.Name = "picNegocio";
            this.picNegocio.Size = new System.Drawing.Size(230, 128);
            this.picNegocio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNegocio.TabIndex = 5;
            this.picNegocio.TabStop = false;
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.BorderRadius = 15;
            this.siticoneButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.siticoneButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.siticoneButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.siticoneButton1.FillColor = System.Drawing.Color.White;
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI Emoji", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(117)))), ((int)(((byte)(74)))));
            this.siticoneButton1.Location = new System.Drawing.Point(394, 33);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.Size = new System.Drawing.Size(1082, 71);
            this.siticoneButton1.TabIndex = 5;
            this.siticoneButton1.Text = ">>> PRESIONE PARA COMENZAR <<<";
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
            this.Load += new System.EventHandler(this.FrmPantallaPrincipalClientes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOfertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNegocio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timerCarrusel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNegocio;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox picNegocio;
        private Siticone.Desktop.UI.WinForms.SiticonePictureBox picOfertas;
        private Siticone.Desktop.UI.WinForms.SiticoneButton siticoneButton1;
    }
}