using Models;

namespace Repositories
{
    public interface ITutorRepository
    {
        Task<List<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task AddAsync(Tutor tutor);
        Task UpdateAsync(Tutor tutor);
        Task DeleteAsync(int id);
        Task<Tutor> GetByUsernameAndPasswordAsync(string username, string password);
    }
}
