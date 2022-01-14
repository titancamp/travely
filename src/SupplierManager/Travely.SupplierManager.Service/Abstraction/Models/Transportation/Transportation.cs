using System;
using System.Collections.Generic;

namespace Travely.SupplierManager.Service.Models
{
    public class Transportation
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public TransportationType Type { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public Location Location { get; set; }
        public Region Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Car> Cars { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}