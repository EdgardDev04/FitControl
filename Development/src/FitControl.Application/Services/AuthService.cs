using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FitControl.Domain.ValueObject;

namespace FitControl.Application.Services
{
    public class AuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var email = Email.Create(request.Email);

            var user = await _unitOfWork.Users.GetByEmailAsync(email.Value);

            if (user == null || !await _unitOfWork.Users.CheckPasswordAsync(user, request.Password))
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            var token = await _jwtTokenGenerator.GenerateToken(user.Id,user.Email);

            return new LoginResponseDto
            {
                Token = token
            };
        }
    }
}
