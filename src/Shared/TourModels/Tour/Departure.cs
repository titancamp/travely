using System;

namespace TourModels.Tour
{
    public class Departure
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Location { get; set; }
        public string FlightNumber { get; set; }
    }
}
