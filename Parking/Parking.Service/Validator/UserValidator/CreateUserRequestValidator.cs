using FluentValidation;
using Parking.Controllers.UserController;

namespace Parking.Validator.UserValidator;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(80)
            .Matches("[А-Я][а-я]*-?[А-Я][а-я]*")
            .WithMessage("Last name is required");
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .Matches("[А-Я][а-я]*")
            .WithMessage("First name is required");
        
        RuleFor(x => x.Birthday)
            .NotEmpty()
            .Must(y => y < DateTime.UtcNow.AddYears(-18))
            .WithMessage("Birthday is required");
        
        RuleFor(x => x.Patronymic)
            .MaximumLength(50)
            .Matches("[А-Я][а-я]*")
            .WithMessage("Patronymic is required");
        
        RuleFor(x => x.Login)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Login is required");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
        
        var conditions = new List<string> { "User", "Worker" ,"Admin"};
        RuleFor(x => x.UserRole)
            .NotEmpty()
            .Must(x => conditions.Contains(x))
            .WithMessage("User role is required");
    }
}