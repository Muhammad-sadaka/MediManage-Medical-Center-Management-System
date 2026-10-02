using FluentValidation;
using MediManage_DataAccess;
using System;

namespace MediManage_API.Validators
{
    public class AppointmentDTOValidator : AbstractValidator<clsAppointmentDTO>
    {
        public AppointmentDTOValidator()
        {
            RuleFor(x => x.PatientID)
                .NotNull().WithMessage("Patient ID is required.")
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(x => x.DoctorID)
                .NotNull().WithMessage("Doctor ID is required.")
                .GreaterThan(0).WithMessage("Doctor ID must be greater than 0.");

            RuleFor(x => x.CreatedByUserID)
                .NotNull().WithMessage("Created By User ID is required.")
                .GreaterThan(0).WithMessage("Created By User ID must be greater than 0.");

            RuleFor(x => x.AppointmentDate)
                .NotNull().WithMessage("Appointment Date is required.");

            RuleFor(x => x.AppointmentCaseID)
                .NotNull().WithMessage("Appointment Case ID is required.")
                .GreaterThan(0).WithMessage("Appointment Case ID must be greater than 0.");

            // التعديل هنا: فحص القيمة فقط إذا كانت ليست null باستخدام .Value
            RuleFor(x => x.Duration)
                .Must(duration => !duration.HasValue || duration.Value > 0)
                .WithMessage("Duration must be greater than 0 minutes.");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters.");
        }
    }
}