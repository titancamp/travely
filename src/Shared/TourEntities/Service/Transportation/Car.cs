using System;
using System.Collections.Generic;

namespace TourEntities.Service.Transportation
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfCarSeats { get; set; }
        public List<string> Attachments { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
