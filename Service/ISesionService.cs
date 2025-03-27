using Models;

namespace Service
{
    public interface ISesionService
    {
        Task<List<Sesion>> GetAllAsync();
        Task<List<Sesion>> GetByUsuarioIdAsync(int idUsuario);
        Task<List<Sesion>> GetByEmpleadoIdAsync(int idEmpleado);
        Task<Sesion> GetByIdAsync(int id);
        Task<List<Sesion>> GetByUsuarioIdAndFechaAsync(int usuarioId, DateTime fecha);
        Task<List<Sesion>> GetByEmpleadoIdAndFechaAsync(int empleadoId, DateTime fecha);
        Task AddAsync(Sesion sesion); 
        Task UpdateAsync(Sesion sesion);
        Task DeleteAsync(int id);
    }
}
