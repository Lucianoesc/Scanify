using MaterialSkin.Controls;
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

namespace CapaPresentacion.Modales
{
    public partial class Md_SalirInicio : MaterialForm
    {
        public Md_SalirInicio()
        {
            InitializeComponent();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {// Cierra todas las ventanas y formularios abiertos
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

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
