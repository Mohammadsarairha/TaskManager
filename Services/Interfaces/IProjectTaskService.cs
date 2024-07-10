using Domain.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
    public interface IProjectTaskService
    {
        Task<ActionResult> GetAllAsync();
        Task<ActionResult> GetByIdAsync(int? id);
        Task<ActionResult> CreateAsync(AddProjectTaskDto addProjectTask, ModelStateDictionary modelState);
        Task<ActionResult> DeleteAsync(int? id);
        Task<ActionResult> UpdateAsync(int? id, AddProjectTaskDto updateProjectTask, ModelStateDictionary modelState);
    }
}
