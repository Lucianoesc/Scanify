namespace CapaPresentacion
{
    partial class FrmBusquedaCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusquedaCategoria));
            this.flowpanelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblSubCategoria2 = new System.Windows.Forms.Label();
            this.lblSiguienteSubCat2 = new System.Windows.Forms.Label();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.lblSiguienteSubCat = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblsiguienteproductos = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.flowpanelCategorias = new System.Windows.Forms.FlowLayoutPanel();
            this.timerCarrucel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowpanelProductos
            // 
            this.flowpanelProductos.AutoScroll = true;
            this.flowpanelProductos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowpanelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowpanelProductos.Location = new System.Drawing.Point(155, 70);
            this.flowpanelProductos.Name = "flowpanelProductos";
            this.flowpanelProductos.Size = new System.Drawing.Size(1231, 896);
            this.flowpanelProductos.TabIndex = 0;
            this.flowpanelProductos.Click += new System.EventHandler(this.flowpanelProductos_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(86, 60);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 10);
            this.panel1.TabIndex = 36;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 966);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1386, 60);
            this.panel2.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblSubCategoria2);
            this.panel4.Controls.Add(this.lblSiguienteSubCat2);
            this.panel4.Controls.Add(this.lblSubCategoria);
            this.panel4.Controls.Add(this.lblSiguienteSubCat);
            this.panel4.Controls.Add(this.lblCategoria);
            this.panel4.Controls.Add(this.lblsiguienteproductos);
            this.panel4.Controls.Add(this.lblProductos);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1386, 60);
            this.panel4.TabIndex = 39;
            // 
            // lblSubCategoria2
            // 
            this.lblSubCategoria2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSubCategoria2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria2.Location = new System.Drawing.Point(684, 0);
            this.lblSubCategoria2.Name = "lblSubCategoria2";
            this.lblSubCategoria2.Size = new System.Drawing.Size(225, 60);
            this.lblSubCategoria2.TabIndex = 37;
            this.lblSubCategoria2.Text = "SubCategoria2";
            this.lblSubCategoria2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubCategoria2.Visible = false;
            this.lblSubCategoria2.Click += new System.EventHandler(this.lblSubCategoria2_Click_1);
            // 
            // lblSiguienteSubCat2
            // 
            this.lblSiguienteSubCat2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSiguienteSubCat2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiguienteSubCat2.Location = new System.Drawing.Point(640, 0);
            this.lblSiguienteSubCat2.Name = "lblSiguienteSubCat2";
            this.lblSiguienteSubCat2.Size = new System.Drawing.Size(44, 60);
            this.lblSiguienteSubCat2.TabIndex = 39;
            this.lblSiguienteSubCat2.Text = ">";
            this.lblSiguienteSubCat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSiguienteSubCat2.Visible = false;
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSubCategoria.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria.Location = new System.Drawing.Point(458, 0);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(182, 60);
            this.lblSubCategoria.TabIndex = 36;
            this.lblSubCategoria.Text = "SubCategoria";
            this.lblSubCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubCategoria.Visible = false;
            this.lblSubCategoria.Click += new System.EventHandler(this.lblSubCategoria_Click_1);
            // 
            // lblSiguienteSubCat
            // 
            this.lblSiguienteSubCat.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSiguienteSubCat.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiguienteSubCat.Location = new System.Drawing.Point(414, 0);
            this.lblSiguienteSubCat.Name = "lblSiguienteSubCat";
            this.lblSiguienteSubCat.Size = new System.Drawing.Size(44, 60);
            this.lblSiguienteSubCat.TabIndex = 38;
            this.lblSiguienteSubCat.Text = ">";
            this.lblSiguienteSubCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSiguienteSubCat.Visible = false;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCategoria.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(226, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(188, 60);
            this.lblCategoria.TabIndex = 35;
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCategoria.Visible = false;
            this.lblCategoria.Click += new System.EventHandler(this.lblCategoria_Click_1);
            // 
            // lblsiguienteproductos
            // 
            this.lblsiguienteproductos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblsiguienteproductos.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsiguienteproductos.Location = new System.Drawing.Point(182, 0);
            this.lblsiguienteproductos.Name = "lblsiguienteproductos";
            this.lblsiguienteproductos.Size = new System.Drawing.Size(44, 60);
            this.lblsiguienteproductos.TabIndex = 41;
            this.lblsiguienteproductos.Text = ">";
            this.lblsiguienteproductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblsiguienteproductos.Visible = false;
            this.lblsiguienteproductos.Click += new System.EventHandler(this.lblsiguienteproductos_Click);
            // 
            // lblProductos
            // 
            this.lblProductos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProductos.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(0, 0);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(182, 60);
            this.lblProductos.TabIndex = 40;
            this.lblProductos.Text = "Productos";
            this.lblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProductos.Click += new System.EventHandler(this.lblProductos_Click_1);
            // 
            // flowpanelCategorias
            // 
            this.flowpanelCategorias.AutoScroll = true;
            this.flowpanelCategorias.BackColor = System.Drawing.Color.White;
            this.flowpanelCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowpanelCategorias.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanelCategorias.Location = new System.Drawing.Point(0, 70);
            this.flowpanelCategorias.Name = "flowpanelCategorias";
            this.flowpanelCategorias.Size = new System.Drawing.Size(155, 896);
            this.flowpanelCategorias.TabIndex = 40;
            this.flowpanelCategorias.Paint += new System.Windows.Forms.PaintEventHandler(this.flowpanelCategorias_Paint);
            // 
            // timerCarrucel
            // 
            this.timerCarrucel.Tick += new System.EventHandler(this.timerCarrucel_Tick);
            // 
            // FrmBusquedaCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 1026);
            this.Controls.Add(this.flowpanelProductos);
            this.Controls.Add(this.flowpanelCategorias);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBusquedaCategoria";
            this.Text = "FrmBusquedaCategoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBusquedaCategoria_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBusquedaCategoria_FormClosed);
            this.Load += new System.EventHandler(this.FrmBusquedaCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowpanelProductos;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowpanelCategorias;
        private System.Windows.Forms.Label lblSubCategoria2;
        private System.Windows.Forms.Label lblSubCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblSiguienteSubCat2;
        private System.Windows.Forms.Label lblSiguienteSubCat;
        private System.Windows.Forms.Label lblsiguienteproductos;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Timer timerCarrucel;
    }
}