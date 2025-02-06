using Models;

namespace Pisicna_Back.Repositories
{
    public interface ITutorRepository
    {
        Task<List<Tutor>> GetAllAsync();
        Task<Tutor?> GetByIdAsync(int id);
        Task AddAsync(Tutor tutor);
        Task UpdateAsync(Tutor tutor);
        Task DeleteAsync(int id);
    }
}
