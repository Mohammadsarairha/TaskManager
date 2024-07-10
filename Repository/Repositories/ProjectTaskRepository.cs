using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Migrations.DataContext;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly TaskManagerDbContext dbContext;
        public ProjectTaskRepository(TaskManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<ProjectTask>> GetAllAsync()
        {
            return await dbContext.ProjectTasks.Include("Project").Include(x => x.User).Include("TaskType").ToListAsync();
        }
        public async Task<ProjectTask?> GetByIdAsync(int? Id)
        {
            return await dbContext.ProjectTasks.Include("Project").Include(x => x.User).Include("TaskType").FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<ProjectTask?> CreateAsync(ProjectTask projectTask)
        {
            await dbContext.ProjectTasks.AddAsync(projectTask);
            await dbContext.SaveChangesAsync();

            return projectTask;
        }
        public async Task<ProjectTask?> DeleteAsync(int? Id)
        {
            var ProjectTask = await dbContext.ProjectTasks.FirstOrDefaultAsync(x => x.Id == Id);
            if (ProjectTask == null)
                return null;

            dbContext.ProjectTasks.Remove(ProjectTask);
            await dbContext.SaveChangesAsync();

            return ProjectTask;
        }
        public async Task<ProjectTask?> UpdateAsync(int? Id, ProjectTask projectTask)
        {
            var ProjectTask = await dbContext.ProjectTasks.FirstOrDefaultAsync(x => x.Id == Id);

            if (ProjectTask == null)
                return null;

            ProjectTask.TaskCode = projectTask.TaskCode;
            ProjectTask.Note = projectTask.Note;
            ProjectTask.StartDate = projectTask.StartDate;
            ProjectTask.EndDate = projectTask.EndDate;
            ProjectTask.UserId = projectTask.UserId;
            ProjectTask.TaskTypeId = projectTask.TaskTypeId;

            await dbContext.SaveChangesAsync();

            return ProjectTask;
        }
    }
}
