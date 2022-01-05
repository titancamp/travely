using System;
using System.Collections.Generic;
using TourEntities.Service.Accommodation.Room;
using TourEntities.Service.Common.Location;

namespace Travely.SupplierManager.API.Responses
{
    public class AccommodationResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Location Location { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public bool AllInclusive { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public List<string> Services { get; set; }
        public List<string> Attachments { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}