using EasyCashDTOLayer.Dtos.AppUserDtos;
using FluentValidation;

namespace EasyCashBusinessLogicLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor( x => x.UserName ).NotEmpty().WithMessage("User Name can not be null or empty!");
            RuleFor( x => x.Name ).NotEmpty().WithMessage("User Name can not be null or empty!");
            RuleFor( x => x.Surname ).NotEmpty().WithMessage("User Name can not be null or empty!");
            RuleFor( x => x.Email ).EmailAddress().WithMessage("Please enter a valid email address!");
            RuleFor( x => x.Phone ).NotEmpty().WithMessage("User Name can not be null or empty!");
            RuleFor( x => x.Password ).NotEmpty().WithMessage("User Name can not be null or empty!");
            RuleFor( x => x.ConfirmPassword ).NotEmpty().WithMessage("User Name can not be null or empty!");

            RuleFor( x => x.UserName ).MaximumLength(30).WithMessage("User Name can be maximum 30 characters");
            RuleFor( x => x.UserName ).MinimumLength(5).WithMessage("User Name can be at least 5 characters");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Can be maximum 20 characters");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Can be at least 2 characters");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Can be maximum 30 characters");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Can be at least 2 characters");

            RuleFor(x => x.Password)
           .NotEmpty().MinimumLength(8).WithMessage("Password is required.")
           .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
           .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character with minimum 8 character!");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords don't matches !");
        }
    }
}
