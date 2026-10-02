using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class PaymentStatusDTOValidator : AbstractValidator<clsPaymentStatusDTO>
    {
        public PaymentStatusDTOValidator()
        {
            RuleFor(x => x.PaymentStatusName)
                .NotEmpty().WithMessage("Payment status name is required.")
                .MaximumLength(50).WithMessage("Payment status name cannot exceed 50 characters.");
        }
    }
}