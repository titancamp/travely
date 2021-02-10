using FluentValidation;

namespace TourManager.Service.Model.Validations
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(a => a.TourName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
