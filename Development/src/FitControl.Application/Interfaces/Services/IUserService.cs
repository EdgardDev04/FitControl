using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(UpdateUserDto dto);
        Task<bool> ChangePasswordAsync(int userId, string password);
    }
}
