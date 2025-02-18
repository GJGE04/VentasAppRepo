using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Core.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        [Required]
        public int CategoriaId { get; set; }        // Clave foránea a la categoría
        public Categoria Categoria { get; set; }    // Relación con la entidad Categoria

        public ICollection<VentaDetalle> VentaDetalles { get; set; } 

        public Producto() { }

        public Producto(string nombre, string descripcion, decimal precio, int stock)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }
    }
}
