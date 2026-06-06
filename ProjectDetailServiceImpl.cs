using Microsoft.EntityFrameworkCore;
using TaskBoard.Data;
using TaskBoard.Entities;

namespace TaskBoard.Services
{
    public class ProjectDetailsService : IProjectDetailsService
    {
        private readonly ApplicationDbContext _context;

        public ProjectDetailsService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDetails>> GetAllAsync()
        {
            return await _context.ProjectDetails
                .OrderBy(x => x.ProjectName)
                .ToListAsync();
        }

        public async Task<ProjectDetails?> GetByIdAsync(
            string projectId,
            string projectName)
        {
            return await _context.ProjectDetails
                .FirstOrDefaultAsync(x =>
                    x.ProjectId == projectId &&
                    x.ProjectName == projectName);
        }

        public async Task<ProjectDetails> CreateAsync(
            ProjectDetails project)
        {
            _context.ProjectDetails.Add(project);

            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<bool> UpdateAsync(
            string projectId,
            string projectName,
            ProjectDetails project)
        {
            var existingProject =
                await _context.ProjectDetails
                .FirstOrDefaultAsync(x =>
                    x.ProjectId == projectId &&
                    x.ProjectName == projectName);

            if (existingProject == null)
                return false;

            existingProject.ProjectStartDate =
                project.ProjectStartDate;

            existingProject.ProjectEndDate =
                project.ProjectEndDate;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(
            string projectId,
            string projectName)
        {
            var existingProject =
                await _context.ProjectDetails
                .FirstOrDefaultAsync(x =>
                    x.ProjectId == projectId &&
                    x.ProjectName == projectName);

            if (existingProject == null)
                return false;

            _context.ProjectDetails.Remove(existingProject);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}