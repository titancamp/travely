using FluentValidation;

namespace Travely.ClientManager.Grpc.Validators
{
    /// <summary>
    /// The client validator
    /// </summary>
    public class ClientValidator : AbstractValidator<Models.Client>
    {
        /// <summary>
        /// Create new instance of client validator
        /// </summary>
        public ClientValidator()
        {
            RuleFor(client => client.FirstName).NotEmpty().WithMessage("The client first name field is required!");
            RuleFor(client => client.LastName).NotEmpty().WithMessage("The client last name field is required!");
            RuleFor(client => client.PhoneNumber).NotEmpty().WithMessage("The client phone field is required!");
            RuleFor(client => client.Email).NotEmpty().WithMessage("The client email field is required!")
                .EmailAddress().WithMessage("The client email address is not valid!");
        }
    }
}
