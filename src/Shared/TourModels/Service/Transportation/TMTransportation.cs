using System;
using System.Collections.Generic;
using TourEntities.Service.Common.Location;

namespace TourEntities.Service.Transportation
{
    public partial class Transporation
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public List<string> Attachments { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}
