using Microsoft.EntityFrameworkCore;
using VentasApp.Core.Entities;
using VentasApp.Infrastructure;

public class VentaService
{
    private readonly VentasDbContext _context;

    public VentaService(VentasDbContext context)
    {
        _context = context;
    }

    // Obtener todas las ventas
    public async Task<List<Venta>> GetVentas()
    {
        return await _context.Ventas.Include(v => v.VentaProductos)
                                    .ThenInclude(vp => vp.Producto)
                                    .ToListAsync();
    }

    // Obtener una venta por su ID
    public async Task<Venta> GetVentaById(int id)
    {
        return await _context.Ventas.Include(v => v.VentaProductos)
                                    .ThenInclude(vp => vp.Producto)
                                    .FirstOrDefaultAsync(v => v.Id == id);
    }

    // Crear una nueva venta
    public async Task AddVenta(Venta venta)
    {
        _context.Ventas.Add(venta);
        await _context.SaveChangesAsync();
    }

    // Actualizar una venta existente
    public async Task UpdateVenta(Venta venta)
    {
        _context.Ventas.Update(venta);
        await _context.SaveChangesAsync();
    }

    // Eliminar una venta
    public async Task DeleteVenta(int id)
    {
        var venta = await _context.Ventas.FindAsync(id);
        if (venta != null)
        {
            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
        }
    }


}
