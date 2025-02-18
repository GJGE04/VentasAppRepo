using Microsoft.EntityFrameworkCore;
using VentasApp.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VentasApp.Infrastructure
{
    public class VentasDbContext : DbContext
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Configurar las relaciones entre las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VentaDetalle>()
                .HasKey(vd => new { vd.VentaId, vd.ProductoId }); // Clave compuesta

            // Para Producto
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(18, 2); // 18 dígitos en total, 2 después del punto decimal

            // Para Venta
            modelBuilder.Entity<Venta>()
                .Property(v => v.Total)
                .HasPrecision(18, 2); // Ajusta según sea necesario

            // Para VentaDetalle
            modelBuilder.Entity<VentaDetalle>()
                .Property(vd => vd.MontoTotal)
                .HasPrecision(18, 2); // Ajusta según sea necesario

            modelBuilder.Entity<VentaDetalle>()
                .Property(vd => vd.PrecioUnitario)
                .HasPrecision(18, 2); // Ajusta según sea necesario

            // Para VentaProducto
            modelBuilder.Entity<VentaProducto>()
                .Property(vp => vp.Precio)
                .HasPrecision(18, 2); // Ajusta según sea necesario

            //// Configurar la relación entre Venta y VentaDetalle
            //modelBuilder.Entity<VentaDetalle>()
            //    .HasOne(vd => vd.Venta)
            //    .WithMany(v => v.VentaDetalles)
            //    .HasForeignKey(vd => vd.VentaId);

            //// Configurar la relación entre Producto y VentaDetalle
            //modelBuilder.Entity<VentaDetalle>()
            //    .HasOne(vd => vd.Producto)
            //    .WithMany(p => p.VentaDetalles)  
            //    .HasForeignKey(vd => vd.ProductoId);

            // Agregar categorías predeterminadas
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Electrónica" },
                new Categoria { Id = 2, Nombre = "Ropa" },
                new Categoria { Id = 3, Nombre = "Hogar" },
                new Categoria { Id = 4, Nombre = "Auto-partes" },
                new Categoria { Id = 5, Nombre = "Alimentos" },
                new Categoria { Id = 6, Nombre = "Ferretería" }
            );
        }
    }

    //Migraciones con Entity Framework

    //  1. Para crear una migración:                        dotnet ef migrations add InitialCreate
    //   o, si usas el Package Manager Console:             Add-Migration InitialCreate
    // Este comando generará una migración llamada InitialCreate, que contendrá las instrucciones necesarias para crear las tablas en la base de datos.

    //  2. Aplicar migración:
    //  Una vez que hayas generado la migración, debes aplicarla para crear las tablas en la base de datos. Ejecuta el siguiente comando:
    //                                                      dotnet ef database update
    //  o, si usas el Package Manager Console:              Update-Database
    //  Este comando actualizará la base de datos de acuerdo con las migraciones pendientes.

}