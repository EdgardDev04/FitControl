using FitControl.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoleAsync();

            return Ok(roles);
        }
    
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleAsync(id);

            return Ok(role);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetRoleByName(string name)
        {
            var role = await _roleService.GetByNameAsync(name);

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            await _roleService.CreateAsync(roleName);

            //return CreatedAtAction(nameof(GetRoleById), new { id = RoleDto.Id }, role);

            return Created();
        }

        [HttpPost("users/{userId:int}")]
        public async Task<IActionResult> RemoveRoleFromUser([FromRoute] int userId, [FromBody] int roleId)
        {
            await _roleService.RemoveRoleFromUserAsync(userId, roleId);

            return NoContent();
        }

        [HttpPost("users/{userId:int}/assign")]
        public async Task<IActionResult> AssignRoleToUser([FromRoute] int userId, [FromBody] int roleId)
        {
            await _roleService.AssignRoleToUserAsync(userId, roleId);

            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, [FromBody] string roleName)
        {
            await _roleService.UpdateRoleAsync(id, roleName);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            await _roleService.DeleteRoleAsync(id);

            return NoContent();
        }
    }
}
