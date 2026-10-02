using FluentValidation;
using MediManage_DataAccess;

namespace MediManage_API.Validators
{
    public class UserDTOValidator : AbstractValidator<clsUserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.PersonID)
                .NotNull().WithMessage("Person ID is required.")
                .GreaterThan(0).WithMessage("Invalid Person ID.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("IsActive status is required.");
        }
    }

    public class LoginRequestValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}