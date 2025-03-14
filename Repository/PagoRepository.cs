using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository
{
    public class PagoRepository : IPagoRepository
    {
        private readonly MyDbContext _context;

        public PagoRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pago>> GetAllAsync()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pago> GetByIdAsync(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task AddAsync(Pago pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pago pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();
            }
        }
    }
}