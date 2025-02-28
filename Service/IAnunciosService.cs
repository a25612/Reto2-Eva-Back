using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IAnuncioService
    {
        Task<List<Anuncio>> GetAllAsync();
        Task<Anuncio> GetByIdAsync(int id);
        Task<Anuncio> AddAsync(Anuncio anuncio);
        Task UpdateAsync(Anuncio anuncio);
        Task DeleteAsync(int id);
    }
}
