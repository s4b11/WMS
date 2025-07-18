﻿using FluentValidation;

namespace WMS.Dtos
{
    public class CurrencyEditDtoValidator : AbstractValidator<CurrencyEditDto>
    {
        public CurrencyEditDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 50).WithMessage("{PropertyName} must be between 1 and 50 characters");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .Length(1, 20).WithMessage("{PropertyName} must be between 1 and 20 characters");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be a valid Country");
        }
    }
}
