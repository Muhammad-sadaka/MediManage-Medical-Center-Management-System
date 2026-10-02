using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class MedicalAnalysisDTOValidator : AbstractValidator<clsMedicalAnalysisDTO>
    {
        public MedicalAnalysisDTOValidator()
        {
            RuleFor(x => x.AnalysisTypeID)
                .NotNull().WithMessage("Analysis Type ID is required.")
                .GreaterThan(0).WithMessage("Analysis Type ID must be greater than 0.");

            RuleFor(x => x.DetectionID)
                .NotNull().WithMessage("Detection ID is required.")
                .GreaterThan(0).WithMessage("Detection ID must be greater than 0.");

            RuleFor(x => x.AnalysisStatusID)
                .NotNull().WithMessage("Analysis Status ID is required.")
                .GreaterThan(0).WithMessage("Analysis Status ID must be greater than 0.");

            RuleFor(x => x.OrderDate)
                .NotNull().WithMessage("Order Date is required.");

            RuleFor(x => x.ResultDate)
                .GreaterThanOrEqualTo(x => x.OrderDate)
                .When(x => x.OrderDate.HasValue && x.ResultDate.HasValue)
                .WithMessage("Result Date cannot be earlier than Order Date.");

            RuleFor(x => x.Result)
                .MaximumLength(1000).WithMessage("Result description cannot exceed 1000 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters.");
        }
    }
}
