using System.Collections;
using System.Collections.Generic;

namespace Travely.PropertyManager.Data.Models
{
    public class Property
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte Stars { get; set; }

        public string Address { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string ContactName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public ICollection<PropertyAttachment> Attachments { get; set; } = new List<PropertyAttachment>();
    }
}
