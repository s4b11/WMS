using FluentValidation;

namespace WMS.Dtos
{
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 50).WithMessage("{PropertyName} must be between 1 and 50 characters");

            RuleFor(x => x.Addr1)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Pin)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 50).WithMessage("{PropertyName} must be between 1 and 50 characters");

            RuleFor(x => x.EmailID)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.ContactPerson)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.CPEmailID)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.CPMobile)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.URL)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters")
                .When(x => !string.IsNullOrEmpty(x.URL));

            RuleFor(x => x.ECCNO)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.TINNO)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.CSTNO)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.BaseCurr)
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(x => x.UserID)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.TransExistFlag)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Must(flag => flag == 'Y' || flag == 'N')
                .WithMessage("{PropertyName} must be either 'Y' or 'N'");
        }
    }
}
