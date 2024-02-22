using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad
{
    public static class InactivityTimerManager
    {
        private static System.Threading.Timer inactivityTimer;
        private static int inactivityTimeout = 15000; // 15 segundos
        private static List<System.Threading.Timer> activeTimers = new List<System.Threading.Timer>();
        private static object lockObject = new object(); // Para sincronización de subprocesos

        public static event Action InactivityDetected;

        public static void Start()
        {
            lock (lockObject)
            {
                if (inactivityTimer == null)
                {
                    inactivityTimer = new System.Threading.Timer(InactivityCallback, null, inactivityTimeout, Timeout.Infinite);
                }
            }
        }

        public static void StopAllTimers()
        {
            lock (lockObject)
            {
                inactivityTimer?.Change(Timeout.Infinite, Timeout.Infinite);
                inactivityTimer?.Dispose();
                inactivityTimer = null;

                foreach (var timer in activeTimers)
                {
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                    timer.Dispose();
                }
                activeTimers.Clear();
            }
        }

        private static void InactivityCallback(object state)
        {
            InactivityDetected?.Invoke();
            lock (lockObject)
            {
                inactivityTimer.Change(inactivityTimeout, Timeout.Infinite);
            }
        }
    }
}