using System.Collections.Generic;

namespace TourManager.Common.Clients.PropertyManager
{
    public class EditPropertyRequestDto : AddPropertyRequestDto
    {
        public int Id { get; set; }

        public IEnumerable<PropertyAttachmentDto> Attachments { get; set; }
    }
}
