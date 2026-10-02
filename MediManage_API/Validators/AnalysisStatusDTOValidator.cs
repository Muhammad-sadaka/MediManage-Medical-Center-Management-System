using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class AnalysisStatusDTOValidator : AbstractValidator<clsAnalysisStatusDTO>
    {
        public AnalysisStatusDTOValidator()
        {
            RuleFor(x => x.AnalysisStatusName)
                .NotEmpty().WithMessage("Analysis Status Name is required.")
                .Length(2, 100).WithMessage("Analysis Status Name must be between 2 and 100 characters.");
        }
    }
}