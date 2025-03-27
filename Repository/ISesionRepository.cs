using Models;
namespace Repositories
{
    public interface ISesionRepository
    {
        Task<List<Sesion>> GetAllAsync();
        Task<Sesion?> GetByIdAsync(int id);
        Task<List<Sesion>> GetByUsuarioIdAsync(int usuarioId);
        Task<List<Sesion>> GetByEmpleadoIdAsync(int empleadoId);
        Task<List<Sesion>> GetByUsuarioIdAndFechaAsync(int usuarioId, DateTime startDate, DateTime endDate);
        Task<List<Sesion>> GetByEmpleadoIdAndFechaAsync(int empleadoId, DateTime startDate, DateTime endDate);
        
        Task AddAsync(Sesion sesion);
        Task UpdateAsync(Sesion sesion);
        Task DeleteAsync(int id);
    }
}
