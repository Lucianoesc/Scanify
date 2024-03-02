using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SubCategoria2
    {
        public int IdSubCategoria2 { get; set; }
        public string Descripcion { get; set; }
        public SubCategoria oSubCategoria { get; set; }

        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
        public byte[] FotoSubCategoria2 { get; set; }
    }
}
