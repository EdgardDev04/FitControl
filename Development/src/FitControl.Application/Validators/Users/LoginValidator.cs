using FitControl.Application.DTOs;
using FluentValidation;

namespace FitControl.Application.Validators.Users
{
    internal class LoginValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .NotEmpty()
                .WithMessage("Email is required.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.");
        }
    }
}
