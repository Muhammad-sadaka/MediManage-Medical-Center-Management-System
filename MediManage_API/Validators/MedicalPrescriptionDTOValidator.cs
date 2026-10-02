using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class MedicalPrescriptionDTOValidator : AbstractValidator<clsMedicalPrescriptionDTO>
    {
        public MedicalPrescriptionDTOValidator()
        {
            RuleFor(x => x.DetectionID)
                .NotNull().WithMessage("Detection ID is required.")
                .GreaterThan(0).WithMessage("Detection ID must be greater than 0.");

            RuleFor(x => x.PrescriptionDate)
                .NotNull().WithMessage("Prescription date is required.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
        }
    }
}