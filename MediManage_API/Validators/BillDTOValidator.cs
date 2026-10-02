using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class BillDTOValidator : AbstractValidator<clsBillDTO>
    {
        public BillDTOValidator()
        {
            RuleFor(x => x.PatientID)
                .NotNull().WithMessage("Patient ID is required.")
                .GreaterThan(0).WithMessage("Patient ID must be greater than 0.");

            RuleFor(x => x.CreatedByUserID)
                .NotNull().WithMessage("Created By User ID is required.")
                .GreaterThan(0).WithMessage("Created By User ID must be greater than 0.");

            RuleFor(x => x.PaymentStatusID)
                .NotNull().WithMessage("Payment Status ID is required.")
                .GreaterThan(0).WithMessage("Payment Status ID must be greater than 0.");

            RuleFor(x => x.TotalAmount)
                .NotNull().WithMessage("Total Amount is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Total Amount must be a positive number or zero.");

            RuleFor(x => x.AmountOfPaid)
                .NotNull().WithMessage("Amount Of Paid is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Amount Of Paid must be a positive number or zero.");

            RuleFor(x => x.AmountOfRemaining)
                .NotNull().WithMessage("Amount Of Remaining is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Amount Of Remaining must be a positive number or zero.");

            RuleFor(x => x.BillDate)
                .NotNull().WithMessage("Bill Date is required.");
        }
    }
}