using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class SesionRepository : ISesionRepository
    {
        private readonly MyDbContext _context;

        public SesionRepository(MyDbContext context)
        {
            _context = context;
        }

        // Obtener todas las sesiones
        public async Task<List<Sesion>> GetAllAsync()
        {
            return await _context.Sesiones
                .Include(s => s.Usuario)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .ToListAsync();
        }

        // Obtener una sesión por ID
        public async Task<Sesion?> GetByIdAsync(int id)
        {
            return await _context.Sesiones
                .Include(s => s.Usuario)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Obtener sesiones por ID de usuario
        public async Task<List<Sesion>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Sesiones
                .Where(s => s.ID_USUARIO == usuarioId)
                .Include(s => s.Usuario)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .ToListAsync();
        }

        // Obtener sesiones por ID de empleado
        public async Task<List<Sesion>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.Sesiones
                .Where(s => s.ID_EMPLEADO == empleadoId)
                .Include(s => s.Usuario)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .ToListAsync();
        }

        // Agregar una nueva sesión
        public async Task AddAsync(Sesion sesion)
        {
            await _context.Sesiones.AddAsync(sesion);
            await _context.SaveChangesAsync();
        }

        // Actualizar una sesión existente
        public async Task UpdateAsync(Sesion sesion)
        {
            var existingSesion = await _context.Sesiones.FindAsync(sesion.Id);

            if (existingSesion != null)
            {
                existingSesion.Fecha = sesion.Fecha;
                existingSesion.ID_USUARIO = sesion.ID_USUARIO;
                existingSesion.ID_EMPLEADO = sesion.ID_EMPLEADO;
                existingSesion.ID_SERVICIO = sesion.ID_SERVICIO;
                existingSesion.Facturar = sesion.Facturar;

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar una sesión por ID
        public async Task DeleteAsync(int id)
        {
            var sesion = await _context.Sesiones.FindAsync(id);

            if (sesion != null)
            {
                _context.Sesiones.Remove(sesion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
