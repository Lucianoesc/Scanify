using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;
using BCrypt.Net;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();

        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            
            if (txtUsuario.Focus() && txtUsuario.Text == "" || txtUsuario.Text == "usuario")
            {
                txtUsuario.Font = new Font(txtUsuario.Font, FontStyle.Regular);
                panelUsuario.BackColor = Color.FromArgb(249, 249, 249);
                panelUsuario.BorderStyle = BorderStyle.FixedSingle;
                txtUsuario.BackColor = Color.FromArgb(249, 249, 249);
                txtUsuario.ForeColor = Color.Black;
                txtUsuario.Text = "";
                lblUsuario.Visible = true;
            }
            if (txtUsuario.Focus() && txtContraseña.Text == "" || txtContraseña.Text == "contraseña")
            {
                panelContraseña.BackColor = Color.FromArgb(237, 237, 237);
                panelContraseña.BorderStyle = BorderStyle.None;
                txtContraseña.BackColor = Color.FromArgb(237, 237, 237);
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.Text = "contraseña";
                lblContraseña.Visible = false;
            }
            if (txtUsuario.Focus() && txtContraseña.Text == "" && txtUsuario.Text != "")
            {
                lblContraseña.ForeColor = Color.DimGray;
                lblUsuario.ForeColor = Color.DimGray;
                txtUsuario.ForeColor = Color.DimGray;
                panelContraseña.BackColor = Color.FromArgb(249, 249, 249);
                panelUsuario.BackColor = Color.FromArgb(249, 249, 249);
                txtContraseña.BackColor = Color.FromArgb(249, 249, 249);
                txtUsuario.BackColor = Color.FromArgb(249, 249, 249);
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Focus() && txtContraseña.Text == "" || txtContraseña.Text == "contraseña")
            {
                panelContraseña.BackColor = Color.FromArgb(249, 249, 249);
                panelContraseña.BorderStyle = BorderStyle.FixedSingle;
                txtContraseña.BackColor = Color.FromArgb(249, 249, 249);
                txtContraseña.ForeColor = Color.Black;
                txtContraseña.UseSystemPasswordChar = true;
                txtContraseña.Text = "";
                lblContraseña.Visible = true;
            }
            if (txtContraseña.Focus() && txtUsuario.Text == "" || txtUsuario.Text == "usuario")
            {
                txtUsuario.Font = new Font(txtUsuario.Font, FontStyle.Bold);
                panelUsuario.BackColor = Color.FromArgb(237, 237, 237);
                panelUsuario.BorderStyle = BorderStyle.None;
                txtUsuario.BackColor = Color.FromArgb(237, 237, 237);
                txtUsuario.Text = "usuario";
                txtUsuario.ForeColor = Color.DimGray;
                lblUsuario.Visible = false;

            }
            
        }

        private void FrmLogin_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                panelContraseña.BackColor = Color.FromArgb(237, 237, 237);
                panelContraseña.BorderStyle = BorderStyle.None;
                txtContraseña.BackColor = Color.FromArgb(237, 237, 237);
                txtContraseña.Enabled = false;
                txtContraseña.Text = "contraseña";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.Enabled = true;
                lblContraseña.Visible = false;


            }
            if (txtUsuario.Text == "")
            {
                txtUsuario.Font = new Font(txtUsuario.Font, FontStyle.Bold);
                btninactivo.Focus();
                panelUsuario.BackColor = Color.FromArgb(237, 237, 237);
                panelUsuario.BorderStyle = BorderStyle.None;
                txtUsuario.BackColor = Color.FromArgb(237, 237, 237);
                txtUsuario.Text = "usuario";
                txtUsuario.ForeColor = Color.DimGray;
                lblUsuario.Visible = false;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "usuario" && txtUsuario.Text != "" && txtContraseña.Text != "contraseña" && txtContraseña.Text != "")
            {
                btnactivo.Visible = true;
                btninactivo.Visible = false;
            }
            else
            {
                btnactivo.Visible = false;
                btninactivo.Visible = true;
            }
        }

        public void Alerta(string msg, Form_Alertas.enmType type)
        {
            Form_Alertas frm = new Form_Alertas();
            frm.mostrarAlerta(msg,type);
        }
        private void btnactivo_Click(object sender, EventArgs e)
        {

            string username = txtUsuario.Text;
            string password = txtContraseña.Text;

            Usuario usuario = new CN_Usuario().Listar().FirstOrDefault(u => u.Username == username);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(password, usuario.Clave))
            {
                this.Alerta("Bienvenido!!", Form_Alertas.enmType.Exito);


                FrmTablero dash = new FrmTablero(usuario);
                CN_Bitacora cnBitacora = new CN_Bitacora();
                cnBitacora.InsertarBitacora(usuario.Username, usuario.IdUsuario.ToString(), "Login", "Login exitoso", "FrmLogin");
                dash.Show();

                this.Hide();
                dash.FormClosing += frm_closing;
            }
            else
            {
                this.Alerta("Credenciales incorrectas", Form_Alertas.enmType.Error);
                panelError.Visible = true;
                txtUsuario.BackColor = Color.FromArgb(242, 226, 244);
                panelUsuario.BackColor = Color.FromArgb(242, 226, 244);
                txtContraseña.BackColor = Color.FromArgb(242, 226, 244);
                panelContraseña.BackColor = Color.FromArgb(242, 226, 244);
                lblContraseña.ForeColor = Color.FromArgb(189, 17, 99);
                lblUsuario.ForeColor = Color.FromArgb(189, 17, 99);
                txtContraseña.Text = "";
            }

        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            panelContraseña.BackColor = Color.FromArgb(237, 237, 237);
            panelContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.BackColor = Color.FromArgb(237, 237, 237);
            txtContraseña.Enabled = false;
            txtContraseña.Text = "contraseña";
            txtContraseña.ForeColor = Color.DimGray;
            txtContraseña.UseSystemPasswordChar = false;
            txtContraseña.Enabled = true;
            lblContraseña.Visible = false;
            txtUsuario.Font = new Font(txtUsuario.Font, FontStyle.Bold);
            btninactivo.Focus();
            panelUsuario.BackColor = Color.FromArgb(237, 237, 237);
            panelUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.BackColor = Color.FromArgb(237, 237, 237);
            txtUsuario.Text = "usuario";
            txtUsuario.ForeColor = Color.DimGray;
            lblUsuario.Visible = false;
            this.Show();
            btninactivo.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmInicio frm = new FrmInicio();
            frm.Show();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnactivo_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Alerta("Bienvenido!", Form_Alertas.enmType.Exito);

        }

        private void panelContraseña_MouseEnter(object sender, EventArgs e)
        {
            if (txtContraseña.BackColor == Color.FromArgb(242, 226, 244))
            {
                panelError.Visible = false;

                lblContraseña.ForeColor = Color.DimGray;
                lblUsuario.ForeColor = Color.DimGray;
                panelContraseña.BackColor = Color.FromArgb(249, 249, 249);
                panelUsuario.BackColor = Color.FromArgb(249, 249, 249);
                txtContraseña.BackColor = Color.FromArgb(249, 249, 249);
                txtUsuario.BackColor = Color.FromArgb(249, 249, 249);

            }
        }

        private void panelUsuario_MouseEnter(object sender, EventArgs e)
        {
            if (txtUsuario.BackColor == Color.FromArgb(242, 226, 244))
            {
                panelError.Visible = false;

                lblContraseña.ForeColor = Color.DimGray;
                lblUsuario.ForeColor = Color.DimGray;
                panelContraseña.BackColor = Color.FromArgb(249, 249, 249);
                panelUsuario.BackColor = Color.FromArgb(249, 249, 249);
                txtContraseña.BackColor = Color.FromArgb(249, 249, 249);
                txtUsuario.BackColor = Color.FromArgb(249, 249, 249);

            }
        }

    }
}
