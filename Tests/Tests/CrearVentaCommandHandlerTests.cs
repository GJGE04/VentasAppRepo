using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Application.Commands;
using VentasApp.Core.Entities;
using VentasApp.Application.Handlers;
using VentasApp.Infrastructure;

namespace Tests.Tests
{
    public class CrearVentaCommandHandlerTests
    {
        private readonly Mock<VentasDbContext> _contextMock;
        private readonly CrearVentaCommandHandler _handler;

        public CrearVentaCommandHandlerTests()
        {
            // Usar base de datos en memoria para pruebas
            //var options = new DbContextOptionsBuilder<VentasDbContext>()
            //    .UseInMemoryDatabase("TestDb")  // Usar base de datos en memoria para pruebas
            //    .Options;

            //_contextMock = new Mock<VentasDbContext>(options);
            //_handler = new CrearVentaCommandHandler(_contextMock.Object);
        }

        [Fact]
        public async Task Handle_CreaVenta_Exitosamente()
        {
            // Arrange
            var producto = new Producto { Id = 1, Nombre = "Producto A", Precio = 10m, Stock = 100 };
            _contextMock.Object.Productos.Add(producto);
            await _contextMock.Object.SaveChangesAsync();

            var ventaDetalles = new List<VentaDetalle>
        {
            new VentaDetalle { ProductoId = 1, Cantidad = 2, PrecioUnitario = 10m, MontoTotal = 20m }
        };

            var comando = new CrearVentaCommand
            {
                VentaDetalles = ventaDetalles,
                Total = 20m
            };

            // Act
            var ventaId = await _handler.Handle(comando, System.Threading.CancellationToken.None);

            // Assert
            Assert.True(ventaId > 0, "La venta no fue creada correctamente.");
            //Assert.Equal(98, producto.Stock, "El stock no se actualizó correctamente.");
        }
    }
}
