using FluentValidation;
using Parking.Controllers.SessionController;

namespace Parking.Validator.SessionValidator;

public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionRequestValidator()
    {
        RuleFor(x => x.EntryDate)
            .NotEmpty()
            .Must(y => y <= DateTime.UtcNow)
            .WithMessage("Entry date is required");
        
        RuleFor(x => x.ExitDate)
            .NotEmpty()
            .Must(y => y > DateTime.UtcNow)
            .WithMessage("Exit date is required");
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User id is required");
        
        RuleFor(x => x.VehicleId)
            .NotEmpty()
            .WithMessage("Vehicle id is required");
    }
}