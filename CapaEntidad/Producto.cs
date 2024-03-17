﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public Categoria oCategoria { get; set; }
        public SubCategoria oSubCategoria { get; set; }
        public SubCategoria2 oSubCategoria2 { get; set; }
        public int Stock { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string InformacionNutricional { get; set; }
        public byte[] Foto { get; set; }
        public Oferta oOferta { get; set; }
        public int StockMinimo { get; set; }
        public int StockLimite { get; set; }
    }
}
