using Models;
using Repositories;

namespace Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<List<Empleado>> GetAllAsync()
        {
            return await _empleadoRepository.GetAllAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _empleadoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Empleado empleado)
        {
            await _empleadoRepository.AddAsync(empleado);
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            await _empleadoRepository.UpdateAsync(empleado);
        }

        public async Task UpdateWithCentrosAsync(Empleado empleado, List<int> centroIds)
        {
            await _empleadoRepository.UpdateWithCentrosAsync(empleado, centroIds); 
        }

        public async Task DeleteAsync(int id)
        {
            await _empleadoRepository.DeleteAsync(id);
        }
    }
}
