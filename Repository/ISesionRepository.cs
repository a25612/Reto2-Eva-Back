using Models;

namespace Repositories
{
    public interface ISesionRepository
    {
        Task<List<Sesion>> GetAllAsync();
        Task<Sesion?> GetByIdAsync(int id);
        Task<List<Sesion>> GetByUsuarioIdAsync(int usuarioId);
        Task<List<Sesion>> GetByEmpleadoIdAsync(int empleadoId);
        Task AddAsync(Sesion sesion);
        Task UpdateAsync(Sesion sesion);
        Task DeleteAsync(int id);
    }
}
