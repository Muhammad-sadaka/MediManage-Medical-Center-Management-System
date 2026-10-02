using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class AppointmentCaseDTOValidator : AbstractValidator<clsAppointmentCaseDTO>
    {
        public AppointmentCaseDTOValidator()
        {
            RuleFor(x => x.AppointmentCaseName)
                .NotEmpty().WithMessage("Appointment Case Name is required.")
                .Length(2, 100).WithMessage("Appointment Case Name must be between 2 and 100 characters.");
        }
    }
}