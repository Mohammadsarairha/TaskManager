using Domain.Dto;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Services.Interfaces;
using Services.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public Task<ActionResult> GetAll()
        {
            return projectService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ActionResult> GetById([FromRoute] int id)
        {
            return projectService.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<ActionResult> Create([FromBody] AddProjectDto addProject)
        {
            return projectService.CreateAsync(addProject, ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ActionResult> Update([FromRoute] int id, [FromBody] AddProjectDto Updateproject)
        {
            return projectService.UpdateAsync(id , Updateproject , ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<ActionResult> Delete([FromRoute] int id)
        {
            return projectService.DeleteAsync(id);
        }

    }
}
