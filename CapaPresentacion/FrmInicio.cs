using CapaPresentacion.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmInicio : Form
    {
        private static FrmInicio instancia;


        public FrmInicio()
        {
            InitializeComponent();
            if (instancia != null)
            {
                this.Dispose();
                return;
            }
            instancia = this;


        }
        public static FrmInicio ObtenerInstancia()
        {
            return instancia;
        }

        public static void CerrarInstancia()
        {
            if (instancia != null)
            {
                instancia.Close();
                instancia = null;
            }
        }
        private void FrmInicio_Load(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().Where(f => f != this).ToList())
            {
                form.Close();
                form.Dispose();
            }



        }
       
        #region BtnConsumidor
        private void picConsumidor_MouseEnter(object sender, EventArgs e)
        {
            // Cuando el mouse entra al picturebox, iniciamos el temporizador
            timConsumidor.Start();

        }

        private void picConsumidor_MouseLeave(object sender, EventArgs e)
        {
            // Cuando el mouse sale del picturebox, detenemos el temporizador y restauramos el tamaño original
            timConsumidor.Stop();
            picConsumidor.Size = new Size(456, 427);

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            // En cada intervalo del temporizador, aumentamos el tamaño del picturebox en un pixel por cada lado
            int ancho = picConsumidor.Width;
            int alto = picConsumidor.Height;
            // Si el picturebox ya alcanzó el tamaño deseado, detenemos el temporizador
            if (ancho >= 486 || alto >= 457)
            {
                timConsumidor.Stop();
                return;
            }
            // Si no, incrementamos el tamaño en un pixel por cada lado
            picConsumidor.Size = new Size(ancho + 2, alto + 2);


        }
        #endregion
        #region BtnEmpleado
        private void picEmpleado_MouseEnter(object sender, EventArgs e)
        {
            timEmpleados.Start();
        }

        private void picEmpleado_MouseLeave(object sender, EventArgs e)
        {
            timEmpleados.Stop();
            picEmpleado.Size = new Size(435, 335);
        }

        private void timEmpleados_Tick(object sender, EventArgs e)
        {
            int ancho = picEmpleado.Width;
            int alto = picEmpleado.Height;
            if (ancho >= 465 || alto >= 365)
            {
                timEmpleados.Stop();
                return;
            }
            picEmpleado.Size = new Size(ancho + 2, alto + 2);
        }
        #endregion
        #region BtnAyuda
        private void picAyuda_MouseEnter(object sender, EventArgs e)
        {
            timAyuda.Start();
        }
        public static void CerrarInstancias()
        {
            if (instancia != null && !instancia.IsDisposed)
            {
                instancia.Close();
            }
        }
        private void picAyuda_MouseLeave(object sender, EventArgs e)
        {
            timAyuda.Stop();
            picAyuda.Size = new Size(441, 335);
        }

        private void timAyuda_Tick(object sender, EventArgs e)
        {
            int ancho = picAyuda.Width;
            int alto = picAyuda.Height;
            if (ancho >= 471 || alto >= 365)
            {
                timAyuda.Stop();
                return;
            }
            picAyuda.Size = new Size(ancho + 2, alto + 2);
        }
        #endregion

        private void picEmpleado_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();

            FrmLogin form = new FrmLogin();

            form.ShowDialog();
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
        }

        private void picConsumidor_Click(object sender, EventArgs e)
        {
            
        }

        private void picConsumidor_DoubleClick(object sender, EventArgs e)
        {
            // Verificar si ya hay una instancia del formulario activa
            FrmPantallaPrincipalClientes frm = Application.OpenForms.OfType<FrmPantallaPrincipalClientes>().FirstOrDefault();

            if (frm == null)
            {
                // Si no hay una instancia activa, crear una nueva instancia y mostrar el formulario
                frm = new FrmPantallaPrincipalClientes();
                frm.Show();
            }
            else
            {
                // Si ya existe una instancia activa, enfocarla en lugar de crear una nueva
                frm.Focus();
            }

            // Opcionalmente, puedes ocultar el formulario actual si es necesario
            this.Hide();
        }

        private void FrmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmInicio principal = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();
            principal?.Dispose();
            this.Close();

        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {
            
            Md_SalirInicio frm = new Md_SalirInicio();

            frm.ShowDialog();
        }

        private void picAyuda_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/document/d/1KXuD5Y0N_NBcDsiL5ACNC5QhkETvGPr6h4lfRHuUYMI/edit?hl=es-419");

        }   
        
        private void FrmInicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmInicio principal = Application.OpenForms.OfType<FrmInicio>().FirstOrDefault();
            principal?.Dispose();
            this.Close();
        }
    }
}
