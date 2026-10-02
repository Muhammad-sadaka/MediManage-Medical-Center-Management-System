using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class MedicineRecipeDTOValidator : AbstractValidator<clsMedicineRecipeDTO>
    {
        public MedicineRecipeDTOValidator()
        {
            RuleFor(x => x.MedicalPrescriptionID)
                .NotNull().WithMessage("Medical Prescription ID is required.")
                .GreaterThan(0).WithMessage("Medical Prescription ID must be greater than 0.");

            RuleFor(x => x.MedicineID)
                .NotNull().WithMessage("Medicine ID is required.")
                .GreaterThan(0).WithMessage("Medicine ID must be greater than 0.");

            RuleFor(x => x.Dose)
                .NotEmpty().WithMessage("Dose is required.")
                .MaximumLength(100).WithMessage("Dose cannot exceed 100 characters.");

            RuleFor(x => x.Repetition)
                .MaximumLength(100).WithMessage("Repetition cannot exceed 100 characters.");

            RuleFor(x => x.Duration)
                .MaximumLength(100).WithMessage("Duration cannot exceed 100 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
        }
    }
}