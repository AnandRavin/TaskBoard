using Microsoft.AspNetCore.Mvc;
using TaskBoard.Entities;
using TaskBoard.Services;

namespace TaskBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectDetailsController : ControllerBase
    {
        private readonly IProjectDetailsService _service;

        public ProjectDetailsController(
            IProjectDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects =
                await _service.GetAllAsync();

            return Ok(projects);
        }

        [HttpGet("{projectId}/{projectName}")]
        public async Task<IActionResult> GetById(
            string projectId,
            string projectName)
        {
            var project =
                await _service.GetByIdAsync(
                    projectId,
                    projectName);

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] ProjectDetails project)
        {
            var createdProject =
                await _service.CreateAsync(project);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    projectId = createdProject.ProjectId,
                    projectName = createdProject.ProjectName
                },
                createdProject);
        }

        [HttpPut("{projectId}/{projectName}")]
        public async Task<IActionResult> Update(
            string projectId,
            string projectName,
            [FromBody] ProjectDetails project)
        {
            var updated =
                await _service.UpdateAsync(
                    projectId,
                    projectName,
                    project);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{projectId}/{projectName}")]
        public async Task<IActionResult> Delete(
            string projectId,
            string projectName)
        {
            var deleted =
                await _service.DeleteAsync(
                    projectId,
                    projectName);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}