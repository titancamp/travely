using FluentValidation;
using System;
using System.Collections.Generic;
using TourManager.Common.Types;

namespace TourManager.Service.Model.TourManager
{
    /// <summary>
    /// The booking model
    /// </summary>
    public class BookingResponseModel
    {
        /// <summary>
        /// The booking id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The booking type
        /// </summary>
        public BookingType Type { get; set; }

        /// <summary>
        /// The booking status
        /// </summary>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// The booking checkin date
        /// </summary>
        public DateTime? CheckInDate { get; set; }

        /// <summary>
        /// The booking checkout date
        /// </summary>
        public DateTime? CheckOutDate { get; set; }

        /// <summary>
        /// The booking cancellation deadline
        /// </summary>
        public DateTime? CancellationDeadline { get; set; }

        /// <summary>
        /// The booking origin
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// The booking arrival time
        /// </summary>
        public DateTime? ArrivalTime { get; set; }

        /// <summary>
        /// The booking arrival flight number
        /// </summary>
        public string ArrivalFlightNumber { get; set; }

        /// <summary>
        /// The booking departure time
        /// </summary>
        public DateTime? DepartureTime { get; set; }

        /// <summary>
        /// The booking departure flight number
        /// </summary>
        public string DepartureFlightNumber { get; set; }

        /// <summary>
        /// The booking notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The booking rooms.
        /// </summary>
        public ICollection<BookingPropertyRoomModel> BookingRooms { get; set; } = new List<BookingPropertyRoomModel>();
    }
}