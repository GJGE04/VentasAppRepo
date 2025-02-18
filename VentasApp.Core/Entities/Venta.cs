using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Core.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public decimal Total { get; set; } 
        public DateTime FechaVenta { get; set; }
        public List<VentaProducto> VentaProductos { get; set; }
    }
}
