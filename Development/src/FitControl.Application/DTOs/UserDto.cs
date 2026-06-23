using FitControl.Domain.ValueObject;

namespace FitControl.Application.DTOs
{
    public record UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    public record CreateUserDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    public record UpdateUserDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }

    public record ResetPasswordDto
    { 
        public string PasswordHash { get; set; }
    }

    public record LoginRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public record LoginResponseDto
    {
        public string Token { get; set; }
    }
}
