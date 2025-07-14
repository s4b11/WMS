using FluentValidation;
using WMS.Dtos;

namespace WMS.Dtos.Validators
{
    public class UomCreateDtoValidator : AbstractValidator<UomCreateDto>
    {
        public UomCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 50).WithMessage("{PropertyName} must be between 1 and 50 characters");

            RuleFor(x => x.Short)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 20).WithMessage("{PropertyName} must be between 1 and 20 characters");
        }
    }
}