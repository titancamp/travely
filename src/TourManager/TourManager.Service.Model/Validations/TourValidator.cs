using FluentValidation;

namespace TourManager.Service.Model.Validations
{
    /// <summary>
    /// The tour validator
    /// </summary>
    public class TourValidator : AbstractValidator<Tour>
    {
        /// <summary>
        /// Create new instance of tour validator
        /// </summary>
        public TourValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
