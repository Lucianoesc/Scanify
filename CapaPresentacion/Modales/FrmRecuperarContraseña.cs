using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using CapaNegocio;
using CapaEntidad;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CapaPresentacion.Modales
{
    public partial class FrmRecuperarContraseña : MaterialForm
    {
        private int codigoVerificacion;


        string emisor = "scanifynotificaciones@gmail.com";
        string contraseña = "vpue bhlo jika zqjs";
        string errorMessage = string.Empty;
        MaterialSkinManager materialSkinManager;

        public FrmRecuperarContraseña()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey900, Accent.Cyan700, TextShade.WHITE);
        }

        private void FrmRecuperarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RecuperarContraseña email = new RecuperarContraseña();
            codigoVerificacion = email.Enviar(emisor, contraseña, txtCorreo.Text, out errorMessage);

            if (codigoVerificacion != 0)
            {
                grupboxEnviar.Visible = false;
                grupboxVerificarNum.Visible = true;
            }
            else
            {
                MessageBox.Show("Error al enviar el correo, compruebe su conexion a internet");
            }



        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string mensaje = string.Empty;


            Usuario mail = new CN_Usuario().Listar().FirstOrDefault(u => u.Correo == correo);

            Usuario objusuario = new Usuario()
            {
                IdUsuario = mail.IdUsuario,
                Username = mail.Username,
                Clave = txtContraseña.Text,
                Nombre = mail.Nombre,
                Apellido = mail.Apellido,
                Documento = mail.Documento,
                Telefono = mail.Telefono,
                Correo = mail.Correo,
                oRol = mail.oRol,
                Estado = mail.Estado


            };
            if (mail.IdUsuario == 0)
            {

            }
            else
            {
                bool resultado = new CN_Usuario().Editar(objusuario, out mensaje);
                if (resultado)
                {
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }



            

        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            int codigoIngresado;
            if (int.TryParse(txtCodigo.Text, out codigoIngresado))
            {
                if (codigoIngresado == codigoVerificacion)
                {
                    grupboxVerificarNum.Visible= false;
                    grupboxCambiarContraseña.Visible = true;
                }
                else
                {
                    MessageBox.Show("Código incorrecto. Por favor, vuelva a intentarlo.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un código válido.");
            }
        }
    }
}
