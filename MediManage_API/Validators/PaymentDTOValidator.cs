using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class PaymentDTOValidator : AbstractValidator<clsPaymentDTO>
    {
        public PaymentDTOValidator()
        {
            RuleFor(x => x.Bill_ID)
                .NotNull().WithMessage("Bill ID is required.")
                .GreaterThan(0).WithMessage("Bill ID must be greater than 0.");

            RuleFor(x => x.Amount)
                .NotNull().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.PaymentDate)
                .NotNull().WithMessage("Payment date is required.");

            RuleFor(x => x.CreatedByUserID)
                .NotNull().WithMessage("Created By User ID is required.")
                .GreaterThan(0).WithMessage("Created By User ID must be greater than 0.");

            RuleFor(x => x.PaymentMethodID)
                .NotNull().WithMessage("Payment Method ID is required.")
                .GreaterThan(0).WithMessage("Payment Method ID must be greater than 0.");
        }
    }
}