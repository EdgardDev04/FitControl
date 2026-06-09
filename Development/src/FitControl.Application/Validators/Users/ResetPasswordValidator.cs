using FitControl.Application.DTOs;
using FluentValidation;

namespace FitControl.Application.Validators.Users
{
    internal class ResetPasswordValidator : AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordValidator() 
        {
            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
        }
    }
}
