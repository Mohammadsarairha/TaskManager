using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repository.Interfaces;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository projectTaskRepository;

        public ProjectTaskService(IProjectTaskRepository projectTaskRepository)
        {
            this.projectTaskRepository = projectTaskRepository;
        }

        public async Task<ActionResult> GetAllAsync()
        {
            var projectTasks = await projectTaskRepository.GetAllAsync();
            return new OkObjectResult(projectTasks);
        }

        public async Task<ActionResult> GetByIdAsync(int? id)
        {
            var projectTask = await projectTaskRepository.GetByIdAsync(id);

            if (projectTask == null)
                return new NotFoundResult();

            return new OkObjectResult(projectTask);
        }

        public async Task<ActionResult> CreateAsync(AddProjectTaskDto addProjectTask, ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var newProjectTask = new ProjectTask()
                {
                    TaskCode = addProjectTask.TaskCode,
                    StartDate = addProjectTask.StartDate,
                    EndDate = addProjectTask.EndDate,
                    Note = addProjectTask.Note,
                    ProjectId = addProjectTask.ProjectId,
                    UserId = addProjectTask.UserId,
                    TaskTypeId = addProjectTask.TaskTypeId,
                };

                var createdProjectTask = await projectTaskRepository.CreateAsync(newProjectTask);
                return new OkObjectResult(newProjectTask);
            }
            else
            {
                return new BadRequestObjectResult(modelState);
            }
        }

        public async Task<ActionResult> DeleteAsync(int? id)
        {
            var deletedProjectTask = await projectTaskRepository.DeleteAsync(id);

            if (deletedProjectTask == null)
                return new NotFoundResult();

            return new NoContentResult();
        }

        public async Task<ActionResult> UpdateAsync(int? id, AddProjectTaskDto updateProjectTask, ModelStateDictionary modelState)
        {
            if (modelState.IsValid)
            {
                var updatedProjectTask = new ProjectTask()
                {
                    TaskCode = updateProjectTask.TaskCode,
                    StartDate = updateProjectTask.StartDate,
                    EndDate = updateProjectTask.EndDate,
                    Note = updateProjectTask.Note,
                    ProjectId = updateProjectTask.ProjectId,
                    UserId = updateProjectTask.UserId,
                    TaskTypeId = updateProjectTask.TaskTypeId,
                };

                var result = await projectTaskRepository.UpdateAsync(id, updatedProjectTask);

                if (result == null)
                    return new NotFoundResult();

                return new OkObjectResult(result);
            }
            else
            {
                return new BadRequestObjectResult(modelState);
            }
        }
    }
}
