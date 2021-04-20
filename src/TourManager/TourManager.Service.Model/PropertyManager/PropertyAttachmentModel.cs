using FluentValidation;

namespace TourManager.Service.Model.PropertyManager
{
    public class PropertyAttachmentModelValidator : AbstractValidator<PropertyAttachmentModel>
    {
        public PropertyAttachmentModelValidator()
        {
            RuleFor(item => item.FileId).NotEmpty();
            RuleFor(item => item.Name).NotEmpty();
        }
    }

    public class PropertyAttachmentModel
    {
        public int Id { get; set; }

        public string FileId { get; set; }

        public string Name { get; set; }
    }
}
