using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly MyDbContext _context;

        // Constructor que recibe el DbContext
        public ServiciosRepository(MyDbContext context)
        {
            _context = context;
        }

        // Obtener todos los servicios
        public async Task<List<Servicio>> GetAllAsync()
        {
            // Cargar servicios junto con sus relaciones con Centros
            return await _context.Servicios
                .Include(s => s.ServiciosCentros) 
                .ThenInclude(sc => sc.Centro)   
                .ToListAsync();
        }

        // Obtener un servicio por ID
        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _context.Servicios
                .Include(s => s.ServiciosCentros) 
                .ThenInclude(sc => sc.Centro)    
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Agregar un nuevo servicio
        public async Task AddAsync(Servicio servicio)
        {
            // Agregar el servicio principal
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
        }

        // Actualizar un servicio existente
        public async Task UpdateAsync(Servicio servicio)
        {
            var existingServicio = await _context.Servicios
                .Include(s => s.ServiciosCentros) 
                .FirstOrDefaultAsync(s => s.Id == servicio.Id);

            if (existingServicio != null)
            {
                // Actualizar las propiedades del servicio principal
                existingServicio.Nombre = servicio.Nombre;
                existingServicio.Precio = servicio.Precio;

                // Eliminar las relaciones existentes en ServiciosCentros
                _context.ServiciosCentros.RemoveRange(existingServicio.ServiciosCentros);

                // Agregar las nuevas relaciones en ServiciosCentros (si hay cambios)
                foreach (var servicioCentro in servicio.ServiciosCentros)
                {
                    var nuevoServicioCentro = new ServicioCentro
                    {
                        ID_SERVICIO = existingServicio.Id,
                        IdCentro = servicioCentro.IdCentro
                    };
                    await _context.ServiciosCentros.AddAsync(nuevoServicioCentro);
                }

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar un servicio por ID
        public async Task DeleteAsync(int id)
        {
            var servicio = await _context.Servicios
                .Include(s => s.ServiciosCentros) 
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio != null)
            {
                // Eliminar las relaciones en ServiciosCentros primero
                _context.ServiciosCentros.RemoveRange(servicio.ServiciosCentros);

                // Eliminar el servicio principal
                _context.Servicios.Remove(servicio);

                await _context.SaveChangesAsync();
            }
        }
    }
}
