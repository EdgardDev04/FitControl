using FitControl.Application.Common;
using FitControl.Application.DTOs;
using FitControl.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitControl.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationParams paginationParams)
        {
            var result = await _userService.GetPagedUsersAsync(paginationParams);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUsers([FromRoute] int userId)
        {
            var users = await _userService.GetUserAsync(userId);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            await _userService.CreateUserAsync(dto);

            return Created();
        }

        [HttpPut("{userId:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserDto dto)
        {
            await _userService.UpdateUserAsync(userId, dto);

            return NoContent();
        }

        [HttpPatch("{userId:int}")  ]
        public async Task<IActionResult> ChangePassword([FromRoute] int userId, [FromBody] string password)
        {
            await _userService.ChangePasswordAsync(userId, password);

            return NoContent();
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            await _userService.DeleteUserAsync(userId);

            return NoContent();
        }
    }
}