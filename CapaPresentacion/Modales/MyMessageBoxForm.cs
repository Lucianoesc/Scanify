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
        private ActivityTimer activityTimer;

        private Timer decisionTimer;
        private int decisionDuration = 5000;
        public MyMessageBoxForm()
        {
            InitializeComponent();
            // Obtener la instancia existente del cronómetro
            activityTimer = ActivityTimer.GetInstance();
            activityTimer.Stop(); // Detener el cronómetro cuando se muestra el cuadro de diálogo

            // Iniciar el temporizador de decisión
            decisionTimer = new Timer();
            decisionTimer.Interval = decisionDuration;
            decisionTimer.Tick += DecisionTimer_Tick;
            decisionTimer.Start();


        }

        private void DecisionTimer_Tick(object sender, EventArgs e)
        {
            // El temporizador de decisión ha terminado
            // Detener el temporizador
            decisionTimer.Stop();
            activityTimer.Stop();
            CompraTemp.ReiniciarCompraTemp();

            // Detener el temporizador de decisión
            decisionTimer.Stop();

            // Cerrar el formulario con DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            this.Dispose();
            Close();
        }
        private void MyMessageBoxForm_Load(object sender, EventArgs e)
        {

        }



        private void picSi_Click(object sender, EventArgs e)
        {
            // El usuario ha elegido continuar la sesión
            // Detener el temporizador de decisión
            decisionTimer.Stop();

            // Cerrar el formulario
            DialogResult = DialogResult.OK;
            this.Dispose();

            Close();
        }

        private void picNo_Click(object sender, EventArgs e)
        {
            activityTimer.Stop();
            CompraTemp.ReiniciarCompraTemp();

            // Detener el temporizador de decisión
            decisionTimer.Stop();

            // Cerrar el formulario con DialogResult.Cancel
            DialogResult = DialogResult.Cancel;
            this.Dispose();

            Close();

        }

        private void MyMessageBoxForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           this.Dispose();
           activityTimer.Stop();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MyMessageBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            activityTimer.Stop();

        }
    }
}
