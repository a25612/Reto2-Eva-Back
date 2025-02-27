using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface ICentroService
    {
        Task<List<Centro>> GetAllAsync();
        Task<Centro> GetByIdAsync(int id);
        Task<Centro> AddAsync(Centro centro);
        Task UpdateAsync(Centro centro);
        Task DeleteAsync(int id);
    }
}
