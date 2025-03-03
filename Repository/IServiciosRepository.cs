using Models;

namespace Repositories
{
    public interface IServiciosRepository
    {
        Task<List<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task<List<Servicio>> GetServiciosByCentroIdAsync(int centroId);
        Task AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(int id);
        Task<List<OpcionServicio>> GetOpcionesServicioAsync(int servicioId);
    }
}
