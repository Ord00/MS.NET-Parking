using FluentValidation;
using Parking.Controllers.VehicleController;

namespace Parking.Validator;

public class CreateVehicleRequestValidator : AbstractValidator<CreateVehicleRequest>
{
    public CreateVehicleRequestValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(40)
            .Matches("( [А-Я][а-я]*-?[А-Я][а-я]*)*")
            .WithMessage("Model is required");
        
        RuleFor(x => x.Brand)
            .NotEmpty()
            .MaximumLength(30)
            .Matches("[А-Я][а-я]*")
            .WithMessage("Brand is required");
        
        RuleFor(x => x.Colour)
            .NotEmpty()
            .MaximumLength(20)
            .Matches("[А-Я][а-я]*-?[а-я]*")
            .WithMessage("Colour is required");
        
        RuleFor(x => x.VehicleTypeId)
            .NotEmpty()
            .WithMessage("Vehicle type id is required");
        
        RuleFor(x => x.RegistrationPlateId)
            .NotEmpty()
            .WithMessage("Registration plate id is required");
    }
}