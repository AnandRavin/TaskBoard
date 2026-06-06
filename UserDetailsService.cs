using TaskBoard.Entities;

namespace TaskBoard.Services
{
    public interface IUserDetailsService
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();

        Task<UserDetails?> GetByIdAsync(
            string userId,
            string userName);

        Task<UserDetails> CreateAsync(
            UserDetails user);

        Task<bool> UpdateAsync(
            string userId,
            string userName,
            UserDetails user);

        Task<bool> DeleteAsync(
            string userId,
            string userName);
    }
}