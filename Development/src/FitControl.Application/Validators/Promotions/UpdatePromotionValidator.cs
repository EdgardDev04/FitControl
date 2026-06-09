using FitControl.Application.DTOs;
using FluentValidation;

namespace FitControl.Application.Validators.Promotions
{
    internal class UpdatePromotionValidator : AbstractValidator<UpdatePromotionDto>
    {
        public UpdatePromotionValidator() 
        {
            RuleFor(p => p.Name)
               .NotEmpty()
               .WithMessage("Name is required");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Description is required");

            RuleFor(p => p.DiscountPercentage)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount percentage cannot be negative");

            RuleFor(p => p.DiscountAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount amount cannot be negative");

            RuleFor(p => p.FixedPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Fixed price cannot be negative");

            RuleFor(p => p.DurationInDays)
                 .GreaterThan(0)
                 .WithMessage("Duration must be at least 1 day");

            RuleFor(p => p.StartDate)
                .NotEmpty()
                .WithMessage("Start date is required")
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("Start date cannot be in the past");

            RuleFor(p => p.EndDate)
                .NotEmpty()
                .WithMessage("End date is required")
                .Must((promotion, endDate) => endDate > promotion.StartDate)
                .WithMessage("End date must be after the start date");

            RuleFor(p => p.Status)
                .IsInEnum()
                .WithMessage("Invalid status");
        }
    }
}
