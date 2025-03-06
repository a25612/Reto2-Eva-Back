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
                .Select(s => new Sesion
                {
                    ID = s.ID,
                    FECHA = s.FECHA,
                    FACTURAR = s.FACTURAR,
                    ID_USUARIO = s.ID_USUARIO,
                    Usuario = s.Usuario,
                    ID_TUTOR = s.ID_TUTOR,
                    Tutor = s.Tutor,
                    ID_EMPLEADO = s.ID_EMPLEADO,
                    Empleado = s.Empleado,
                    ID_SERVICIO = s.ID_SERVICIO,
                    Servicio = s.Servicio,
                    ID_OPCION_SERVICIO = s.ID_OPCION_SERVICIO,
                    OpcionServicio = s.OpcionServicio,
                    ID_CENTRO = s.ID_CENTRO,
                    Centro = s.Centro
                })
                .ToListAsync();
        }

        // Obtener sesión por ID
        public async Task<Sesion> GetByIdAsync(int id)
        {
            return await _context.Sesiones
                .Where(s => s.ID == id)
                .Select(s => new Sesion
                {
                    ID = s.ID,
                    FECHA = s.FECHA,
                    FACTURAR = s.FACTURAR,
                    ID_USUARIO = s.ID_USUARIO,
                    Usuario = s.Usuario,
                    ID_TUTOR = s.ID_TUTOR,
                    Tutor = s.Tutor,
                    ID_EMPLEADO = s.ID_EMPLEADO,
                    Empleado = s.Empleado,
                    ID_SERVICIO = s.ID_SERVICIO,
                    Servicio = s.Servicio,
                    ID_OPCION_SERVICIO = s.ID_OPCION_SERVICIO,
                    OpcionServicio = s.OpcionServicio,
                    ID_CENTRO = s.ID_CENTRO,
                    Centro = s.Centro
                })
                .FirstOrDefaultAsync();
        }

        // Obtener sesiones por usuarioId
        public async Task<List<Sesion>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Sesiones
                .Where(s => s.ID_USUARIO == usuarioId)
                .Select(s => new Sesion
                {
                    ID = s.ID,
                    FECHA = s.FECHA,
                    FACTURAR = s.FACTURAR,
                    ID_USUARIO = s.ID_USUARIO,
                    Usuario = s.Usuario,
                    ID_TUTOR = s.ID_TUTOR,
                    Tutor = s.Tutor,
                    ID_EMPLEADO = s.ID_EMPLEADO,
                    Empleado = s.Empleado,
                    ID_SERVICIO = s.ID_SERVICIO,
                    Servicio = s.Servicio,
                    ID_OPCION_SERVICIO = s.ID_OPCION_SERVICIO,
                    OpcionServicio = s.OpcionServicio,
                    ID_CENTRO = s.ID_CENTRO,
                    Centro = s.Centro
                })
                .ToListAsync();
        }

        // Obtener sesiones por empleadoId
        public async Task<List<Sesion>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.Sesiones
                .Where(s => s.ID_EMPLEADO == empleadoId)
                .Select(s => new Sesion
                {
                    ID = s.ID,
                    FECHA = s.FECHA,
                    FACTURAR = s.FACTURAR,
                    ID_USUARIO = s.ID_USUARIO,
                    Usuario = s.Usuario,
                    ID_TUTOR = s.ID_TUTOR,
                    Tutor = s.Tutor,
                    ID_EMPLEADO = s.ID_EMPLEADO,
                    Empleado = s.Empleado,
                    ID_SERVICIO = s.ID_SERVICIO,
                    Servicio = s.Servicio, 
                    ID_OPCION_SERVICIO = s.ID_OPCION_SERVICIO, 
                    OpcionServicio=s.OpcionServicio, 
                    ID_CENTRO=s.ID_CENTRO, 
                    Centro=s.Centro 
                })
                .ToListAsync();
        }

        // Añadir nueva sesión
        public async Task AddAsync(Sesion sesion)
        {
            await _context.Sesiones.AddAsync(sesion);
            await _context.SaveChangesAsync();
        }

        // Actualizar sesión existente
        public async Task UpdateAsync(Sesion sesion)
        {
            var existingSesion=await _context.Sesiones.FindAsync(sesion.ID);
            if(existingSesion!=null)
            {
                existingSesion.FECHA=sesion.FECHA;
                existingSesion.ID_USUARIO=sesion.ID_USUARIO;
                existingSesion.ID_TUTOR=sesion.ID_TUTOR;
                existingSesion.ID_EMPLEADO=sesion.ID_EMPLEADO;
                existingSesion.ID_SERVICIO=sesion.ID_SERVICIO;
                existingSesion.ID_OPCION_SERVICIO=sesion.ID_OPCION_SERVICIO;
                existingSesion.ID_CENTRO=sesion.ID_CENTRO;
                existingSesion.FACTURAR=sesion.FACTURAR;

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar sesión por id
        public async Task DeleteAsync(int id)
        {
            var sesion=await _context.Sesiones.FindAsync(id);
            if(sesion!=null)
            {
                _context.Sesiones.Remove(sesion);
                await _context.SaveChangesAsync();
            }
        }
    }
}