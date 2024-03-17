using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ModalSalirDashboard : Form
    {
        public ModalSalirDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ModalSalirDashboard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, 0, 0, Width - 1, 0);
            e.Graphics.DrawLine(Pens.Black, 0, 0, 0, Height - 1);
            e.Graphics.DrawLine(Pens.Black, Width - 1, 0, Width - 1, Height - 1);
            e.Graphics.DrawLine(Pens.Black, 0, Height - 1, Width - 1, Height - 1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
                form.Dispose();
            }

            // Detén todos los procesos en segundo plano
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    // Maneja cualquier excepción que pueda ocurrir al intentar detener un proceso
                    Console.WriteLine($"Error al detener el proceso {process.ProcessName}: {ex.Message}");
                }
            }

            // Libera recursos no administrados
            // Por ejemplo, cierra conexiones de bases de datos, archivos temporales, etc.
            // Asegúrate de incluir aquí el código para liberar cualquier recurso no administrado

            // Cierra la aplicación
            Environment.Exit(0);

            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            this.Dispose();
            this.Close();


        }
    }
}
