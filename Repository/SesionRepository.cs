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

        public async Task<List<Sesion>> GetAllAsync()
        {
            return await _context.Sesiones
                .Include(s => s.Usuario)
                .Include(s => s.Tutor)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .Include(s => s.OpcionServicio)
                .Include(s => s.Centro)
                .ToListAsync();
        }

        public async Task<Sesion?> GetByIdAsync(int id)
        {
            return await _context.Sesiones
                .Include(s => s.Usuario)
                .Include(s => s.Tutor)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .Include(s => s.OpcionServicio)
                .Include(s => s.Centro)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<List<Sesion>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Sesiones
                .Where(s => s.ID_USUARIO == usuarioId)
                .Include(s => s.Usuario)
                .Include(s => s.Tutor)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .Include(s => s.OpcionServicio)
                .Include(s => s.Centro)
                .ToListAsync();
        }

        public async Task<List<Sesion>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.Sesiones
                .Where(s => s.ID_EMPLEADO == empleadoId)
                .Include(s => s.Usuario)
                .Include(s => s.Tutor)
                .Include(s => s.Empleado)
                .Include(s => s.Servicio)
                .Include(s => s.OpcionServicio)
                .Include(s => s.Centro)
                .ToListAsync();
        }

        public async Task AddAsync(Sesion sesion)
        {
            await _context.Sesiones.AddAsync(sesion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sesion sesion)
        {
            var existingSesion = await _context.Sesiones.FindAsync(sesion.ID);

            if (existingSesion != null)
            {
                existingSesion.FECHA = sesion.FECHA;
                existingSesion.ID_USUARIO = sesion.ID_USUARIO;
                existingSesion.ID_TUTOR = sesion.ID_TUTOR;
                existingSesion.ID_EMPLEADO = sesion.ID_EMPLEADO;
                existingSesion.ID_SERVICIO = sesion.ID_SERVICIO;
                existingSesion.ID_OPCION_SERVICIO = sesion.ID_OPCION_SERVICIO;
                existingSesion.ID_CENTRO = sesion.ID_CENTRO;
                existingSesion.FACTURAR = sesion.FACTURAR;

                await _context.SaveChangesAsync();
            }
        }

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
