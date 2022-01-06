using FluentValidation;

namespace Travely.PropertyManager.Grpc.Models
{
    public class PropertyAttachmentModelValidator : AbstractValidator<PropertyAttachmentModel>
    {
        public PropertyAttachmentModelValidator()
        {
            RuleFor(item => item.FileId).NotEmpty();
            RuleFor(item => item.Name).NotEmpty();
        }
    }
}
