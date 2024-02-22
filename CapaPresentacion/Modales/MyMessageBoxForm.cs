using CapaEntidad;
using Irony;
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
    public partial class MyMessageBoxForm : Form
    {
        public static DateTime LastActivityTime { get; set; } // Definir como variable estática

        private DateTime lastActivityTime;
        private int inactivityThreshold = 15; // Umbral de inactividad en segundos


        public MyMessageBoxForm(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;

            lastActivityTime = DateTime.Now; // Registra la hora de inicio


        }


        private void MyMessageBoxForm_Load(object sender, EventArgs e)
        {
            InactivityTimerManager.InactivityDetected += HandleInactivity;

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            CompraTemp.ReiniciarCompraTemp(); // Reiniciar la compra temporal aquí
            Close();

        }

        private void picSi_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void HandleInactivity()
        {
            TimeSpan elapsed = DateTime.Now - lastActivityTime;

            if (elapsed.TotalSeconds >= inactivityThreshold)
            {
                // Muestra el mensaje o realiza una acción necesaria
                // ...

                // Cierra el formulario
                Close();
            }

        }
        private void picNo_Click(object sender, EventArgs e)
        {
            CompraTemp.ReiniciarCompraTemp(); // Reiniciar la compra temporal aquí
            Close();
        }

        private void MyMessageBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InactivityTimerManager.InactivityDetected -= HandleInactivity;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;

        }
    }
}
