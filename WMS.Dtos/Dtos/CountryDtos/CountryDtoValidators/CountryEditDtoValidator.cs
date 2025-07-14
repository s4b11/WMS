using FluentValidation;
using WMS.Dtos;

namespace WMS.Dtos.Validators
{
    public class CountryEditDtoValidator : AbstractValidator<CountryEditDto>
    {
        public CountryEditDtoValidator()
        {
            RuleFor(x => x.CountryName)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.CountryCode)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(1, 20).WithMessage("{PropertyName} must be between 1 and 20 characters");

        }
    }
}