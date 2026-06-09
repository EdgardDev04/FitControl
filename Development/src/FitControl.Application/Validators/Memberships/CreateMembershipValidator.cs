using FitControl.Application.DTOs;
using FluentValidation;

namespace FitControl.Application.Validators.Memberships
{
    internal class CreateMembershipValidator : AbstractValidator<CreateMembershipDto>
    {
        public CreateMembershipValidator() 
        {
            RuleFor(c => c.StartDate)
                .NotEmpty()
                .WithMessage("Start date is required.");

            RuleFor(c => c.EndDate)
                .NotEmpty()
                .WithMessage("End date is required.")
                .Must((promotion, endDate) => endDate > promotion.StartDate)
                .WithMessage("End date must be after the start date");

            RuleFor(c => c.Status)
                .IsInEnum()
                .WithMessage("Invalid status value.")
                .NotEmpty()
                .WithMessage("Status is required.");
        }
    }
}
