using Microsoft.AspNetCore.Mvc;
using YourProject.Entities;
using YourProject.Services;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _service;

        public UserDetailsController(
            IUserDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{userId}/{userName}")]
        public async Task<IActionResult> GetById(
            string userId,
            string userName)
        {
            var user = await _service.GetByIdAsync(
                userId,
                userName);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] UserDetails user)
        {
            var createdUser =
                await _service.CreateAsync(user);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    userId = createdUser.UserId,
                    userName = createdUser.UserName
                },
                createdUser);
        }

        [HttpPut("{userId}/{userName}")]
        public async Task<IActionResult> Update(
            string userId,
            string userName,
            [FromBody] UserDetails user)
        {
            var updated =
                await _service.UpdateAsync(
                    userId,
                    userName,
                    user);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{userId}/{userName}")]
        public async Task<IActionResult> Delete(
            string userId,
            string userName)
        {
            var deleted =
                await _service.DeleteAsync(
                    userId,
                    userName);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}