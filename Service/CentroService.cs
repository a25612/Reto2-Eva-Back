using Models;
using Repository;


namespace Service
{
    public class CentroService : ICentroService
    {
        private readonly ICentroRepository _repository;

        public CentroService(ICentroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Centro>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Centro> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Centro> AddAsync(Centro centro)
        {
            return await _repository.AddAsync(centro);
        }

        public async Task UpdateAsync(Centro centro)
        {
            await _repository.UpdateAsync(centro);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
