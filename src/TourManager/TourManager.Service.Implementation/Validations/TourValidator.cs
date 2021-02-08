using FluentValidation;
using TourManager.Service.Model;

namespace TourManager.Service.Implementation.Validations
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
