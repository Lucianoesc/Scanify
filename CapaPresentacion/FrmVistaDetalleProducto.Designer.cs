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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCategoria = new System.Windows.Forms.Label();
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
            this.dtgvCompra = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Oferta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.txtCategoria);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 49);
            this.panel1.TabIndex = 0;
            this.panel1.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(66, 49);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(72, 9);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(240, 36);
            this.txtCategoria.TabIndex = 32;
            this.txtCategoria.Text = "Categoria";
            this.txtCategoria.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // picFoto
            // 
            this.picFoto.Location = new System.Drawing.Point(32, 81);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(531, 464);
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
            this.panel2.Location = new System.Drawing.Point(586, 81);
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
            this.panel3.Location = new System.Drawing.Point(586, 524);
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
            this.txtDescripcion.Location = new System.Drawing.Point(49, 700);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(440, 291);
            this.txtDescripcion.TabIndex = 26;
            this.txtDescripcion.Text = "...";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 675);
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
            this.panel4.Location = new System.Drawing.Point(294, 588);
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
            this.panel5.Location = new System.Drawing.Point(43, 586);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(245, 53);
            this.panel5.TabIndex = 1;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            this.panel5.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Location = new System.Drawing.Point(586, 55);
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoBarras.TabIndex = 30;
            this.txtCodigoBarras.Visible = false;
            this.txtCodigoBarras.TextChanged += new System.EventHandler(this.txtCodigoBarras_TextChanged);
            // 
            // pictureBoxCamera
            // 
            this.pictureBoxCamera.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBoxCamera.Location = new System.Drawing.Point(530, 549);
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
            // dtgvCompra
            // 
            this.dtgvCompra.AllowUserToAddRows = false;
            this.dtgvCompra.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Producto,
            this.PrecioCompra,
            this.Oferta,
            this.btneliminar});
            this.dtgvCompra.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvCompra.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvCompra.Location = new System.Drawing.Point(586, 645);
            this.dtgvCompra.MultiSelect = false;
            this.dtgvCompra.Name = "dtgvCompra";
            this.dtgvCompra.ReadOnly = true;
            this.dtgvCompra.RowHeadersWidth = 38;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgvCompra.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvCompra.RowTemplate.Height = 28;
            this.dtgvCompra.Size = new System.Drawing.Size(624, 369);
            this.dtgvCompra.TabIndex = 41;
            this.dtgvCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvCompra_CellContentClick);
            this.dtgvCompra.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgvCompra_CellPainting);
            this.dtgvCompra.MouseEnter += new System.EventHandler(this.FrmVistaDetalleProducto_MouseEnter);
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 100;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 111;
            // 
            // Producto
            // 
            this.Producto.FillWeight = 98.90017F;
            this.Producto.HeaderText = "Nombre de productos";
            this.Producto.MinimumWidth = 222;
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 222;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio";
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            this.PrecioCompra.Width = 70;
            // 
            // Oferta
            // 
            this.Oferta.HeaderText = "Ofertas incluidas";
            this.Oferta.MinimumWidth = 180;
            this.Oferta.Name = "Oferta";
            this.Oferta.ReadOnly = true;
            this.Oferta.Width = 180;
            // 
            // btneliminar
            // 
            this.btneliminar.HeaderText = "";
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.ReadOnly = true;
            this.btneliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btneliminar.Visible = false;
            this.btneliminar.Width = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1028, 591);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 57;
            this.label10.Text = "Total a pagar:";
            this.label10.Visible = false;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(1028, 611);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPagar.TabIndex = 58;
            this.txtTotalPagar.Text = "0";
            this.txtTotalPagar.Visible = false;
            // 
            // FrmVistaDetalleProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1386, 1026);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtgvCompra);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCompra)).EndInit();
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
        private System.Windows.Forms.Label txtCategoria;
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
        private System.Windows.Forms.DataGridView dtgvCompra;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Oferta;
        private System.Windows.Forms.DataGridViewButtonColumn btneliminar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Button btnPedirStock;
    }
}