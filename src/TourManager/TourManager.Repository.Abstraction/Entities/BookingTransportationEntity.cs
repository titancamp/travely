using System;

namespace TourManager.Repository.Entities
{
    public class BookingTransportationEntity
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int TransportationId { get; set; }

        public string CompanyName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string DriverName { get; set; }

        public string CarModel { get; set; }

        public int PropertyId { get; set; }

        public string RoomType { get; set; }

        public int RoomCount { get; set; }

        public bool Accomodation { get; set; }

        public BookingEntity Booking { get; set; }

        public PropertyEntity Property { get; set; }
    }
}