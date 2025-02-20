using Models;
using Pisicna_Back.Repositories;

namespace Pisicna_Back.Service
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repository;

        public TutorService(ITutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tutor?> LoginAsync(string username, string password)
        {
            return await _repository.GetByUsernameAndPasswordAsync(username, password);
        }

        public async Task<List<Tutor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tutor?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Tutor tutor)
        {
            await _repository.AddAsync(tutor);
        }

        public async Task UpdateAsync(Tutor tutor)
        {
            await _repository.UpdateAsync(tutor);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
