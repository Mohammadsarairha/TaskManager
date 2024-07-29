using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Migrations.DataContext;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskManagerDbContext dbContext;
        public ProjectRepository(TaskManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Projects.Include(x => x.ParentProject).Include(x => x.ChildProjects).ToListAsync();
        }
        public async Task<Project?> GetByIdAsync(int? Id)
        {
            return await dbContext.Projects.Include(x => x.ParentProject).Include(x => x.ChildProjects).FirstOrDefaultAsync(x => x.ID == Id);
        }
        public async Task<Project?> CreateAsync(Project project)
        {
            var newProject = await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
            project.ID = newProject.Entity.ID;
            return project;
        }
        public async Task<Project?> DeleteAsync(int? Id)
        {
            var Project = await dbContext.Projects.Include(x => x.ChildProjects).FirstOrDefaultAsync(x => x.ID == Id);
            if (Project == null)
                return null;

            dbContext.Projects.RemoveRange(Project);
            dbContext.Projects.Remove(Project);
            await dbContext.SaveChangesAsync();
            return Project;
        }
        public async Task<Project?> UpdateAsync(int? Id, Project project)
        {
            var Project = await dbContext.Projects.FirstOrDefaultAsync(x => x.ID == Id);

            if (Project == null)
                return null;

            Project.ProjectCode = project.ProjectCode;
            Project.ProjectName = project.ProjectName;
            Project.StartDate = project.StartDate;
            Project.EndDate = project.EndDate;
            Project.ParentProjectId = project.ParentProjectId;
            Project.ProjectNote = project.ProjectNote;

            await dbContext.SaveChangesAsync();

            return Project;
        }

    }
}
