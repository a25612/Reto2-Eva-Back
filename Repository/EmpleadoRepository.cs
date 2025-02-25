using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly MyDbContext _context;

        public EmpleadoRepository(MyDbContext context)
        {
            _context = context;
        }

        // Obtener todos los empleados con sus centros relacionados
        public async Task<List<Empleado>> GetAllAsync()
        {
            return await _context.Empleados
                .Include(e => e.EmpleadosCentros)
                .ThenInclude(ec => ec.Centro)
                .ToListAsync();
        }

        // Obtener un empleado por su ID con sus centros relacionados
        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados
                .Include(e => e.EmpleadosCentros)
                .ThenInclude(ec => ec.Centro)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // Agregar un nuevo empleado
        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        // Actualizar un empleado existente
        public async Task UpdateAsync(Empleado empleado)
        {
            var existingEmpleado = await _context.Empleados.FindAsync(empleado.Id);

            if (existingEmpleado != null)
            {
                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.DNI = empleado.DNI;
                existingEmpleado.JornadaTotalHoras = empleado.JornadaTotalHoras;
                existingEmpleado.Username = empleado.Username;
                existingEmpleado.Password = empleado.Password;

                await _context.SaveChangesAsync();
            }
        }

        // Actualizar un empleado y sus centros asociados
        public async Task UpdateWithCentrosAsync(Empleado empleado, List<int> centroIds)
        {
            var existingEmpleado = await _context.Empleados
                .Include(e => e.EmpleadosCentros) // Incluir la relación con la tabla intermedia
                .FirstOrDefaultAsync(e => e.Id == empleado.Id);

            if (existingEmpleado != null)
            {
                // Actualizar los datos del empleado
                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.DNI = empleado.DNI;
                existingEmpleado.JornadaTotalHoras = empleado.JornadaTotalHoras;
                existingEmpleado.Username = empleado.Username;
                existingEmpleado.Password = empleado.Password;

                // Eliminar las relaciones existentes con centros
                var currentCentros = existingEmpleado.EmpleadosCentros.ToList();
                foreach (var centro in currentCentros)
                {
                    _context.EmpleadosCentros.Remove(centro);
                }

                // Agregar las nuevas relaciones con centros
                foreach (var centroId in centroIds)
                {
                    var nuevoCentro = new EmpleadosCentros
                    {
                        ID_EMPLEADO = empleado.Id,
                        ID_CENTRO = centroId
                    };
                    _context.EmpleadosCentros.Add(nuevoCentro);
                }

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
        }

        // Eliminar un empleado por su ID
        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                // Eliminar las relaciones en la tabla intermedia primero
                var EmpleadosCentros = _context.EmpleadosCentros.Where(ec => ec.ID_EMPLEADO == id);
                _context.EmpleadosCentros.RemoveRange(EmpleadosCentros);

                // Eliminar el empleado
                _context.Empleados.Remove(empleado);
                
                await _context.SaveChangesAsync();
            }
        }

        // Obtener un empleado por su username y password
        public async Task<Empleado?> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Username == username && e.Password == password);
        }
    }
}
