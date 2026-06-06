using Microsoft.EntityFrameworkCore;
using TaskBoard.Data;
using TaskBoard.Entities;

namespace TaskBoard.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly ApplicationDbContext _context;

        public UserDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetails?> GetByIdAsync(
            string userId,
            string userName)
        {
            return await _context.UserDetails
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.UserName == userName);
        }

        public async Task<UserDetails> CreateAsync(
            UserDetails user)
        {
            _context.UserDetails.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdateAsync(
            string userId,
            string userName,
            UserDetails user)
        {
            var existingUser = await _context.UserDetails
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.UserName == userName);

            if (existingUser == null)
                return false;

            existingUser.ProjectId = user.ProjectId;
            existingUser.ReportingTo = user.ReportingTo;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(
            string userId,
            string userName)
        {
            var existingUser = await _context.UserDetails
                .FirstOrDefaultAsync(x =>
                    x.UserId == userId &&
                    x.UserName == userName);

            if (existingUser == null)
                return false;

            _context.UserDetails.Remove(existingUser);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}