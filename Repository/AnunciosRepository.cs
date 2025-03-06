using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly MyDbContext _context;

        public AnuncioRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Anuncio>> GetAllAsync()
        {
            return await _context.Anuncios.ToListAsync();
        }

        public async Task<Anuncio> GetByIdAsync(int id)
        {
            return await _context.Anuncios.FindAsync(id);
        }

        public async Task AddAsync(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Anuncio anuncio)
        {
            _context.Anuncios.Update(anuncio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio != null)
            {
                _context.Anuncios.Remove(anuncio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
