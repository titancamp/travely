using System;
using System.Collections.Generic;

namespace TourEntities.Service.Accommodation
{
    public partial class Accommodation
    {
        public Guid Id { get; set; }
        public AccommodationType Type { get; set; }
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
        public ICollection<Room.Room> Rooms { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}