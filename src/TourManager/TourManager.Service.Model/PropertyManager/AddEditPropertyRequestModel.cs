using System.Collections.Generic;
using FluentValidation;

namespace TourManager.Service.Model.PropertyManager
{
    public class AddEditPropertyRequestModelValidator : AbstractValidator<AddEditPropertyRequestModel>
    {
        public AddEditPropertyRequestModelValidator()
        {
            RuleFor(item => item.Name).NotEmpty();
            RuleForEach(item => item.Attachments).SetValidator(new PropertyAttachmentModelValidator());
        }
    }

    public class AddEditPropertyRequestModel
    {
        public string Name { get; set; }

        public byte Stars { get; set; }

        public string Address { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public IEnumerable<PropertyAttachmentModel> Attachments { get; set; }
    }
}
