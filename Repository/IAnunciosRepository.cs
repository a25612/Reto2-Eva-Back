using Models;

namespace Repository
{
    public interface IAnuncioRepository
    {
        Task<List<Anuncio>> GetAllAsync();
        Task<Anuncio> GetByIdAsync(int id);
        Task AddAsync(Anuncio anuncio);
        Task UpdateAsync(Anuncio anuncio);
        Task DeleteAsync(int id);
    }

}
