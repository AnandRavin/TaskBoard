using TaskBoard.Entities;

namespace TaskBoard.Services
{
    public interface ITaskDetailsService
    {
        Task<IEnumerable<TaskDetails>> GetAllAsync();
        Task<TaskDetails?> GetByIdAsync(string taskId, string taskName);
        Task<TaskDetails> CreateAsync(TaskDetails task);
        Task<bool> UpdateAsync(string taskId, string taskName, TaskDetails task);
        Task<bool> DeleteAsync(string taskId, string taskName);
    }
}