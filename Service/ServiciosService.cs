using Models;
using Repositories;

namespace Service
{
    public class ServiciosService : IServiciosService
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServiciosService(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        public async Task<List<Servicio>> GetAllAsync()
        {
            return await _serviciosRepository.GetAllAsync();
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            return await _serviciosRepository.GetByIdAsync(id);
        }

        public async Task<List<Servicio>> GetServiciosByCentroIdAsync(int centroId)
        {
            return await _serviciosRepository.GetServiciosByCentroIdAsync(centroId);
        }

        public async Task<List<OpcionServicio>> GetOpcionesServicioAsync(int servicioId)
        {
            return await _serviciosRepository.GetOpcionesServicioAsync(servicioId);
        }

        public async Task AddAsync(Servicio servicio)
        {
            await _serviciosRepository.AddAsync(servicio);
        }

        public async Task UpdateAsync(Servicio servicio)
        {
            await _serviciosRepository.UpdateAsync(servicio);
        }

        public async Task DeleteAsync(int id)
        {
            var servicio = await _serviciosRepository.GetByIdAsync(id);
            if (servicio == null)
            {
                throw new KeyNotFoundException($"Servicio con ID {id} no encontrado.");
            }
            await _serviciosRepository.DeleteAsync(id);
        }
    }
}
