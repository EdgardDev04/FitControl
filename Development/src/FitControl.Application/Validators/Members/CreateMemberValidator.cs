using FitControl.Application.DTOs;
using FitControl.Application.Interfaces;
using FluentValidation;

namespace FitControl.Application.Validators.Members
{
    internal class CreateMemberValidator : AbstractValidator<CreateMemberDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateMemberValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");

            RuleFor(c => c.DocumentNumber)
                .NotEmpty()
                .WithMessage("Document number is required.");

            RuleFor(c => c.DocumentType)
                .IsInEnum()
                .WithMessage("Invalid document type value.")
                .NotEmpty()
                .WithMessage("Document type is required.");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(c => c.PhoneNumber)
                .MaximumLength(20)
                .WithMessage("Phone number cannot exceed 20 characters.")
                .NotEmpty()
                .WithMessage("Phone number is required.");

            RuleFor(c => c.BirthDate)
                .GreaterThan(DateTime.Now.AddYears(-120))
                .WithMessage("Birth date must be a valid date in the past and not more than 120 years ago.")
                .LessThan(DateTime.Now)
                .WithMessage("Birth date cannot be in the future.")
                .Must(date => date.HasValue && date.Value <= DateTime.Now.AddYears(-18))
                .WithMessage("Member must be at least 18 years old.");

            RuleFor(c => c.Gender)
                .IsInEnum()
                .WithMessage("Invalid gender value.");
        }
    }
}
