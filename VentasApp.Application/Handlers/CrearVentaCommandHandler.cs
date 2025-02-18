using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Application.Commands;
using VentasApp.Core.Entities;

namespace VentasApp.Application.Handlers
{
    public class CrearVentaCommandHandler : IRequestHandler<CrearVentaCommand, int>
    {
        // private readonly VentasDbContext _context;

        //public CrearVentaCommandHandler(VentasDbContext context)
        //{
        //    _context = context;
        //}

        public async Task<int> Handle(CrearVentaCommand request, CancellationToken cancellationToken)
        {
            if (request.VentaDetalles == null || !request.VentaDetalles.Any())
            {
                throw new ArgumentException("La venta debe tener al menos un detalle.");
            }

            var venta = new Venta
            {
                FechaVenta = DateTime.Now,
                //VentaDetalles = request.VentaDetalles,
                Total = request.Total
            };

            // Reducir el stock de cada producto involucrado en la venta
            foreach (var detalle in request.VentaDetalles)
            {
                //var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                //if (producto == null) throw new Exception($"Producto con ID {detalle.ProductoId} no encontrado.");

                //producto.Stock -= detalle.Cantidad;
            }

            //_context.Ventas.Add(venta);
            //await _context.SaveChangesAsync(cancellationToken);

            return venta.Id;  // Devolvemos el ID de la venta creada
        }
    }
}
