using Models;
using Microsoft.EntityFrameworkCore;

namespace Pisicna_Back.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly MyDbContext _context;

        // Constructor que recibe el DbContext
        public UsuariosRepository(MyDbContext context)
        {
            _context = context;
        }

        // Obtener todos los usuarios
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Obtener un usuario por ID
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        // Agregar un nuevo usuario
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        // Actualizar un usuario existente
        public async Task UpdateAsync(Usuario usuario)
        {
            var existingUsuario = await _context.Usuarios.FindAsync(usuario.Id);

            if (existingUsuario != null)
            {
                existingUsuario.Nombre = usuario.Nombre;
                existingUsuario.DNI = usuario.DNI;
                existingUsuario.CodigoFacturacion = usuario.CodigoFacturacion;

                await _context.SaveChangesAsync();
            }
        }

        // Eliminar un usuario por ID
        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
