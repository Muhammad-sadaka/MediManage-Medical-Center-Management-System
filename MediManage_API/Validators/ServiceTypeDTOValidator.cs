using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class ServiceTypeDTOValidator : AbstractValidator<clsServiceTypeDTO>
    {
        public ServiceTypeDTOValidator()
        {
            RuleFor(x => x.ServicTypeName)
                .NotEmpty().WithMessage("Service type name is required.")
                .MaximumLength(100).WithMessage("Service type name cannot exceed 100 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).When(x => x.Price.HasValue)
                .WithMessage("Price must be greater than or equal to 0.");
        }
    }
}