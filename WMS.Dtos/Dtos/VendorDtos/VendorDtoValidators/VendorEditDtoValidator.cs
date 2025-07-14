using FluentValidation;

namespace WMS.Dtos
{
    public class VendorEditDtoValidator : AbstractValidator<VendorEditDto>
    {
        public VendorEditDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .MaximumLength(100).WithMessage("{PropertyName} must be at most 100 characters");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters");

            RuleFor(x => x.FDType)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Must(c => c == 'F' || c == 'D')
                .WithMessage("{PropertyName} must be either 'F' (Foreign) or 'D' (Domestic)");

            RuleFor(x => x.Addr1)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .MaximumLength(100).WithMessage("{PropertyName} must be at most 100 characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a valid Country");

            RuleFor(x => x.StateId)
                .GreaterThan(0).WithMessage("{PropertyName} must be a valid State");

            RuleFor(x => x.Pin)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .MaximumLength(50).WithMessage("{PropertyName} must be at most 50 characters");

            RuleFor(x => x.EmailID)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.ContactPerson)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.CPEmailID)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email");

            RuleFor(x => x.CPMobile)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.BaseCurr)
                .GreaterThan(0).WithMessage("{PropertyName} must be a valid currency");

            RuleFor(x => x.UserID)
                .GreaterThan(0).WithMessage("{PropertyName} is empty");

            RuleFor(x => x.Url)
                .MaximumLength(100).WithMessage("{PropertyName} must be at most 100 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.Url));

            RuleFor(x => x.ECCNo)
                .MaximumLength(100).WithMessage("{PropertyName} must be at most 100 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.ECCNo));

            RuleFor(x => x.TINNo)
                .MaximumLength(100).WithMessage("{PropertyName} must be at most 100 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.TINNo));

            RuleFor(x => x.CSTNo)
                .MaximumLength(100).WithMessage("{PropertyName} must be at most 100 characters")
                .When(x => !string.IsNullOrWhiteSpace(x.CSTNo));
        }
    }
}
