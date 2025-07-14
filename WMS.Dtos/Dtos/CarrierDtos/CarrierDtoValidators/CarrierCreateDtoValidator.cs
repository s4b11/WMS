using FluentValidation;
using WMS.Dtos;

namespace WMS.Dtos.Validators
{
    public class CarrierCreateDtoValidator : AbstractValidator<CarrierCreateDto>
    {
        public CarrierCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 10).WithMessage("{PropertyName} must be between 1 and 10 characters");

            RuleFor(x => x.Addr1)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.Addr2)
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 50).WithMessage("{PropertyName} must be between 1 and 50 characters");

            RuleFor(x => x.Pin)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 20).WithMessage("{PropertyName} must be between 1 and 20 characters");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country is required");

            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("State is required");

            RuleFor(x => x.CpName)
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters")
                .EmailAddress().WithMessage("Invalid email format")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");

            RuleFor(x => x.Mobile)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters");

            RuleFor(x => x.LstRegnno)
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters");

            RuleFor(x => x.CstRegnno)
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters");

            RuleFor(x => x.StRegnno)
                .MaximumLength(50).WithMessage("{PropertyName} cannot exceed 50 characters");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer is required");
        }
    }
}
