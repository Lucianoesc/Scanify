namespace CapaPresentacion
{
    partial class CartaControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartaControl));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picFoto = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblId = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblInfoNutricional = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.lblSubCategoria2 = new System.Windows.Forms.Label();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.txtStockLimite = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(220, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(87, 37);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(169, 99);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(15, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(199, 23);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Titulo";
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.ImageRotate = 0F;
            this.picFoto.Location = new System.Drawing.Point(3, 37);
            this.picFoto.Name = "picFoto";
            this.picFoto.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.picFoto.Size = new System.Drawing.Size(78, 75);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 4;
            this.picFoto.TabStop = false;
            this.picFoto.Click += new System.EventHandler(this.picFoto_Click);
            this.picFoto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picFoto_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editarToolStripMenuItem.Image")));
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.borraruno;
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // lblId
            // 
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(3, 115);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(51, 23);
            this.lblId.TabIndex = 8;
            this.lblId.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(30, 113);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(51, 23);
            this.lblCodigo.TabIndex = 9;
            this.lblCodigo.Visible = false;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(86, 113);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(51, 23);
            this.lblCategoria.TabIndex = 10;
            this.lblCategoria.Visible = false;
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(15, 113);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(51, 23);
            this.lblStock.TabIndex = 11;
            this.lblStock.Visible = false;
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioCompra.Location = new System.Drawing.Point(29, 115);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(51, 23);
            this.lblPrecioCompra.TabIndex = 12;
            this.lblPrecioCompra.Visible = false;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioVenta.Location = new System.Drawing.Point(15, 115);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(51, 23);
            this.lblPrecioVenta.TabIndex = 13;
            this.lblPrecioVenta.Visible = false;
            // 
            // lblInfoNutricional
            // 
            this.lblInfoNutricional.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoNutricional.Location = new System.Drawing.Point(30, 113);
            this.lblInfoNutricional.Name = "lblInfoNutricional";
            this.lblInfoNutricional.Size = new System.Drawing.Size(51, 23);
            this.lblInfoNutricional.TabIndex = 14;
            this.lblInfoNutricional.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(46, 115);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 23);
            this.lblEstado.TabIndex = 15;
            this.lblEstado.Visible = false;
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria.Location = new System.Drawing.Point(104, 64);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(51, 23);
            this.lblSubCategoria.TabIndex = 16;
            this.lblSubCategoria.Visible = false;
            // 
            // lblSubCategoria2
            // 
            this.lblSubCategoria2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria2.Location = new System.Drawing.Point(112, 72);
            this.lblSubCategoria2.Name = "lblSubCategoria2";
            this.lblSubCategoria2.Size = new System.Drawing.Size(51, 23);
            this.lblSubCategoria2.TabIndex = 17;
            this.lblSubCategoria2.Visible = false;
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockMinimo.Location = new System.Drawing.Point(120, 80);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(51, 23);
            this.lblStockMinimo.TabIndex = 18;
            this.lblStockMinimo.Visible = false;
            // 
            // txtStockLimite
            // 
            this.txtStockLimite.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockLimite.Location = new System.Drawing.Point(128, 88);
            this.txtStockLimite.Name = "txtStockLimite";
            this.txtStockLimite.Size = new System.Drawing.Size(51, 23);
            this.txtStockLimite.TabIndex = 19;
            this.txtStockLimite.Visible = false;
            // 
            // CartaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtStockLimite);
            this.Controls.Add(this.lblStockMinimo);
            this.Controls.Add(this.lblSubCategoria2);
            this.Controls.Add(this.lblSubCategoria);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblInfoNutricional);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblPrecioCompra);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.picFoto);
            this.Name = "CartaControl";
            this.Size = new System.Drawing.Size(259, 150);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblTitulo;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox picFoto;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblInfoNutricional;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblSubCategoria;
        private System.Windows.Forms.Label lblSubCategoria2;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.Label lblStockLimite;
        private System.Windows.Forms.Label txtStockLimite;
    }
}
