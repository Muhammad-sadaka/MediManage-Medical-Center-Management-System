using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class PaymentMethodDTOValidator : AbstractValidator<clsPaymentMethodDTO>
    {
        public PaymentMethodDTOValidator()
        {
            RuleFor(x => x.PaymentMethodName)
                .NotEmpty().WithMessage("Payment method name is required.")
                .MaximumLength(50).WithMessage("Payment method name cannot exceed 50 characters.");
        }
    }
}