using FitControl.Application.DTOs;
using FluentValidation;

namespace FitControl.Application.Validators.Users
{
    internal class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
