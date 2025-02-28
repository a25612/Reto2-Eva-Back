using Models;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _repository;

        public AnuncioService(IAnuncioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Anuncio>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Anuncio> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Anuncio> AddAsync(Anuncio anuncio)
        {
            return await _repository.AddAsync(anuncio);
        }

        public async Task UpdateAsync(Anuncio anuncio)
        {
            await _repository.UpdateAsync(anuncio);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
