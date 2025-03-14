using Models;
using Repository;


namespace Service
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _repository;

        public PagoService(IPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Pago>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Pago> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Pago pago)
        {
            await _repository.AddAsync(pago);
        }

        public async Task UpdateAsync(Pago pago)
        {
            await _repository.UpdateAsync(pago);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
