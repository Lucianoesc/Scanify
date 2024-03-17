using CapaPresentacion.Properties;
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
    public partial class Form_Alertas : Form
    {
        public Form_Alertas()
        {
            InitializeComponent();
        }


        public enum enmAccion
        {
            espera,
            comienzo,
            cerrado
        }

        public enum enmType
        {
            Exito,
            Cuidado,
            Error,
            Info
        }
        private Form_Alertas.enmAccion accion;
        private int x, y;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            accion = enmAccion.cerrado;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.accion)
            {
                case enmAccion.espera:
                    timer1.Interval = 2000;
                    accion = enmAccion.cerrado;
                    break;
                case enmAccion.comienzo:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if(this.Opacity == 1.0)
                        {
                            accion = enmAccion.espera;
                        }
                    }
                    break;
                case enmAccion.cerrado:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if(base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void Form_Alertas_Load(object sender, EventArgs e)
        {

        }

        public void mostrarAlerta(string msg, enmType type)
        {

            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fnombre;
            for (int i = 1; i < 10; i++)
            {
                fnombre = "alerta" + i.ToString();
                Form_Alertas frm = (Form_Alertas)Application.OpenForms[fnombre];

                if (frm == null)
                {

                    this.Name = fnombre;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Exito:
                    this.pictureBox1.Image = Resources.correcto_png;
                    this.BackColor= Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Resources.erroralert_png;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Resources.informacion_png;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Cuidado:
                    this.pictureBox1.Image = Resources.peligro_png;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.lblMsg.Text = msg;
            this.TopMost = true;
            this.Show();
            this.accion = enmAccion.comienzo;
            this.timer1.Interval = 1;
            timer1.Start();
        }
    }
}
