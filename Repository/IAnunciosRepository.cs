using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAnuncioRepository
    {
        Task<List<Anuncio>> GetAllAsync();
        Task<Anuncio> GetByIdAsync(int id);
        Task<Anuncio> AddAsync(Anuncio anuncio);
        Task UpdateAsync(Anuncio anuncio);
        Task DeleteAsync(int id);
    }
}
