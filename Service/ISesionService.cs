using Models;

namespace Service
{
    public interface ISesionService
{
    Task<List<Sesion>> GetAllAsync();
    Task<List<Sesion>> GetByUsuarioIdAsync(int idUsuario);
    Task<List<Sesion>> GetByEmpleadoIdAsync(int idEmpleado);
    Task<Sesion> GetByIdAsync(int id);
    Task AddAsync(Sesion sesion); 
    Task UpdateAsync(Sesion sesion);
    Task DeleteAsync(int id);
}

}
