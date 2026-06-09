using FitControl.Application.DTOs;

namespace FitControl.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(CreateUserDto dto);
        Task UpdateUserAsync(int userId, UpdateUserDto dto);
        Task DeleteUserAsync(int userId);
        Task<bool> ChangePasswordAsync(int userId, string password); 
        Task<LoginDto> LoginAsync(LoginDto dto);
        Task ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
        Task<UserDto> GetUserAsync(int id);
        Task<ICollection<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByEmailAsync(string email);
    }
}
