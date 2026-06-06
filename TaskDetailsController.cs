using Microsoft.AspNetCore.Mvc;
using TaskBoard.Entities;
using TaskBoard.Services;

namespace TaskBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskDetailsService _service;

        public TaskDetailsController(ITaskDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{taskId}/{taskName}")]
        public async Task<IActionResult> GetById(
            string taskId,
            string taskName)
        {
            var task = await _service.GetByIdAsync(taskId, taskName);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] TaskDetails task)
        {
            var createdTask = await _service.CreateAsync(task);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    taskId = createdTask.TaskId,
                    taskName = createdTask.TaskName
                },
                createdTask);
        }

        [HttpPut("{taskId}/{taskName}")]
        public async Task<IActionResult> Update(
            string taskId,
            string taskName,
            [FromBody] TaskDetails task)
        {
            var updated = await _service.UpdateAsync(taskId,taskName,task);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{taskId}/{taskName}")]
        public async Task<IActionResult> Delete(
            string taskId,
            string taskName)
        {
            var deleted = await _service.DeleteAsync(taskId,taskName);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}