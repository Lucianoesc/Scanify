namespace CapaPresentacion
{
    partial class FrmCategoria
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
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnSubCategoria2 = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.btnSubCategoria = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.txtBuscador = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.btnCategorias = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBuscadorSubCategorias = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.txtBuscadorSubCategorias2 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.txtBuscadorProductos = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.btnProducto = new MaterialSkin.Controls.MaterialFloatingActionButton();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.Controls.Add(this.btnProducto);
            this.panelSuperior.Controls.Add(this.txtBuscadorProductos);
            this.panelSuperior.Controls.Add(this.txtBuscadorSubCategorias2);
            this.panelSuperior.Controls.Add(this.txtBuscadorSubCategorias);
            this.panelSuperior.Controls.Add(this.btnSubCategoria2);
            this.panelSuperior.Controls.Add(this.btnSubCategoria);
            this.panelSuperior.Controls.Add(this.txtBuscador);
            this.panelSuperior.Controls.Add(this.btnCategorias);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1159, 100);
            this.panelSuperior.TabIndex = 3;
            // 
            // btnSubCategoria2
            // 
            this.btnSubCategoria2.Depth = 0;
            this.btnSubCategoria2.Icon = global::CapaPresentacion.Properties.Resources.mas__1_;
            this.btnSubCategoria2.Location = new System.Drawing.Point(382, 42);
            this.btnSubCategoria2.Mini = true;
            this.btnSubCategoria2.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSubCategoria2.Name = "btnSubCategoria2";
            this.btnSubCategoria2.Size = new System.Drawing.Size(43, 45);
            this.btnSubCategoria2.TabIndex = 2;
            this.btnSubCategoria2.Text = "materialFloatingActionButton1";
            this.btnSubCategoria2.UseVisualStyleBackColor = true;
            this.btnSubCategoria2.Visible = false;
            this.btnSubCategoria2.Click += new System.EventHandler(this.btnSubCategoria2_Click);
            // 
            // btnSubCategoria
            // 
            this.btnSubCategoria.Depth = 0;
            this.btnSubCategoria.Icon = global::CapaPresentacion.Properties.Resources.mas__1_;
            this.btnSubCategoria.Location = new System.Drawing.Point(382, 42);
            this.btnSubCategoria.Mini = true;
            this.btnSubCategoria.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSubCategoria.Name = "btnSubCategoria";
            this.btnSubCategoria.Size = new System.Drawing.Size(43, 45);
            this.btnSubCategoria.TabIndex = 1;
            this.btnSubCategoria.Text = "materialFloatingActionButton1";
            this.btnSubCategoria.UseVisualStyleBackColor = true;
            this.btnSubCategoria.Visible = false;
            this.btnSubCategoria.Click += new System.EventHandler(this.btnSubCategoria_Click);
            // 
            // txtBuscador
            // 
            this.txtBuscador.BorderRadius = 15;
            this.txtBuscador.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscador.DefaultText = "";
            this.txtBuscador.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscador.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscador.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscador.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscador.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscador.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscador.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscador.IconLeft = global::CapaPresentacion.Properties.Resources.lupa;
            this.txtBuscador.Location = new System.Drawing.Point(12, 42);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.PasswordChar = '\0';
            this.txtBuscador.PlaceholderText = "Buscar";
            this.txtBuscador.SelectedText = "";
            this.txtBuscador.Size = new System.Drawing.Size(364, 36);
            this.txtBuscador.TabIndex = 0;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // btnCategorias
            // 
            this.btnCategorias.Depth = 0;
            this.btnCategorias.Icon = global::CapaPresentacion.Properties.Resources.mas__1_;
            this.btnCategorias.Location = new System.Drawing.Point(382, 42);
            this.btnCategorias.Mini = true;
            this.btnCategorias.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(43, 45);
            this.btnCategorias.TabIndex = 0;
            this.btnCategorias.Text = "materialFloatingActionButton1";
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 933);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(1159, 108);
            this.panelInferior.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1159, 833);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // txtBuscadorSubCategorias
            // 
            this.txtBuscadorSubCategorias.BorderRadius = 15;
            this.txtBuscadorSubCategorias.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscadorSubCategorias.DefaultText = "";
            this.txtBuscadorSubCategorias.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscadorSubCategorias.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscadorSubCategorias.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscadorSubCategorias.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscadorSubCategorias.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscadorSubCategorias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscadorSubCategorias.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscadorSubCategorias.IconLeft = global::CapaPresentacion.Properties.Resources.lupa;
            this.txtBuscadorSubCategorias.Location = new System.Drawing.Point(12, 42);
            this.txtBuscadorSubCategorias.Name = "txtBuscadorSubCategorias";
            this.txtBuscadorSubCategorias.PasswordChar = '\0';
            this.txtBuscadorSubCategorias.PlaceholderText = "Buscar";
            this.txtBuscadorSubCategorias.SelectedText = "";
            this.txtBuscadorSubCategorias.Size = new System.Drawing.Size(364, 36);
            this.txtBuscadorSubCategorias.TabIndex = 3;
            this.txtBuscadorSubCategorias.Visible = false;
            this.txtBuscadorSubCategorias.TextChanged += new System.EventHandler(this.txtBuscadorSubCategorias_TextChanged);
            // 
            // txtBuscadorSubCategorias2
            // 
            this.txtBuscadorSubCategorias2.BorderRadius = 15;
            this.txtBuscadorSubCategorias2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscadorSubCategorias2.DefaultText = "";
            this.txtBuscadorSubCategorias2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscadorSubCategorias2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscadorSubCategorias2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscadorSubCategorias2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscadorSubCategorias2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscadorSubCategorias2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscadorSubCategorias2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscadorSubCategorias2.IconLeft = global::CapaPresentacion.Properties.Resources.lupa;
            this.txtBuscadorSubCategorias2.Location = new System.Drawing.Point(12, 42);
            this.txtBuscadorSubCategorias2.Name = "txtBuscadorSubCategorias2";
            this.txtBuscadorSubCategorias2.PasswordChar = '\0';
            this.txtBuscadorSubCategorias2.PlaceholderText = "Buscar";
            this.txtBuscadorSubCategorias2.SelectedText = "";
            this.txtBuscadorSubCategorias2.Size = new System.Drawing.Size(364, 36);
            this.txtBuscadorSubCategorias2.TabIndex = 4;
            this.txtBuscadorSubCategorias2.Visible = false;
            this.txtBuscadorSubCategorias2.TextChanged += new System.EventHandler(this.txtBuscadorSubCategorias2_TextChanged);
            // 
            // txtBuscadorProductos
            // 
            this.txtBuscadorProductos.BorderRadius = 15;
            this.txtBuscadorProductos.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscadorProductos.DefaultText = "";
            this.txtBuscadorProductos.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscadorProductos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscadorProductos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscadorProductos.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscadorProductos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscadorProductos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBuscadorProductos.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscadorProductos.IconLeft = global::CapaPresentacion.Properties.Resources.lupa;
            this.txtBuscadorProductos.Location = new System.Drawing.Point(12, 42);
            this.txtBuscadorProductos.Name = "txtBuscadorProductos";
            this.txtBuscadorProductos.PasswordChar = '\0';
            this.txtBuscadorProductos.PlaceholderText = "Buscar";
            this.txtBuscadorProductos.SelectedText = "";
            this.txtBuscadorProductos.Size = new System.Drawing.Size(364, 36);
            this.txtBuscadorProductos.TabIndex = 5;
            this.txtBuscadorProductos.Visible = false;
            this.txtBuscadorProductos.TextChanged += new System.EventHandler(this.txtBuscadorProductos_TextChanged);
            // 
            // btnProducto
            // 
            this.btnProducto.Depth = 0;
            this.btnProducto.Icon = global::CapaPresentacion.Properties.Resources.mas__1_;
            this.btnProducto.Location = new System.Drawing.Point(382, 42);
            this.btnProducto.Mini = true;
            this.btnProducto.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(43, 45);
            this.btnProducto.TabIndex = 6;
            this.btnProducto.Text = "materialFloatingActionButton1";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Visible = false;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // FrmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 1041);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCategoria";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCategoria_Load);
            this.panelSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtBuscador;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnCategorias;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnSubCategoria;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnSubCategoria2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtBuscadorProductos;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtBuscadorSubCategorias2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtBuscadorSubCategorias;
        private MaterialSkin.Controls.MaterialFloatingActionButton btnProducto;
    }
}