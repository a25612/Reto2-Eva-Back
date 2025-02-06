using Models;

namespace Pisicna_Back.Repositories
{
    public interface IServiciosRepository
    {
        Task<List<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(int id);
    }
}
