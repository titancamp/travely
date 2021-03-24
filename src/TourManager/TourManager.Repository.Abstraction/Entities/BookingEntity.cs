using System;

namespace TourManager.Repository.Entities
{
    /// <summary>
    /// The booking entity
    /// </summary>
    public class BookingEntity
    {
        /// <summary>
        /// The booking id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The tour id of the booking
        /// </summary>
        public int TourId { get; set; }

        /// <summary>
        /// The external id
        /// </summary>
        public int ExternalId { get; set; }

        /// <summary>
        /// The tour entity of the booking
        /// </summary>
        public TourEntity Tour { get; set; }

        /// <summary>
        /// The booking name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The booking type
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// The booking status
        /// </summary>
        public int Status { get; set; }

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
        /// The booking notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The booking destination
        /// </summary>
        public string Destination { get; set; }
    }
}