using Models;

namespace Service
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task UpdateWithCentrosAsync(Empleado empleado, List<int> centroIds); 
        Task<Empleado?> LoginAsync(string username, string password);
        Task DeleteAsync(int id);
    }
}
