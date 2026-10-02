using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class DetectionDTOValidator : AbstractValidator<clsDetectionDTO>
    {
        public DetectionDTOValidator()
        {
            RuleFor(x => x.AppointmentID)
                .NotNull().WithMessage("Appointment ID is required.")
                .GreaterThan(0).WithMessage("Appointment ID must be greater than 0.");

            RuleFor(x => x.CreatedByUserID)
                .NotNull().WithMessage("Created By User ID is required.")
                .GreaterThan(0).WithMessage("Created By User ID must be greater than 0.");

            RuleFor(x => x.Symproms)
                .MaximumLength(1000).WithMessage("Symptoms cannot exceed 1000 characters.");

            RuleFor(x => x.Diagnosis)
                .MaximumLength(1000).WithMessage("Diagnosis cannot exceed 1000 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters.");

            RuleFor(x => x.Temperature)
                .Must(temp => !temp.HasValue || temp.Value > 0)
                .WithMessage("Temperature must be greater than 0.");

            RuleFor(x => x.Wight)
                .Must(weight => !weight.HasValue || weight.Value > 0)
                .WithMessage("Weight must be greater than 0.");

            RuleFor(x => x.BloodPressure)
                .Must(bp => !bp.HasValue || bp.Value > 0)
                .WithMessage("Blood Pressure must be greater than 0.");

            RuleFor(x => x.HeartRate)
                .Must(hr => !hr.HasValue || hr.Value > 0)
                .WithMessage("Heart Rate must be greater than 0.");
        }
    }
}