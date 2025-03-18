using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class UsuarioTutorRepository : IUsuarioTutorRepository
    {
        private readonly MyDbContext _context;

        public UsuarioTutorRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioTutor>> GetAllAsync()
        {
            return await _context.UsuariosTutores
                .Include(ut => ut.Usuario)
                .Include(ut => ut.Tutor)
                .ToListAsync();
        }

        public async Task<UsuarioTutor> GetByIdAsync(int id)
        {
            return await _context.UsuariosTutores
                .Include(ut => ut.Usuario)
                .Include(ut => ut.Tutor)
                .FirstOrDefaultAsync(ut => ut.Id == id);
        }

        public async Task<IEnumerable<UsuarioTutor>> GetByUsuarioIdAsync(int idUsuario)
        {
            return await _context.UsuariosTutores
                .Include(ut => ut.Usuario)
                .Include(ut => ut.Tutor)
                .Where(ut => ut.ID_USUARIO == idUsuario)
                .ToListAsync();
        }

        public async Task<IEnumerable<UsuarioTutor>> GetByTutorIdAsync(int idTutor)
        {
            return await _context.UsuariosTutores
                .Include(ut => ut.Usuario)
                .Include(ut => ut.Tutor)
                .Where(ut => ut.ID_TUTOR == idTutor)
                .ToListAsync();
        }

        public async Task AddAsync(UsuarioTutor usuarioTutor)
        {
            await _context.UsuariosTutores.AddAsync(usuarioTutor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioTutor usuarioTutor)
        {
            _context.UsuariosTutores.Update(usuarioTutor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuarioTutor = await GetByIdAsync(id);
            if (usuarioTutor != null)
            {
                _context.UsuariosTutores.Remove(usuarioTutor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
