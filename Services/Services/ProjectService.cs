using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<ActionResult> CreateAsync(AddProjectDto addProject, ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var newProject = new Project()
                {
                    ProjectName = addProject.ProjectName,
                    ProjectCode = addProject.ProjectCode,
                    StartDate = addProject.StartDate,
                    EndDate = addProject.EndDate,
                    ParentProjectId = addProject.ParentProjectId != 0 ? addProject.ParentProjectId : null,
                    ProjectNote = addProject.ProjectNote,
                };

                var project = await projectRepository.CreateAsync(newProject);
                return new OkObjectResult(project);
            }
            else
            {
                return new BadRequestObjectResult(modelState);
            }
        }

        public async Task<ActionResult> DeleteAsync(int? id)
        {
            var project = await projectRepository.DeleteAsync(id);

            if (project == null)
                return new NotFoundResult();

            return new NoContentResult();
        }

        public async Task<ActionResult> GetAllAsync()
        {
            var projects = await projectRepository.GetAllAsync();

            return new OkObjectResult(projects);
        }

        public async Task<ActionResult> GetByIdAsync(int? id)
        {
            var project = await projectRepository.GetByIdAsync(id);

            if (project == null)
                return new NotFoundResult();

            return new OkObjectResult(project);
        }

        public async Task<ActionResult> UpdateAsync(int? id, AddProjectDto updateProject, ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var newProject = new Project()
                {
                    ProjectName = updateProject.ProjectName,
                    ProjectCode = updateProject.ProjectCode,
                    StartDate = updateProject.StartDate,
                    EndDate = updateProject.EndDate,
                    ParentProjectId = updateProject.ParentProjectId != 0 ? updateProject.ParentProjectId  : null ,
                    ProjectNote = updateProject.ProjectNote,
                };

                var project = await projectRepository.UpdateAsync(id, newProject);

                if (project == null)
                    return new NotFoundResult();

                return new OkObjectResult(project);
            }
            else
            {
                return new BadRequestObjectResult(modelState);
            }
        }
    }
}
