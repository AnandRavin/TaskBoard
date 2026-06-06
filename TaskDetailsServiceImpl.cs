using Microsoft.EntityFrameworkCore;
using TaskBoard.Data;
using TaskBoard.Entities;

namespace TaskBoard.Services
{
    public class TaskDetailsService : ITaskDetailsService
    {
        private readonly ApplicationDbContext _context;

        public TaskDetailsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDetails>> GetAllAsync()
        {
            return await _context.TaskDetails
                .Where(x => x.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<TaskDetails?> GetByIdAsync(string taskId, string taskName)
        {
            return await _context.TaskDetails
                .FirstOrDefaultAsync(x =>
                    x.TaskId == taskId &&
                    x.TaskName == taskName &&
                    x.IsDeleted != true);
        }

        public async Task<TaskDetails> CreateAsync(TaskDetails task)
        {
            task.CreatedTime = DateTime.UtcNow;
            task.IsDeleted = false;

            _context.TaskDetails.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateAsync(
            string taskId,
            string taskName,
            TaskDetails task)
        {
            var existing = await _context.TaskDetails
                .FirstOrDefaultAsync(x =>
                    x.TaskId == taskId &&
                    x.TaskName == taskName);

            if (existing == null)
                return false;

            existing.UserName = task.UserName;
            existing.TaskDescription = task.TaskDescription;
            existing.IsActive = task.IsActive;
            existing.TaskStatus = task.TaskStatus;
            existing.UpdatedBy = task.UpdatedBy;
            existing.UpdatedTime = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(string taskId, string taskName)
        {
            var existing = await _context.TaskDetails
                .FirstOrDefaultAsync(x =>
                    x.TaskId == taskId &&
                    x.TaskName == taskName);

            if (existing == null)
                return false;

            // Soft Delete
            existing.IsDeleted = true;
            existing.DelDtimes = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}