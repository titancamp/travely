using FluentValidation;

namespace Travely.PropertyManager.API.Validators
{
    public class EditPropertyRequestValidator : AbstractValidator<EditPropertyRequest>
    {
        public EditPropertyRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
