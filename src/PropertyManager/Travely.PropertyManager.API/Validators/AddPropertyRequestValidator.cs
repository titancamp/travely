using FluentValidation;
using Travely.PropertyManager.Grpc;

namespace Travely.PropertyManager.API.Validators
{
    public class AddPropertyRequestValidator : AbstractValidator<AddPropertyRequest>
    {
        public AddPropertyRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Latitude).Must(latitude => !latitude.HasValue || (latitude.Value >= -90 && latitude.Value <= 90))
                .WithMessage("Latitude must be between -90 and 90 degrees inclusive.");
            RuleFor(x => x.Longitude).Must(longitude => !longitude.HasValue || (longitude.Value >= -180 && longitude.Value <= 180))
                .WithMessage("Longitude must be between -180 and 180 degrees inclusive.");
        }
    }
}
