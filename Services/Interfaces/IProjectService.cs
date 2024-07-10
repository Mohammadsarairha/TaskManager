using Domain.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Services.Interfaces
{
    public interface IProjectService
    {
        Task<ActionResult> CreateAsync(AddProjectDto addProject, ModelStateDictionary modelState);
        Task<ActionResult> DeleteAsync(int? id);
        Task<ActionResult> GetAllAsync();
        Task<ActionResult> GetByIdAsync(int? id);
        Task<ActionResult> UpdateAsync(int? id, AddProjectDto updateProject, ModelStateDictionary modelState);
    }
}
