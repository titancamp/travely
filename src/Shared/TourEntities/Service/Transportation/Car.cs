using System;

namespace TourEntities.Service.Transportation
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfCarSeats { get; set; }
    }
}
