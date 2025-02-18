using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Core.Entities;
using VentasApp.Infrastructure;

namespace VentasApp.Application.Services
{
    public class CategoriaService
    {
        private readonly VentasDbContext _context;

        public CategoriaService(VentasDbContext context)
        {
            _context = context;
        }

        // Obtener todas las categorías
        public async Task<List<Categoria>> GetCategorias()
        {
            try
            {
                return await _context.Categorias.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las categorías", ex);
            }
        }

        // Obtener una categoría por su ID
        public async Task<Categoria> GetCategoriaById(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    throw new Exception($"Categoría con ID {id} no encontrada.");
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la categoría con ID {id}", ex);
                // throw new Exception($"Error al obtener la categoría con ID {id}: {ex.Message}");
            }
        }

        // Crear una nueva categoría
        public async Task AddCategoria(Categoria categoria)
        {
            try
            {
                _context.Categorias.Add(categoria);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al añadir la categoría", ex);
            }
            
        }

        // Actualizar una categoría existente
        public async Task UpdateCategoria(Categoria categoria)
        {
            try
            {
                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría", ex);
            }
        }

        // Eliminar una categoría
        public async Task DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la categoría", ex);
            }
        }

        public async Task UpdateCategoria2(Categoria categoria)
        {
            try
            {
                var categoriaExistente = await _context.Categorias.FindAsync(categoria.Id);
                if (categoriaExistente == null)
                {
                    throw new Exception("Categoría no encontrada para actualizar.");
                }

                categoriaExistente.Nombre = categoria.Nombre;
                _context.Categorias.Update(categoriaExistente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la categoría: " + ex.Message);
            }
        }

    }
}
