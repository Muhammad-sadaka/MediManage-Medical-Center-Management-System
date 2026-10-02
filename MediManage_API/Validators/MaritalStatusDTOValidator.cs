using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class MaritalStatusDTOValidator : AbstractValidator<clsMaritalStatusDTO>
    {
        public MaritalStatusDTOValidator()
        {
            RuleFor(x => x.MaritalStatusName)
                .NotEmpty().WithMessage("Marital status name is required.")
                .MaximumLength(50).WithMessage("Marital status name cannot exceed 50 characters.");
        }
    }
}