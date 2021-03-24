using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Api.Models.Requests
{
    public class AddPropertyRequestModel
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

        public IEnumerable<PropertyAttachment> Attachments { get; set; }

        public IFormFileCollection AttachmentsToAdd { get; set; }
    }
}
