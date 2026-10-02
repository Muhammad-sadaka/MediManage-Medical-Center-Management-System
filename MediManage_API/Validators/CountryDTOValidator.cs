using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class CountryDTOValidator : AbstractValidator<clsCountryDTO>
    {
        public CountryDTOValidator()
        {
            RuleFor(x => x.CountryName)
                .NotEmpty().WithMessage("Country name is required.")
                .MaximumLength(100).WithMessage("Country name cannot exceed 100 characters.");
        }
    }
}