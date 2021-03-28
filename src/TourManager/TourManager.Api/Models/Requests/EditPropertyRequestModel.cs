using System.Collections.Generic;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Api.Models.Requests
{
    public class EditPropertyRequestModel : AddPropertyRequestModel
    {
        public IEnumerable<PropertyAttachmentDto> Attachments { get; set; }
    }
}
