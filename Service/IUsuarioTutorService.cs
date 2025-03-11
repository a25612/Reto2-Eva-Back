using Models;

namespace Service
{
    public interface IUsuarioTutorService
    {
        Task<IEnumerable<UsuarioTutor>> GetAllAsync();
        Task<UsuarioTutor> GetByIdAsync(int id);
        Task<IEnumerable<UsuarioTutor>> GetByUsuarioIdAsync(int idUsuario);
        Task<IEnumerable<UsuarioTutor>> GetByTutorIdAsync(int idTutor);
        Task AddAsync(UsuarioTutor usuarioTutor);
        Task UpdateAsync(UsuarioTutor usuarioTutor);
        Task DeleteAsync(int id);
    }
}
