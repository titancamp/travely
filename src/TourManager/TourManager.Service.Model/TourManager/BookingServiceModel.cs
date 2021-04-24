using System;

namespace TourManager.Service.Model.TourManager
{
    public class BookingServiceModel
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int ServiceId { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfGuests { get; set; }
    }
}
