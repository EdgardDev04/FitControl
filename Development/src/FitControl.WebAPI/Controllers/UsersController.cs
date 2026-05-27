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

        [HttpPost("{id:int}")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            await _userService.CreateUserAsync(dto);

            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto dto)
        {
            await _userService.UpdateUserAsync(dto);

            return NoContent();
        }

        [HttpPatch("{id:int}")  ]
        public async Task<IActionResult> ChangePassword([FromRoute] int id, [FromBody] string password)
        {
            await _userService.ChangePasswordAsync(id, password);

            return NoContent();
        }
    }
}