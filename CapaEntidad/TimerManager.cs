using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad
{
    public class TimerManager
    {
        private static Timer _timer;
        private static int _timeoutSeconds = 15; // Cambia esto al valor deseado (15 segundos en tu caso)

        // Evento para manejar la inactividad detectada
        public static event Action InactivityDetected;

        public static void StartTimer()
        {
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Interval = _timeoutSeconds * 1000; // Convierte segundos a milisegundos
                _timer.Tick += (sender, e) =>
                {
                    InactivityDetected?.Invoke();
                    _timer.Stop();
                };
            }

            _timer.Start();
        }

        public static void ResetTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Start();
            }
        }

        public static void StopTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
            }
        }
    }

}
