using Models;

namespace Service
{
    public interface IServiciosService
{
    Task<List<Servicio>> GetAllAsync();
    Task<Servicio?> GetByIdAsync(int id);
    Task<List<Servicio>> GetServiciosByCentroIdAsync(int centroId);
    Task<List<OpcionServicio>> GetOpcionesServicioAsync(int servicioId);
    Task AddAsync(Servicio servicio);
    Task UpdateAsync(Servicio servicio);
    Task DeleteAsync(int id);
}

}
