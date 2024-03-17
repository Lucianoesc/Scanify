using CapaPresentacion.Modales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer; // Agrega esta línea para especificar que estás utilizando el Timer de Windows Forms

namespace CapaPresentacion
{
    public class ActivityTimer
    {
        private static List<ActivityTimer> instances = new List<ActivityTimer>();

        private Timer timer; // Usa el Timer de Windows Forms
        private int duration = 9000; // Duración en milisegundos (5 minutos en este ejemplo)

        // Define el evento InactivityDetected
        public event EventHandler InactivityDetected;

        // Propiedad estática para obtener la instancia única del cronómetro
        public static ActivityTimer GetInstance()
        {// Cerrar todas las instancias existentes antes de crear una nueva
            CloseAllInstances();

            // Crear una nueva instancia
            var instance = new ActivityTimer();
            instances.Add(instance);

            return instance;
        }
        private static void CloseAllInstances()
        {
            foreach (var instance in instances)
            {
                instance.Stop();
            }
            instances.Clear();
        }
        private ActivityTimer()
        {
            // Inicializar el temporizador
            timer = new Timer();
            timer.Interval = duration;
            timer.Tick += Timer_Tick; // Usar el evento Tick para el Timer de Windows Forms
            timer.Enabled = true; // Habilitar el temporizador
        }

        public void Start()
        {
            // Iniciar el temporizador
            timer.Start();
        }

        public void Stop()
        {
            // Detener el temporizador
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Invocar el evento InactivityDetected cuando se alcance el tiempo de inactividad
            InactivityDetected?.Invoke(this, EventArgs.Empty);
        }
    }
}
