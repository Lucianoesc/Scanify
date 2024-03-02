namespace CapaPresentacion
{
    partial class CategoriasClientes
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriasClientes));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picFoto = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubCategoria2 = new System.Windows.Forms.Label();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.lblIdCategoria = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 98);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(120, 26);
            this.lblTitulo.TabIndex = 19;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.ImageRotate = 0F;
            this.picFoto.Location = new System.Drawing.Point(14, 3);
            this.picFoto.Name = "picFoto";
            this.picFoto.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.picFoto.Size = new System.Drawing.Size(96, 86);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 18;
            this.picFoto.TabStop = false;
            this.picFoto.Click += new System.EventHandler(this.picFoto_Click);
            this.picFoto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picFoto_MouseClick);
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(6, 52);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 23);
            this.lblEstado.TabIndex = 21;
            this.lblEstado.Visible = false;
            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(10, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(57, 43);
            this.lblId.TabIndex = 20;
            this.lblId.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSubCategoria2);
            this.panel1.Controls.Add(this.lblSubCategoria);
            this.panel1.Controls.Add(this.lblIdCategoria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 13);
            this.panel1.TabIndex = 22;
            // 
            // lblSubCategoria2
            // 
            this.lblSubCategoria2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria2.Location = new System.Drawing.Point(61, 12);
            this.lblSubCategoria2.Name = "lblSubCategoria2";
            this.lblSubCategoria2.Size = new System.Drawing.Size(49, 26);
            this.lblSubCategoria2.TabIndex = 25;
            this.lblSubCategoria2.Visible = false;
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria.Location = new System.Drawing.Point(74, 10);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(49, 26);
            this.lblSubCategoria.TabIndex = 24;
            this.lblSubCategoria.Visible = false;
            // 
            // lblIdCategoria
            // 
            this.lblIdCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCategoria.Location = new System.Drawing.Point(33, 10);
            this.lblIdCategoria.Name = "lblIdCategoria";
            this.lblIdCategoria.Size = new System.Drawing.Size(49, 26);
            this.lblIdCategoria.TabIndex = 23;
            this.lblIdCategoria.Visible = false;
            // 
            // CategoriasClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblId);
            this.Name = "CategoriasClientes";
            this.Size = new System.Drawing.Size(120, 137);
            this.Load += new System.EventHandler(this.CategoriasClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox picFoto;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblIdCategoria;
        private System.Windows.Forms.Label lblSubCategoria2;
        private System.Windows.Forms.Label lblSubCategoria;
    }
}
