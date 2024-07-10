using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Migrations.DataContext
{
    public class TaskManagerDbContext : IdentityDbContext
    {
        public TaskManagerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var taskTypes = new List<TaskType>()
            {
                new TaskType()
                {
                    Id = 1,
                    Name = "Development"
                },
                new TaskType()
                {
                    Id = 2,
                    Name = "Testing"
                },
                new TaskType()
                {
                    Id = 3,
                    Name = "Analysis"
                }
            };
            modelBuilder.Entity<TaskType>().HasData(taskTypes);
        }
    }
}
