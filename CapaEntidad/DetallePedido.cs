using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePedido
    {
        public int IdDetalleCompra { get; set; }
        public Producto oProducto { get; set; }
        public int Cantidad { get; set; }

        public string FechaRegistro { get; set; }
    }
}
