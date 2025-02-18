using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasApp.Core.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la categoría no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
