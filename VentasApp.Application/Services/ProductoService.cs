using Microsoft.EntityFrameworkCore;
using VentasApp.Core.Entities;
using VentasApp.Infrastructure;

namespace VentasApp.Application.Services
{
    public class ProductoService
    {
        private readonly VentasDbContext _context;

        public ProductoService(VentasDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerProductosAsync()
        {
            return await _context.Productos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producto> AgregarProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task CrearProductoAsync(string nombre, string Descripcion, decimal precio, int stock, int categoriaId)
        {
            var nuevoProducto = new Producto
            {
                Nombre = nombre,
                Descripcion = Descripcion,
                Precio = precio,
                Stock = stock,
                CategoriaId = categoriaId   // Asignar el ID de la categoría
            };

            // Agregar el nuevo producto a la base de datos
            _context.Productos.Add(nuevoProducto);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarProductoAsync(int productoId, string nombre, string descripcion, decimal precio, int stock, int categoriaId)
        {
            // Buscar el producto por ID
            var productoExistente = await _context.Productos.FindAsync(productoId);

            if (productoExistente != null)
            {
                // Actualizar las propiedades del producto
                productoExistente.Nombre = nombre;
                productoExistente.Descripcion = descripcion;
                productoExistente.Precio = precio;
                productoExistente.Stock = stock;
                productoExistente.CategoriaId = categoriaId;  // Actualizar la categoría

                // _context.Productos.Update(productoExistente);

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProducto(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProductoAsync(int productoId)
        {
            var producto = await _context.Productos.FindAsync(productoId);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}