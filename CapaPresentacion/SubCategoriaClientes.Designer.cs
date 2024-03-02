namespace CapaPresentacion
{
    partial class SubCategoriaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubCategoriaClientes));
            this.lblIdCategoria = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.picFoto = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIdCategoria
            // 
            this.lblIdCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCategoria.Location = new System.Drawing.Point(8, 125);
            this.lblIdCategoria.Name = "lblIdCategoria";
            this.lblIdCategoria.Size = new System.Drawing.Size(49, 26);
            this.lblIdCategoria.TabIndex = 29;
            this.lblIdCategoria.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 132);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(170, 26);
            this.lblTitulo.TabIndex = 25;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSubCategoria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 50);
            this.panel1.TabIndex = 28;
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria.Location = new System.Drawing.Point(61, 12);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(49, 26);
            this.lblSubCategoria.TabIndex = 24;
            this.lblSubCategoria.Visible = false;
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.ImageRotate = 0F;
            this.picFoto.Location = new System.Drawing.Point(20, 5);
            this.picFoto.Name = "picFoto";
            this.picFoto.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.picFoto.Size = new System.Drawing.Size(128, 125);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 24;
            this.picFoto.TabStop = false;
            this.picFoto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picFoto_MouseClick);
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(6, 48);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 23);
            this.lblEstado.TabIndex = 27;
            this.lblEstado.Visible = false;
            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(10, 5);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(57, 43);
            this.lblId.TabIndex = 26;
            this.lblId.Visible = false;
            // 
            // SubCategoriaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblIdCategoria);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblId);
            this.Name = "SubCategoriaClientes";
            this.Size = new System.Drawing.Size(170, 208);
            this.Load += new System.EventHandler(this.SubCategoriaClientes_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIdCategoria;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox picFoto;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblSubCategoria;
    }
}
