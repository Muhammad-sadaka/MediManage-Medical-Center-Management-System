using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class AnalysisTypeDTOValidator : AbstractValidator<clsAnalysisTypeDTO>
    {
        public AnalysisTypeDTOValidator()
        {
            RuleFor(x => x.AnalysisTypeName)
                .NotEmpty().WithMessage("Analysis Type Name is required.")
                .Length(2, 100).WithMessage("Analysis Type Name must be between 2 and 100 characters.");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Price must be a positive number or zero.");
        }
    }
}