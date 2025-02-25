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
        Task DeleteAsync(int id);
    }
}
