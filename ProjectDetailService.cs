using TaskBoard.Entities;

namespace TaskBoard.Services
{
    public interface IProjectDetailsService
    {
        Task<IEnumerable<ProjectDetails>> GetAllAsync();

        Task<ProjectDetails?> GetByIdAsync(
            string projectId,
            string projectName);

        Task<ProjectDetails> CreateAsync(
            ProjectDetails project);

        Task<bool> UpdateAsync(
            string projectId,
            string projectName,
            ProjectDetails project);

        Task<bool> DeleteAsync(
            string projectId,
            string projectName);
    }
}