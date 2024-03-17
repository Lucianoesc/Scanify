using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidad
{
    public static class CompraTemp
    {
        public static bool DtgvComprasVisible { get; set; }
        public static List<string> DtgvComprasData { get; set; } = new List<string>();

        public static void ReiniciarCompraTemp()
        {
            DtgvComprasVisible = false;
            DtgvComprasData.Clear();
        }
    }
}
