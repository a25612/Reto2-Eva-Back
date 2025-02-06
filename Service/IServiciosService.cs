using Models;

namespace Pisicna_Back.Service
{
    public interface IServiciosService
    {
        Task<List<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(int id);
    }
}
