using System;
using System.Collections.Generic;
using TourEntities.Service.Accommodation;
using TourEntities.Service.Common.Location;

namespace Travely.SupplierManager.Service.Models
{
    public class Accommodation
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; }
        public AccommodationType Type { get; set; }
        public string Name { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        
        public Location Location { get; set; }
        public TmRegion TmRegion { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        
        public List<AccommodationServiceModel> Services { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }

        public List<Room> Rooms { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }

        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Attachment> Attachments { get; set; }
        
        public bool AllInclusive { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }

        public AccommodationStatus Status { get; set; }
    }
}