using CapaEntidad;
using CapaNegocio;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class Md_CodigoSeguro : Form
    {
        private ActivityTimer activityTimer;

        public Md_CodigoSeguro()
        {
            InitializeComponent();
            activityTimer = ActivityTimer.GetInstance();
            activityTimer.InactivityDetected += ActivityTimer_InactivityDetected;
            activityTimer.Start();
        }

        private void Md_CodigoSeguro_Load(object sender, EventArgs e)
        {

        }
        private void ActivityTimer_InactivityDetected(object sender, EventArgs e)
        {
            // Se detectó inactividad, mostrar el formulario de confirmación
            MyMessageBoxForm messageBoxForm = new MyMessageBoxForm();
            DialogResult result = messageBoxForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                activityTimer.Stop();
                activityTimer.Start();
            }
            else
            {
                // El usuario no respondió o confirmó que no está activo, cerrar sesión y volver a la pantalla principal
                // Realiza aquí las acciones para cerrar la sesión y volver a la pantalla principal
                FrmPantallaPrincipalClientes frmPantallaPrincipal = new FrmPantallaPrincipalClientes();
                frmPantallaPrincipal.Show();
                activityTimer.Stop();
                // Cerrar el formulario principal FrmInicioClientes si está abierto
                FrmInicioClientes principalClientes = Application.OpenForms.OfType<FrmInicioClientes>().FirstOrDefault();
                principalClientes?.Dispose();
                this.Dispose();

                this.Close();
            }
        }
        private void btnUno_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("1");

        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("2");

        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("3");

        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("4");

        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("5");

        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("6");

        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("7");

        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("8");

        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("9");

        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo(".");

        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            AgregarNumeroAlCodigo("0");

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            if (txtCodigo.Text.Length > 0)
            {
                txtCodigo.Text = txtCodigo.Text.Remove(txtCodigo.Text.Length - 1);
            }
        }
        private void AgregarNumeroAlCodigo(string numero)
        {
            activityTimer.Stop();
            activityTimer.Start();
            txtCodigo.Text += numero;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            activityTimer.Stop();
            activityTimer.Start();
            string codigoIngresado = txtCodigo.Text;

            // Obtener los datos del negocio, incluido el código de seguridad, desde la capa de datos
            Negocio negocio = new CN_Negocio().ObtenerDatos();

            // Verificar si el código ingresado coincide con el código seguro obtenido
            if (codigoIngresado.SequenceEqual(negocio.CodigoSeguridad))
            {
                activityTimer.Stop();

                CompraTemp.ReiniciarCompraTemp(); // Reiniciar la compra temporal aquí

                // Cerrar el formulario de código de seguridad
                this.Close();
                this.Dispose();
                // Verificar si el formulario de inicio ya está abierto
                FrmInicio frmInicio = FrmInicio.ObtenerInstancia();
                if (frmInicio == null)
                {
                    frmInicio = new FrmInicio();
                }
                frmInicio.Show();
                // Cerrar el formulario principal FrmInicioClientes si está abierto
                FrmInicioClientes principalClientes = Application.OpenForms.OfType<FrmInicioClientes>().FirstOrDefault();
                principalClientes?.Dispose();
                FrmVistaDetalleProducto vistadetalle = Application.OpenForms.OfType<FrmVistaDetalleProducto>().FirstOrDefault();
                vistadetalle?.Dispose();
                // Cerrar el formulario principal FrmBusquedaCategoria si está abierto
                FrmBusquedaCategoria principalCategorias = Application.OpenForms.OfType<FrmBusquedaCategoria>().FirstOrDefault();
                principalCategorias?.Dispose();

                
            }
            else
            {
                // Código incorrecto, puedes manejar esta lógica según tus necesidades
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            this.Dispose();
            this.Close();
        }

        private void Md_CodigoSeguro_FormClosing(object sender, FormClosingEventArgs e)
        {
            activityTimer.Stop();
            this.Dispose();
            this.Close();

        }

        private void Md_CodigoSeguro_FormClosed(object sender, FormClosedEventArgs e)
        {
            activityTimer.Stop();
            this.Dispose();
            this.Close();
        }
    }
}
