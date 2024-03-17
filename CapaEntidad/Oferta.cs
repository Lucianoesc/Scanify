using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Oferta
    {
        public int IdOferta { get; set; }
        public string NombreOferta { get; set; }
        public decimal Descuento { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }
        public byte[] Foto { get; set; }
        public byte[] PantallaPrincipal { get; set; }

    }
}
