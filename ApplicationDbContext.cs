using Microsoft.EntityFrameworkCore;
using YourProject.Entities;

namespace YourProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskDetails> TaskDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDetails>()
                .HasKey(x => new { x.TaskId, x.TaskName });

            base.OnModelCreating(modelBuilder);
        }
    }
}