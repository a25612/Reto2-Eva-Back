using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class CentroRepository : ICentroRepository
    {
        private readonly MyDbContext _context;

        public CentroRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Centro>> GetAllAsync()
        {
            return await _context.Centros.ToListAsync();
        }

        public async Task<Centro> GetByIdAsync(int id)
        {
            return await _context.Centros.FindAsync(id);
        }

        public async Task<Centro> AddAsync(Centro centro)
        {
            _context.Centros.Add(centro);
            await _context.SaveChangesAsync();
            return centro;
        }

        public async Task UpdateAsync(Centro centro)
        {
            _context.Entry(centro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var centro = await _context.Centros.FindAsync(id);
            if (centro != null)
            {
                _context.Centros.Remove(centro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
