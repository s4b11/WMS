using FluentValidation;

namespace WMS.Dtos
{
    public class CompanyCreateDtoValidator : AbstractValidator<CompanyCreateDto>
    {
        public CompanyCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.Addr1)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.Addr2)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.StateId)
                .GreaterThan(0).WithMessage("{PropertyName} is required");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("{PropertyName} is required");

            RuleFor(x => x.Pin)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.ContactPerson)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.CPMobile)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.EmailID)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Invalid {PropertyName} format")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.CPEmailID)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("Invalid {PropertyName} format")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.URL)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.ECCNO)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.TINNO)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x.CSTNO)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters");

            RuleFor(x => x._3PLFlag)
                .MaximumLength(1).WithMessage("{PropertyName} must be a single character");

            RuleFor(x => x.TransExistFlag)
                .MaximumLength(1).WithMessage("{PropertyName} must be a single character");

            RuleFor(x => x.ImagePath)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

            RuleFor(x => x.ImageName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters");

            RuleFor(x => x.Image)
                .NotNull().WithMessage("{PropertyName} is required")
                .Must(img => img.Length > 0).WithMessage("{PropertyName} cannot be empty");

            RuleFor(x => x.BaseCurr)
                .GreaterThan(0).WithMessage("{PropertyName} is required");

            RuleFor(x => x.UserID)
                .GreaterThan(0).WithMessage("{PropertyName} is required");
        }
    }
}
