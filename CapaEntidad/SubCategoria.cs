using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SubCategoria
    {
        public int IdSubCategoria { get; set; }
        public string Descripcion { get; set; }
        public Categoria oCategoria { get; set; }

        public bool Estado { get; set; }
        public string FechaRegistro { get; set; }
        public byte[] FotoSubCategoria { get; set; }

    }
}
