using Models;

namespace Repository
{
    public interface ICentroRepository
    {
        Task<List<Centro>> GetAllAsync();
        Task<Centro> GetByIdAsync(int id);
        Task<Centro> AddAsync(Centro centro);
        Task UpdateAsync(Centro centro);
        Task DeleteAsync(int id);
    }
}
