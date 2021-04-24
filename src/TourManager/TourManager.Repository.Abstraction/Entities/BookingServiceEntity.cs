using System;

namespace TourManager.Repository.Entities
{
    public class BookingServiceEntity
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int ServiceId { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfGuests { get; set; }

        public BookingEntity Booking { get; set; }
    }
}