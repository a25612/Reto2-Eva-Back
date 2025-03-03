using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly MyDbContext _context;

        public ServiciosRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servicio>> GetAllAsync()
        {
            return await _context.Servicios
                .Include(s => s.ServiciosCentros)
                    .ThenInclude(sc => sc.Centro)
                .Include(s => s.Opciones)
                .ToListAsync();
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _context.Servicios
                .Include(s => s.ServiciosCentros)
                    .ThenInclude(sc => sc.Centro)
                .Include(s => s.Opciones)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Servicio>> GetServiciosByCentroIdAsync(int centroId)
        {
            return await _context.Servicios
                .Where(s => s.ServiciosCentros.Any(sc => sc.IdCentro == centroId))
                .Include(s => s.Opciones)
                .ToListAsync();
        }

        public async Task<List<OpcionServicio>> GetOpcionesServicioAsync(int servicioId)
        {
            return await _context.OpcionesServicio
                .Where(os => os.IdServicio == servicioId)
                .ToListAsync();
        }

        public async Task AddAsync(Servicio servicio)
        {
            await _context.Servicios.AddAsync(servicio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Servicio servicio)
        {
            var existingServicio = await _context.Servicios
                .Include(s => s.ServiciosCentros)
                .Include(s => s.Opciones)
                .FirstOrDefaultAsync(s => s.Id == servicio.Id);

            if (existingServicio != null)
            {
                existingServicio.Nombre = servicio.Nombre;
                existingServicio.Descripcion = servicio.Descripcion;
                existingServicio.Activo = servicio.Activo;

                _context.ServiciosCentros.RemoveRange(existingServicio.ServiciosCentros);
                foreach (var servicioCentro in servicio.ServiciosCentros)
                {
                    await _context.ServiciosCentros.AddAsync(new ServicioCentro
                    {
                        ID_SERVICIO = existingServicio.Id,
                        IdCentro = servicioCentro.IdCentro
                    });
                }

                _context.OpcionesServicio.RemoveRange(existingServicio.Opciones);
                foreach (var opcion in servicio.Opciones)
                {
                    opcion.IdServicio = existingServicio.Id;
                    await _context.OpcionesServicio.AddAsync(opcion);
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var servicio = await _context.Servicios
                .Include(s => s.ServiciosCentros)
                .Include(s => s.Opciones)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (servicio != null)
            {
                _context.ServiciosCentros.RemoveRange(servicio.ServiciosCentros);
                _context.OpcionesServicio.RemoveRange(servicio.Opciones);
                _context.Servicios.Remove(servicio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
