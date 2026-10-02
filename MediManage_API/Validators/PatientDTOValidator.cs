using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class PatientDTOValidator : AbstractValidator<clsPatientDTO>
    {
        public PatientDTOValidator()
        {
            RuleFor(x => x.PersonID)
                .NotNull().WithMessage("Person ID is required.")
                .GreaterThan(0).WithMessage("Person ID must be greater than 0.");

            RuleFor(x => x.PatientCaseID)
                .NotNull().WithMessage("Patient Case ID is required.")
                .GreaterThan(0).WithMessage("Patient Case ID must be greater than 0.");

            RuleFor(x => x.JoinDate)
                .NotNull().WithMessage("Join date is required.");

            RuleFor(x => x.Sensitivity)
                .MaximumLength(500).WithMessage("Sensitivity details cannot exceed 500 characters.");

            RuleFor(x => x.ChronicDiseases)
                .MaximumLength(500).WithMessage("Chronic diseases details cannot exceed 500 characters.");
        }
    }
}