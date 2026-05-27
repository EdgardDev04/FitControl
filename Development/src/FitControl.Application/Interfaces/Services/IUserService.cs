using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(UpdateUserDto dto);
        Task<bool> ChangePasswordAsync(int userId, string password);
    }
}
