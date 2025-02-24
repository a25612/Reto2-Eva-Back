using DTOs;
using Models;

namespace Service
{
    public interface IUsuariosService
    {
        Task<List<UsuarioDTO>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
