using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class MedicineDTOValidator : AbstractValidator<clsMedicineDTO>
    {
        public MedicineDTOValidator()
        {
            RuleFor(x => x.MedicineName)
                .NotEmpty().WithMessage("Medicine name is required.")
                .MaximumLength(100).WithMessage("Medicine name cannot exceed 100 characters.");
        }
    }
}