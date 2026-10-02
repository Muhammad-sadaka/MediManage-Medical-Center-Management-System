using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class PersonDTOValidator : AbstractValidator<clsPersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.SecondName)
                .MaximumLength(50).WithMessage("Second name cannot exceed 50 characters.");

            RuleFor(x => x.ThirdName)
                .MaximumLength(50).WithMessage("Third name cannot exceed 50 characters.");

            RuleFor(x => x.NationalNo)
                .NotEmpty().WithMessage("National number is required.")
                .MaximumLength(20).WithMessage("National number cannot exceed 20 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Invalid email format.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required.")
                .MaximumLength(10).WithMessage("Gender cannot exceed 10 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotNull().WithMessage("Date of birth is required.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");
        }
    }
}