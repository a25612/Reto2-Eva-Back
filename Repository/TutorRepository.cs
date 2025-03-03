using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly MyDbContext _context;

        public TutorRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tutor>> GetAllAsync()
        {
            return await _context.Tutores.ToListAsync();
        }

        public async Task<Tutor?> GetByIdAsync(int id)
        {
            return await _context.Tutores.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Tutor tutor)
        {
            await _context.Tutores.AddAsync(tutor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetUsuariosByTutorIdAsync(int tutorId)
        {
            return await _context.Usuarios
                .Where(u => u.UsuariosTutores.Any(ut => ut.ID_TUTOR == tutorId))
                .ToListAsync();
        }
        public async Task UpdateAsync(Tutor tutor)
        {
            var existingTutor = await _context.Tutores.FindAsync(tutor.Id);

            if (existingTutor != null)
            {
                existingTutor.Nombre = tutor.Nombre;
                existingTutor.DNI = tutor.DNI;
                existingTutor.Email = tutor.Email;
                existingTutor.Username = tutor.Username;
                existingTutor.Password = tutor.Password;
                existingTutor.Activo = tutor.Activo;

                await _context.SaveChangesAsync();
            }
        }
    
        public async Task DeleteAsync(int id)
        {
            var tutor = await _context.Tutores.FindAsync(id);

            if (tutor != null)
            {
                _context.Tutores.Remove(tutor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tutor?> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await _context.Tutores.FirstOrDefaultAsync(t => t.Username == username && t.Password == password);
        }
    }
}