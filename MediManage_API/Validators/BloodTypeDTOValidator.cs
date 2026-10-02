using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class BloodTypeDTOValidator : AbstractValidator<clsBloodTypeDTO>
    {
        public BloodTypeDTOValidator()
        {
            RuleFor(x => x.BloodTypeSymbol)
                .NotEmpty().WithMessage("Blood type symbol is required.")
                .MaximumLength(10).WithMessage("Blood type symbol cannot exceed 10 characters.");
        }
    }
}