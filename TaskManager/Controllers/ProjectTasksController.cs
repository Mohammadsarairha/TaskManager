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
    public class ProjectTasksController : ControllerBase
    {
        private readonly IProjectTaskService projectTaskService;

        public ProjectTasksController(IProjectTaskService projectTaskService)
        {
            this.projectTaskService = projectTaskService;
        }

        [HttpGet]
        public Task<ActionResult> GetAll()
        {
            return projectTaskService.GetAllAsync();
        }

        [HttpGet]
        [Route("{id")]
        public Task<ActionResult> GetById([FromRoute] int id)
        {
            return projectTaskService.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<ActionResult> Create([FromBody] AddProjectTaskDto addProjectTask)
        {
            return projectTaskService.CreateAsync(addProjectTask , ModelState);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ActionResult> Update([FromRoute] int id, [FromBody] AddProjectTaskDto UpdateprojectTask)
        {
            return projectTaskService.UpdateAsync(id, UpdateprojectTask , ModelState);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<ActionResult> Delete([FromRoute] int id)
        {
            return projectTaskService.DeleteAsync(id);
        }

    }
}
