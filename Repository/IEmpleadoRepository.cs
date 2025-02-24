using Models;

namespace Repositories
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
        Task<Empleado> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
