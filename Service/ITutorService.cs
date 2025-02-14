using Models;

namespace Pisicna_Back.Service
{
    public interface ITutorService
    {
        Task<List<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task AddAsync(Tutor tutor);
        Task UpdateAsync(Tutor tutor);
        Task DeleteAsync(int id);
        Task<Tutor> LoginAsync(string username, string password);
    }
}
