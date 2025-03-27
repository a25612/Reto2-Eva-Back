using Models;
using Repositories;

namespace Service
{
    public class SesionService : ISesionService
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionService(ISesionRepository sesionRepository)
        {
            _sesionRepository = sesionRepository;
        }

        public async Task<List<Sesion>> GetAllAsync()
        {
            return await _sesionRepository.GetAllAsync();
        }

        public async Task<Sesion?> GetByIdAsync(int id)
        {
            return await _sesionRepository.GetByIdAsync(id);
        }
        public async Task<List<Sesion>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _sesionRepository.GetByUsuarioIdAsync(usuarioId);
        }

        public async Task<List<Sesion>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _sesionRepository.GetByEmpleadoIdAsync(empleadoId);
        }

        public async Task<List<Sesion>> GetByUsuarioIdAndFechaAsync(int usuarioId, DateTime fecha)
        {
            var startDate = fecha.Date; 
            var endDate = startDate.AddDays(1);

            return await _sesionRepository.GetByUsuarioIdAndFechaAsync(usuarioId, startDate, endDate);
        }

        public async Task<List<Sesion>> GetByEmpleadoIdAndFechaAsync(int empleadoId, DateTime fecha)
        {
            var startDate = fecha.Date;
            var endDate = startDate.AddDays(1);

            return await _sesionRepository.GetByEmpleadoIdAndFechaAsync(empleadoId, startDate, endDate);
        }


        public async Task AddAsync(Sesion sesion)
        {
            await _sesionRepository.AddAsync(sesion);
        }

        public async Task UpdateAsync(Sesion sesion)
        {
            await _sesionRepository.UpdateAsync(sesion);
        }

        public async Task DeleteAsync(int id)
        {
            await _sesionRepository.DeleteAsync(id);
        }
    }
}

