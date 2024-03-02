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
        public Md_CodigoSeguro()
        {
            InitializeComponent();
        }

        private void Md_CodigoSeguro_Load(object sender, EventArgs e)
        {

        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("1");

        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("2");

        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("3");

        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("4");

        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("5");

        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("6");

        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("7");

        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("8");

        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("9");

        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo(".");

        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            AgregarNumeroAlCodigo("0");

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                txtCodigo.Text = txtCodigo.Text.Remove(txtCodigo.Text.Length - 1);
            }
        }
        private void AgregarNumeroAlCodigo(string numero)
        {
            txtCodigo.Text += numero;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodigo.Text;

            // Obtener los datos del negocio, incluido el código de seguridad, desde la capa de datos
            Negocio negocio = new CN_Negocio().ObtenerDatos();

            // Verificar si el código ingresado coincide con el código seguro obtenido
            if (codigoIngresado.SequenceEqual(negocio.CodigoSeguridad))
            {
                // Cerrar el formulario de código de seguridad
                this.Dispose();

                // Cerrar el formulario principal FrmInicioClientes si está abierto
                FrmInicioClientes principalClientes = Application.OpenForms.OfType<FrmInicioClientes>().FirstOrDefault();
                principalClientes?.Dispose();

                // Cerrar el formulario principal FrmBusquedaCategoria si está abierto
                FrmBusquedaCategoria principalCategorias = Application.OpenForms.OfType<FrmBusquedaCategoria>().FirstOrDefault();
                principalCategorias?.Dispose();

                // Verificar si el formulario de inicio ya está abierto
                FrmInicio frmInicio = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();

                if (frmInicio != null)
                {
                    // Si el formulario de inicio está abierto pero oculto, simplemente mostrarlo
                    frmInicio.Show();
                    frmInicio.WindowState = FormWindowState.Maximized; // Asegurarse de que el formulario esté en estado normal
                }
                else
                {
                    // Si el formulario de inicio no está abierto, crear una nueva instancia y mostrarla
                    frmInicio = new FrmInicio();
                    frmInicio.Show();
                }
            }
            else
            {
                // Código incorrecto, puedes manejar esta lógica según tus necesidades
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
