using Models;

namespace Pisicna_Back.Service
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
        Task<Empleado> LoginAsync(string username, string password);
    }
}
