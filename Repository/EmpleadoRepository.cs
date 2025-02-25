using Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly MyDbContext _context;

        // Constructor que recibe el DbContext
        public EmpleadoRepository(MyDbContext context)
        {
            _context = context;
        }

        // Obtener todos los empleados
        public async Task<List<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        // Obtener un empleado por su ID
        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados
                .Include(e => e.Centro) 
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
                existingEmpleado.Centro = empleado.Centro;

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar un empleado por su ID
        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }

        // Obtener un empleado por su username y password
        public async Task<Empleado?> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.Empleados
                .FirstOrDefaultAsync(e => e.Username == username && e.Password == password);
        }
    }
}