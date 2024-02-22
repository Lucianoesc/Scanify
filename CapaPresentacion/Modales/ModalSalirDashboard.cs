using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ModalSalirDashboard : Form
    {
        public Form PreviousForm { get; set; }

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
            // Cerrar todos los formularios y finalizar la aplicación
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PreviousForm.Close(); // Cerrar el formulario anterior
            Close();              // Cerrar este formulario de confirmación


        }
    }
}
