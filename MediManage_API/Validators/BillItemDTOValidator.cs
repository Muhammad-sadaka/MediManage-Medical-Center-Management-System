using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class BillItemDTOValidator : AbstractValidator<clsBillItemDTO>
    {
        public BillItemDTOValidator()
        {
            RuleFor(x => x.Bill_ID)
                .NotNull().WithMessage("Bill ID is required.")
                .GreaterThan(0).WithMessage("Bill ID must be greater than 0.");

            RuleFor(x => x.ServiceTypeID)
                .NotNull().WithMessage("Service Type ID is required.")
                .GreaterThan(0).WithMessage("Service Type ID must be greater than 0.");

            RuleFor(x => x.Amount)
                .NotNull().WithMessage("Amount (Quantity) is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than 0.");

            RuleFor(x => x.Total)
                .NotNull().WithMessage("Total is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Total must be a positive number or zero.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}