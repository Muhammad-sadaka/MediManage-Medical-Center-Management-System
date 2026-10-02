using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class PatientCaseDTOValidator : AbstractValidator<clsPatientCaseDTO>
    {
        public PatientCaseDTOValidator()
        {
            RuleFor(x => x.PatientCaseName)
                .NotEmpty().WithMessage("Patient case name is required.")
                .MaximumLength(100).WithMessage("Patient case name cannot exceed 100 characters.");
        }
    }
}