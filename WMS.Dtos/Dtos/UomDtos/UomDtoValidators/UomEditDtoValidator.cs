using FluentValidation;

namespace WMS.Dtos
{
    public class UomEditDtoValidator : AbstractValidator<UomEditDto>
    {
        public UomEditDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 100).WithMessage("{PropertyName} must be between 1 and 100 characters");

            RuleFor(x => x.Short)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 20).WithMessage("{PropertyName} must be between 1 and 20 characters");
        }
    }
}