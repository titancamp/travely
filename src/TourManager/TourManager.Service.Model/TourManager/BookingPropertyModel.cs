using System;
using System.Collections.Generic;

namespace TourManager.Service.Model.TourManager
{
    public class BookingPropertyModel
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int PropertyId { get; set; }

        /// <summary>
        /// The booking checkin date
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// The booking checkout date
        /// </summary>
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// The booking cancellation deadline
        /// </summary>
        public DateTime CancellationDeadline { get; set; }

        /// <summary>
        /// The booking origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// The booking arrival time
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// The booking arrival flight number
        /// </summary>
        public string ArrivalFlightNumber { get; set; }

        /// <summary>
        /// The booking departure time
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// The booking departure flight number
        /// </summary>
        public string DepartureFlightNumber { get; set; }

        /// <summary>
        /// The booking rooms
        /// </summary>
        public ICollection<BookingPropertyRoomModel> BookingPropertyRooms { get; set; } = new List<BookingPropertyRoomModel>();
    }
}
