using FitControl.Application.DTOs;
using FluentValidation;

namespace FitControl.Application.Validators.MembershipPlans
{
    internal class CreateMembershipPlanValidator : AbstractValidator<CreateMembershipPlanDto>
    {
        public CreateMembershipPlanValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(100)
                .WithMessage("Name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(250)
                .WithMessage("Description must not exceed 250 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a positive value.");

            RuleFor(x => x.DurationInDays)
                .GreaterThan(0)
                .WithMessage("Duration in days must be a positive value.");
        }
    }
}
