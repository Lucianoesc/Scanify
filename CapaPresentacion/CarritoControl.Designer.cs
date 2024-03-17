namespace CapaPresentacion
{
    partial class CarritoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarritoControl));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picFoto = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.Borrar = new System.Windows.Forms.PictureBox();
            this.txtId = new System.Windows.Forms.Label();
            this.lblOferta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrecioOferta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Borrar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(87, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 38);
            this.lblTitulo.TabIndex = 8;
            this.lblTitulo.Text = "Titulo";
            // 
            // picFoto
            // 
            this.picFoto.Image = ((System.Drawing.Image)(resources.GetObject("picFoto.Image")));
            this.picFoto.ImageRotate = 0F;
            this.picFoto.Location = new System.Drawing.Point(3, 9);
            this.picFoto.Name = "picFoto";
            this.picFoto.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.picFoto.Size = new System.Drawing.Size(78, 75);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 7;
            this.picFoto.TabStop = false;
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.Color.White;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(210, 69);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(49, 15);
            this.lblPrecio.TabIndex = 10;
            this.lblPrecio.Text = "Precio";
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.Color.White;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(162, 69);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(29, 27);
            this.lblCantidad.TabIndex = 11;
            this.lblCantidad.Text = "Cantidad";
            // 
            // Borrar
            // 
            this.Borrar.Image = ((System.Drawing.Image)(resources.GetObject("Borrar.Image")));
            this.Borrar.Location = new System.Drawing.Point(237, 3);
            this.Borrar.Name = "Borrar";
            this.Borrar.Size = new System.Drawing.Size(22, 15);
            this.Borrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Borrar.TabIndex = 12;
            this.Borrar.TabStop = false;
            this.Borrar.Click += new System.EventHandler(this.Borrar_Click);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.White;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(222, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(17, 17);
            this.txtId.TabIndex = 13;
            this.txtId.Visible = false;
            // 
            // lblOferta
            // 
            this.lblOferta.BackColor = System.Drawing.Color.White;
            this.lblOferta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOferta.Location = new System.Drawing.Point(87, 59);
            this.lblOferta.Name = "lblOferta";
            this.lblOferta.Size = new System.Drawing.Size(68, 17);
            this.lblOferta.TabIndex = 14;
            this.lblOferta.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "$";
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(0, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(262, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "___________________________________";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 15);
            this.label2.TabIndex = 44;
            this.label2.Text = "x";
            // 
            // lblPrecioOferta
            // 
            this.lblPrecioOferta.BackColor = System.Drawing.Color.White;
            this.lblPrecioOferta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioOferta.Location = new System.Drawing.Point(88, 67);
            this.lblPrecioOferta.Name = "lblPrecioOferta";
            this.lblPrecioOferta.Size = new System.Drawing.Size(68, 17);
            this.lblPrecioOferta.TabIndex = 45;
            this.lblPrecioOferta.Visible = false;
            // 
            // CarritoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPrecioOferta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblOferta);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.Borrar);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.picFoto);
            this.Name = "CarritoControl";
            this.Size = new System.Drawing.Size(262, 100);
            this.Load += new System.EventHandler(this.CarritoControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Borrar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox picFoto;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.PictureBox Borrar;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Label lblOferta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrecioOferta;
    }
}
