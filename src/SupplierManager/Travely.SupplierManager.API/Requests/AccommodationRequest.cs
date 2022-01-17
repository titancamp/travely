using System;
using System.Collections.Generic;
using System.Drawing;
using TourEntities.Service.Accommodation;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API.Requests
{
    public class AccommodationRequest
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public Location Location { get; set; }
        public Region Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<AccommodationService> Services { get; set; }
        public string Notes { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }

        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        
        public bool AllInclusive { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }

        public string Status { get; set; }
    }
}