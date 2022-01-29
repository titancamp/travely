using FluentValidation;

namespace Travely.PropertyManager.Grpc.Models
{
    public class AddEditPropertyRequestModelValidator : AbstractValidator<AddEditPropertyRequestModel>
    {
        public AddEditPropertyRequestModelValidator()
        {
            RuleFor(item => item.Name).NotEmpty();
            RuleForEach(item => item.Attachments).SetValidator(new PropertyAttachmentModelValidator());
        }
    }
}
