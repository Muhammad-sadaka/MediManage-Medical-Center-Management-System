using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class DoctorDTOValidator : AbstractValidator<clsDoctorDTO>
    {
        public DoctorDTOValidator()
        {
            RuleFor(x => x.PersonID)
                .NotNull().WithMessage("Person ID is required.")
                .GreaterThan(0).WithMessage("Person ID must be greater than 0.");

            RuleFor(x => x.SpecialtyID)
                .NotNull().WithMessage("Specialty ID is required.")
                .GreaterThan(0).WithMessage("Specialty ID must be greater than 0.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");

            RuleFor(x => x.LicenseNo)
                .NotEmpty().WithMessage("License number is required.")
                .MaximumLength(50).WithMessage("License number cannot exceed 50 characters.");

            RuleFor(x => x.Qualification)
                .MaximumLength(250).WithMessage("Qualification cannot exceed 250 characters.");

            RuleFor(x => x.YearsOfExperience)
                .Must(exp => !exp.HasValue || exp.Value >= 0)
                .WithMessage("Years of experience cannot be negative.");
        }
    }
}