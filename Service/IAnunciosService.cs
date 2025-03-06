using Models;

namespace Service
{
    public interface IAnuncioService
    {
        Task<List<Anuncio>> GetAllAsync();
        Task<Anuncio> GetByIdAsync(int id);
        Task AddAsync(Anuncio anuncio); 
        Task UpdateAsync(Anuncio anuncio);
        Task DeleteAsync(int id);
    }
}
