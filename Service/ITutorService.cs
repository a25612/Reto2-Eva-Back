using Models;

namespace Service
{
    public interface ITutorService
    {
        Task<Tutor?> LoginAsync(string username, string password);
        Task<List<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task<List<Usuario>> GetUsuariosByTutorIdAsync(int tutorId);
        Task AddAsync(Tutor tutor);
        Task UpdateAsync(Tutor tutor);
        Task DeleteAsync(int id);
    }
}