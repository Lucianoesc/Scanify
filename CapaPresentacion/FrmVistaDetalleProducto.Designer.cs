namespace CapaPresentacion
{
    partial class FrmVistaDetalleProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVistaDetalleProducto));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPedirStock = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblpreciodescuento = new System.Windows.Forms.Label();
            this.lblcantidad = new System.Windows.Forms.Label();
            this.btnsuma = new System.Windows.Forms.PictureBox();
            this.btnresta = new System.Windows.Forms.PictureBox();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.Label();
            this.lblOferta = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTextprecio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.incrementimer = new System.Windows.Forms.Timer(this.components);
            this.decrementimer = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.pictureBoxCamera = new System.Windows.Forms.PictureBox();
            this.scanDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.panelCarrito = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCabeceraCarrito = new System.Windows.Forms.Panel();
            this.txtTotalPagar = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panelTotalCarrito = new System.Windows.Forms.Panel();
            this.lblSubCategoria2 = new System.Windows.Forms.Label();
            this.lblSiguienteSubCat2 = new System.Windows.Forms.Label();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.lblSiguienteSubCat = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnsuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnresta)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).BeginInit();
            this.panelCarrito.SuspendLayout();
            this.panelCabeceraCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.lblSubCategoria2);
            this.panel1.Controls.Add(this.lblSiguienteSubCat2);
            this.panel1.Controls.Add(this.lblSubCategoria);
            this.panel1.Controls.Add(this.lblSiguienteSubCat);
            this.panel1.Controls.Add(this.lblCategoria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1347, 49);
            this.panel1.TabIndex = 0;
            this.panel1.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(107, 66);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // picFoto
            // 
            this.picFoto.Location = new System.Drawing.Point(2, 55);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(543, 470);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 1;
            this.picFoto.TabStop = false;
            this.picFoto.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.btnPedirStock);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.lblpreciodescuento);
            this.panel2.Controls.Add(this.lblcantidad);
            this.panel2.Controls.Add(this.btnsuma);
            this.panel2.Controls.Add(this.btnresta);
            this.panel2.Controls.Add(this.txtCantidad);
            this.panel2.Controls.Add(this.txtPrecio);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Location = new System.Drawing.Point(551, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 420);
            this.panel2.TabIndex = 2;
            this.panel2.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // btnPedirStock
            // 
            this.btnPedirStock.Location = new System.Drawing.Point(329, 177);
            this.btnPedirStock.Name = "btnPedirStock";
            this.btnPedirStock.Size = new System.Drawing.Size(75, 23);
            this.btnPedirStock.TabIndex = 43;
            this.btnPedirStock.Text = "Pedir stock";
            this.btnPedirStock.UseVisualStyleBackColor = true;
            this.btnPedirStock.Click += new System.EventHandler(this.btnPedirStock_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(248, 177);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 42;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // lblpreciodescuento
            // 
            this.lblpreciodescuento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblpreciodescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblpreciodescuento.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblpreciodescuento.ForeColor = System.Drawing.Color.YellowGreen;
            this.lblpreciodescuento.Location = new System.Drawing.Point(8, 140);
            this.lblpreciodescuento.Name = "lblpreciodescuento";
            this.lblpreciodescuento.Size = new System.Drawing.Size(149, 30);
            this.lblpreciodescuento.TabIndex = 36;
            this.lblpreciodescuento.Visible = false;
            // 
            // lblcantidad
            // 
            this.lblcantidad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblcantidad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblcantidad.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcantidad.Location = new System.Drawing.Point(137, 219);
            this.lblcantidad.Name = "lblcantidad";
            this.lblcantidad.Size = new System.Drawing.Size(72, 30);
            this.lblcantidad.TabIndex = 34;
            this.lblcantidad.Text = "1";
            // 
            // btnsuma
            // 
            this.btnsuma.Image = ((System.Drawing.Image)(resources.GetObject("btnsuma.Image")));
            this.btnsuma.Location = new System.Drawing.Point(248, 221);
            this.btnsuma.Name = "btnsuma";
            this.btnsuma.Size = new System.Drawing.Size(31, 30);
            this.btnsuma.TabIndex = 33;
            this.btnsuma.TabStop = false;
            this.btnsuma.Click += new System.EventHandler(this.pictureBox2_Click);
            this.btnsuma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnsuma_MouseDown);
            this.btnsuma.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            this.btnsuma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnsuma_MouseUp);
            // 
            // btnresta
            // 
            this.btnresta.Image = ((System.Drawing.Image)(resources.GetObject("btnresta.Image")));
            this.btnresta.Location = new System.Drawing.Point(302, 221);
            this.btnresta.Name = "btnresta";
            this.btnresta.Size = new System.Drawing.Size(31, 30);
            this.btnresta.TabIndex = 32;
            this.btnresta.TabStop = false;
            this.btnresta.Click += new System.EventHandler(this.btnresta_Click);
            this.btnresta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnresta_MouseDown);
            this.btnresta.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            this.btnresta.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnresta_MouseUp);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCantidad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCantidad.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(12, 219);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(136, 30);
            this.txtCantidad.TabIndex = 31;
            this.txtCantidad.Text = "Cantidad:";
            this.txtCantidad.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPrecio.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(6, 100);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(118, 30);
            this.txtPrecio.TabIndex = 29;
            this.txtPrecio.Text = "Precio";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(-88, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 30);
            this.label9.TabIndex = 30;
            this.label9.Text = "$";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombre.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(3, 15);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(385, 58);
            this.txtNombre.TabIndex = 28;
            this.txtNombre.Text = "Nombre";
            this.txtNombre.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // lblOferta
            // 
            this.lblOferta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOferta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOferta.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOferta.ForeColor = System.Drawing.Color.IndianRed;
            this.lblOferta.Location = new System.Drawing.Point(114, 8);
            this.lblOferta.Name = "lblOferta";
            this.lblOferta.Size = new System.Drawing.Size(308, 101);
            this.lblOferta.TabIndex = 35;
            this.lblOferta.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Controls.Add(this.lblTextprecio);
            this.panel3.Controls.Add(this.lblOferta);
            this.panel3.Location = new System.Drawing.Point(551, 498);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(424, 115);
            this.panel3.TabIndex = 3;
            this.panel3.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // lblTextprecio
            // 
            this.lblTextprecio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTextprecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTextprecio.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextprecio.Location = new System.Drawing.Point(2, 45);
            this.lblTextprecio.Name = "lblTextprecio";
            this.lblTextprecio.Size = new System.Drawing.Size(102, 35);
            this.lblTextprecio.TabIndex = 37;
            this.lblTextprecio.Text = "Oferta:";
            this.lblTextprecio.Visible = false;
            this.lblTextprecio.Click += new System.EventHandler(this.lblTextprecio_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 27);
            this.label2.TabIndex = 22;
            this.label2.Text = "Detalles";
            this.label2.Click += new System.EventHandler(this.label3_Click);
            this.label2.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(14, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 30);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ficha tecnica";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "______________________";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(4, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "______________________________________";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(9, 614);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(524, 296);
            this.txtDescripcion.TabIndex = 26;
            this.txtDescripcion.Text = "...";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 587);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 27);
            this.label6.TabIndex = 27;
            this.label6.Text = "Descripcion:";
            this.label6.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // incrementimer
            // 
            this.incrementimer.Tick += new System.EventHandler(this.incrementimer_Tick);
            // 
            // decrementimer
            // 
            this.decrementimer.Tick += new System.EventHandler(this.decrementimer_Tick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(264, 533);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 53);
            this.panel4.TabIndex = 28;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            this.panel4.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(13, 531);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(245, 53);
            this.panel5.TabIndex = 1;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            this.panel5.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodigoBarras.Location = new System.Drawing.Point(612, 691);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoBarras.TabIndex = 30;
            this.txtCodigoBarras.Visible = false;
            this.txtCodigoBarras.TextChanged += new System.EventHandler(this.txtCodigoBarras_TextChanged);
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Location = new System.Drawing.Point(727, 669);
            this.pictureBoxCamera.Name = "pictureBoxCamera";
            this.pictureBoxCamera.Size = new System.Drawing.Size(33, 33);
            this.pictureBoxCamera.TabIndex = 31;
            this.pictureBoxCamera.TabStop = false;
            this.pictureBoxCamera.Visible = false;
            // 
            // scanDelayTimer
            // 
            this.scanDelayTimer.Tick += new System.EventHandler(this.scanDelayTimer_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(171, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 57;
            this.label10.Text = "Total a pagar:";
            // 
            // panelCarrito
            // 
            this.panelCarrito.AutoScroll = true;
            this.panelCarrito.Controls.Add(this.panelCabeceraCarrito);
            this.panelCarrito.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelCarrito.Location = new System.Drawing.Point(1044, 49);
            this.panelCarrito.Name = "panelCarrito";
            this.panelCarrito.Size = new System.Drawing.Size(303, 901);
            this.panelCarrito.TabIndex = 60;
            this.panelCarrito.Visible = false;
            // 
            // panelCabeceraCarrito
            // 
            this.panelCabeceraCarrito.Controls.Add(this.txtTotalPagar);
            this.panelCabeceraCarrito.Controls.Add(this.label10);
            this.panelCabeceraCarrito.Controls.Add(this.label11);
            this.panelCabeceraCarrito.Controls.Add(this.label8);
            this.panelCabeceraCarrito.Controls.Add(this.pictureBox1);
            this.panelCabeceraCarrito.Controls.Add(this.label7);
            this.panelCabeceraCarrito.Controls.Add(this.label5);
            this.panelCabeceraCarrito.Location = new System.Drawing.Point(3, 3);
            this.panelCabeceraCarrito.Name = "panelCabeceraCarrito";
            this.panelCabeceraCarrito.Size = new System.Drawing.Size(274, 85);
            this.panelCabeceraCarrito.TabIndex = 61;
            this.panelCabeceraCarrito.Visible = false;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTotalPagar.BackColor = System.Drawing.Color.White;
            this.txtTotalPagar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPagar.Location = new System.Drawing.Point(173, 46);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(99, 17);
            this.txtTotalPagar.TabIndex = 59;
            this.txtTotalPagar.Text = "Items";
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label11.Location = new System.Drawing.Point(0, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(274, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "____________________________________________";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(6, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 25);
            this.label8.TabIndex = 41;
            this.label8.Text = "Items";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(253, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 25);
            this.label7.TabIndex = 39;
            this.label7.Text = "Carrito";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(78, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 38;
            this.label5.Text = "cantidad";
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 1016);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1347, 10);
            this.panel7.TabIndex = 61;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.pictureBox3);
            this.panel8.Controls.Add(this.panelTotalCarrito);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 950);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1347, 66);
            this.panel8.TabIndex = 62;
            // 
            // panelTotalCarrito
            // 
            this.panelTotalCarrito.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTotalCarrito.Location = new System.Drawing.Point(1044, 0);
            this.panelTotalCarrito.Name = "panelTotalCarrito";
            this.panelTotalCarrito.Size = new System.Drawing.Size(303, 66);
            this.panelTotalCarrito.TabIndex = 0;
            this.panelTotalCarrito.Visible = false;
            // 
            // lblSubCategoria2
            // 
            this.lblSubCategoria2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSubCategoria2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria2.Location = new System.Drawing.Point(458, 0);
            this.lblSubCategoria2.Name = "lblSubCategoria2";
            this.lblSubCategoria2.Size = new System.Drawing.Size(182, 49);
            this.lblSubCategoria2.TabIndex = 44;
            this.lblSubCategoria2.Text = "SubCategoria2";
            this.lblSubCategoria2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubCategoria2.Visible = false;
            // 
            // lblSiguienteSubCat2
            // 
            this.lblSiguienteSubCat2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSiguienteSubCat2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiguienteSubCat2.Location = new System.Drawing.Point(414, 0);
            this.lblSiguienteSubCat2.Name = "lblSiguienteSubCat2";
            this.lblSiguienteSubCat2.Size = new System.Drawing.Size(44, 49);
            this.lblSiguienteSubCat2.TabIndex = 46;
            this.lblSiguienteSubCat2.Text = ">";
            this.lblSiguienteSubCat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSiguienteSubCat2.Visible = false;
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSubCategoria.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria.Location = new System.Drawing.Point(232, 0);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(182, 49);
            this.lblSubCategoria.TabIndex = 43;
            this.lblSubCategoria.Text = "SubCategoria";
            this.lblSubCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubCategoria.Visible = false;
            // 
            // lblSiguienteSubCat
            // 
            this.lblSiguienteSubCat.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSiguienteSubCat.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSiguienteSubCat.Location = new System.Drawing.Point(188, 0);
            this.lblSiguienteSubCat.Name = "lblSiguienteSubCat";
            this.lblSiguienteSubCat.Size = new System.Drawing.Size(44, 49);
            this.lblSiguienteSubCat.TabIndex = 45;
            this.lblSiguienteSubCat.Text = ">";
            this.lblSiguienteSubCat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSiguienteSubCat.Visible = false;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCategoria.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(0, 0);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(188, 49);
            this.lblCategoria.TabIndex = 42;
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCategoria.Visible = false;
            // 
            // FrmVistaDetalleProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1347, 1026);
            this.Controls.Add(this.panelCarrito);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.pictureBoxCamera);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.picFoto);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVistaDetalleProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetalleProducto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVistaDetalleProducto_FormClosing);
            this.Load += new System.EventHandler(this.FrmVistaDetalleProducto_Load);
            this.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnsuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnresta)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCamera)).EndInit();
            this.panelCarrito.ResumeLayout(false);
            this.panelCabeceraCarrito.ResumeLayout(false);
            this.panelCabeceraCarrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label txtPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtDescripcion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblcantidad;
        private System.Windows.Forms.PictureBox btnsuma;
        private System.Windows.Forms.PictureBox btnresta;
        private System.Windows.Forms.Timer incrementimer;
        private System.Windows.Forms.Timer decrementimer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.PictureBox pictureBoxCamera;
        private System.Windows.Forms.Timer scanDelayTimer;
        private System.Windows.Forms.Label lblOferta;
        private System.Windows.Forms.Label lblpreciodescuento;
        private System.Windows.Forms.Label lblTextprecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPedirStock;
        private System.Windows.Forms.FlowLayoutPanel panelCarrito;
        private System.Windows.Forms.Panel panelCabeceraCarrito;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panelTotalCarrito;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtTotalPagar;
        private System.Windows.Forms.Label lblSubCategoria2;
        private System.Windows.Forms.Label lblSiguienteSubCat2;
        private System.Windows.Forms.Label lblSubCategoria;
        private System.Windows.Forms.Label lblSiguienteSubCat;
        private System.Windows.Forms.Label lblCategoria;
    }
}