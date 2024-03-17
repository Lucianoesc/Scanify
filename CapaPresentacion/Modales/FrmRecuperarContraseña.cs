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
using static TheArtOfDev.HtmlRenderer.Adapters.RGraphicsPath;
using DocumentFormat.OpenXml.Spreadsheet;

namespace CapaPresentacion.Modales
{
    public partial class FrmRecuperarContraseña : MaterialForm
    {
        private int codigoVerificacion;
        private static Usuario usuarioActual;


        string emisor = "scanifynotificaciones@gmail.com";
        string contraseña = "vpue bhlo jika zqjs";
        string errorMessage = string.Empty;
        MaterialSkinManager materialSkinManager;

        public FrmRecuperarContraseña(Usuario objUsuario)
        {
            InitializeComponent();
            usuarioActual = objUsuario;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey900, Accent.Cyan700, TextShade.WHITE);
        }

        private void FrmRecuperarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            // Verifica si el correo tiene un formato válido
            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("Por favor, ingrese un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RecuperarContraseña email = new RecuperarContraseña();
            Usuario mail = new CN_Usuario().Listar().FirstOrDefault(u => u.Correo == correo);
            if (mail != null)
            {
                codigoVerificacion = email.Enviar(emisor, contraseña, txtCorreo.Text, out errorMessage);

                if (codigoVerificacion != 0)
                {
                    grupboxEnviar.Visible = false;
                    grupboxVerificarNum.Visible = true;
                }
                else
                {
                    MessageBox.Show("Error al enviar el correo, compruebe su conexión a internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: el correo electrónico no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string mensaje = string.Empty;

            CN_Bitacora cnBitacora = new CN_Bitacora();

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


                    cnBitacora.InsertarBitacora(mail.Username, mail.IdUsuario.ToString(), "Cambio de contraseña", "Cambio exitoso", "FrmRecuperarContraseña");
                    this.Dispose();
                }
                else
                {
                    
                    cnBitacora.InsertarBitacora(mail.Username, mail.ToString(), "Cambio de contraseña", "Cambio erroeno", "FrmRecuperarContraseña");
                    this.Dispose();

                }
            }



            

        }
        private bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar el formato del correo electrónico
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica si el correo coincide con el patrón de expresión regular
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patronCorreo);
        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            CN_Bitacora cnBitacora = new CN_Bitacora();
            Usuario mail = new CN_Usuario().Listar().FirstOrDefault(u => u.Correo == correo);

            string username = mail.Username;

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

                    int idUsuario = mail != null ? mail.IdUsuario : -1;

                    cnBitacora.InsertarBitacora(username, idUsuario.ToString(), "Cambio de contraseña", "Cambio erroeno", "FrmRecuperarContraseña");

                    MessageBox.Show("Código incorrecto, por su seguridad vuelva a intentarlo.");
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un código válido.");
            }
        }
    }
}
