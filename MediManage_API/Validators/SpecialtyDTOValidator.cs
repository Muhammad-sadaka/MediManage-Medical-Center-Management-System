using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class SpecialtyDTOValidator : AbstractValidator<clsSpecialtyDTO>
    {
        public SpecialtyDTOValidator()
        {
            RuleFor(x => x.SpecialtyName)
                .NotEmpty().WithMessage("Specialty name is required.")
                .MaximumLength(100).WithMessage("Specialty name cannot exceed 100 characters.");

            RuleFor(x => x.Fees)
                .NotNull().WithMessage("Fees are required.")
                .GreaterThanOrEqualTo(0).WithMessage("Fees must be greater than or equal to 0.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}