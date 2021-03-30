using FluentValidation;

namespace Travely.PropertyManager.API.Validators
{
    public class AddPropertyRequestValidator : AbstractValidator<AddPropertyRequest>
    {
        public AddPropertyRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
