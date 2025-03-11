using Models;
using Repositories;

namespace Service
{
    public class UsuarioTutorService : IUsuarioTutorService
    {
        private readonly IUsuarioTutorRepository _repository;

        public UsuarioTutorService(IUsuarioTutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioTutor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UsuarioTutor> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UsuarioTutor>> GetByUsuarioIdAsync(int idUsuario)
        {
            return await _repository.GetByUsuarioIdAsync(idUsuario);
        }

        public async Task<IEnumerable<UsuarioTutor>> GetByTutorIdAsync(int idTutor)
        {
            return await _repository.GetByTutorIdAsync(idTutor);
        }

        public async Task AddAsync(UsuarioTutor usuarioTutor)
        {
            await _repository.AddAsync(usuarioTutor);
        }

        public async Task UpdateAsync(UsuarioTutor usuarioTutor)
        {
            await _repository.UpdateAsync(usuarioTutor);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
