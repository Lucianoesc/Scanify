namespace CapaPresentacion.Modales
{
    partial class FrmRecuperarContraseña
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
            this.grupboxEnviar = new Siticone.Desktop.UI.WinForms.SiticoneGroupBox();
            this.btnBuscar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCorreo = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.grupboxCambiarContraseña = new Siticone.Desktop.UI.WinForms.SiticoneGroupBox();
            this.btnGuardar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContraseña = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.grupboxVerificarNum = new Siticone.Desktop.UI.WinForms.SiticoneGroupBox();
            this.btnVerificar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigo = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.grupboxEnviar.SuspendLayout();
            this.grupboxCambiarContraseña.SuspendLayout();
            this.grupboxVerificarNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupboxEnviar
            // 
            this.grupboxEnviar.Controls.Add(this.btnBuscar);
            this.grupboxEnviar.Controls.Add(this.label1);
            this.grupboxEnviar.Controls.Add(this.txtCorreo);
            this.grupboxEnviar.CustomBorderColor = System.Drawing.Color.White;
            this.grupboxEnviar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupboxEnviar.ForeColor = System.Drawing.Color.Black;
            this.grupboxEnviar.Location = new System.Drawing.Point(6, 27);
            this.grupboxEnviar.Name = "grupboxEnviar";
            this.grupboxEnviar.Size = new System.Drawing.Size(427, 201);
            this.grupboxEnviar.TabIndex = 0;
            this.grupboxEnviar.Text = "Recuperar tu cuenta";
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(314, 163);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 34);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Introduce tu correo electrónico para recuperar tu cuenta";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCorreo.DefaultText = "";
            this.txtCorreo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCorreo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCorreo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCorreo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCorreo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCorreo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCorreo.Location = new System.Drawing.Point(15, 77);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.PasswordChar = '\0';
            this.txtCorreo.PlaceholderText = "Correo electrónico";
            this.txtCorreo.SelectedText = "";
            this.txtCorreo.Size = new System.Drawing.Size(335, 36);
            this.txtCorreo.TabIndex = 0;
            // 
            // grupboxCambiarContraseña
            // 
            this.grupboxCambiarContraseña.Controls.Add(this.btnGuardar);
            this.grupboxCambiarContraseña.Controls.Add(this.label2);
            this.grupboxCambiarContraseña.Controls.Add(this.txtContraseña);
            this.grupboxCambiarContraseña.CustomBorderColor = System.Drawing.Color.White;
            this.grupboxCambiarContraseña.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupboxCambiarContraseña.ForeColor = System.Drawing.Color.Black;
            this.grupboxCambiarContraseña.Location = new System.Drawing.Point(6, 27);
            this.grupboxCambiarContraseña.Name = "grupboxCambiarContraseña";
            this.grupboxCambiarContraseña.Size = new System.Drawing.Size(427, 201);
            this.grupboxCambiarContraseña.TabIndex = 4;
            this.grupboxCambiarContraseña.Text = "Cambiar contraseña";
            this.grupboxCambiarContraseña.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuardar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(315, 164);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(109, 34);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Introduce la nueva contraseña";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContraseña.DefaultText = "";
            this.txtContraseña.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContraseña.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContraseña.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContraseña.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContraseña.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContraseña.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtContraseña.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContraseña.Location = new System.Drawing.Point(15, 77);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '\0';
            this.txtContraseña.PlaceholderText = "Nueva contraseña";
            this.txtContraseña.SelectedText = "";
            this.txtContraseña.Size = new System.Drawing.Size(335, 36);
            this.txtContraseña.TabIndex = 0;
            // 
            // grupboxVerificarNum
            // 
            this.grupboxVerificarNum.Controls.Add(this.btnVerificar);
            this.grupboxVerificarNum.Controls.Add(this.label3);
            this.grupboxVerificarNum.Controls.Add(this.txtCodigo);
            this.grupboxVerificarNum.CustomBorderColor = System.Drawing.Color.White;
            this.grupboxVerificarNum.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupboxVerificarNum.ForeColor = System.Drawing.Color.Black;
            this.grupboxVerificarNum.Location = new System.Drawing.Point(3, 27);
            this.grupboxVerificarNum.Name = "grupboxVerificarNum";
            this.grupboxVerificarNum.Size = new System.Drawing.Size(430, 201);
            this.grupboxVerificarNum.TabIndex = 4;
            this.grupboxVerificarNum.Text = "Verificacion del codigo";
            this.grupboxVerificarNum.Visible = false;
            // 
            // btnVerificar
            // 
            this.btnVerificar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerificar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerificar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerificar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerificar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVerificar.ForeColor = System.Drawing.Color.White;
            this.btnVerificar.Location = new System.Drawing.Point(314, 163);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(109, 34);
            this.btnVerificar.TabIndex = 3;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Introduce el codigo de verificacion que te mandamos al mail";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCodigo.DefaultText = "";
            this.txtCodigo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCodigo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCodigo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCodigo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCodigo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCodigo.Location = new System.Drawing.Point(15, 77);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PasswordChar = '\0';
            this.txtCodigo.PlaceholderText = "Codigo de verificacion";
            this.txtCodigo.SelectedText = "";
            this.txtCodigo.Size = new System.Drawing.Size(335, 36);
            this.txtCodigo.TabIndex = 0;
            // 
            // FrmRecuperarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 234);
            this.Controls.Add(this.grupboxEnviar);
            this.Controls.Add(this.grupboxCambiarContraseña);
            this.Controls.Add(this.grupboxVerificarNum);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Name = "FrmRecuperarContraseña";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRecuperarContraseña";
            this.Load += new System.EventHandler(this.FrmRecuperarContraseña_Load);
            this.grupboxEnviar.ResumeLayout(false);
            this.grupboxEnviar.PerformLayout();
            this.grupboxCambiarContraseña.ResumeLayout(false);
            this.grupboxCambiarContraseña.PerformLayout();
            this.grupboxVerificarNum.ResumeLayout(false);
            this.grupboxVerificarNum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneGroupBox grupboxEnviar;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnBuscar;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtCorreo;
        private Siticone.Desktop.UI.WinForms.SiticoneGroupBox grupboxCambiarContraseña;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnGuardar;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtContraseña;
        private Siticone.Desktop.UI.WinForms.SiticoneGroupBox grupboxVerificarNum;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnVerificar;
        private System.Windows.Forms.Label label3;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtCodigo;
    }
}