using FluentValidation;
using System;
using System.Collections.Generic;
using TourManager.Common.Types;

namespace TourManager.Service.Model
{
    /// <summary>
    /// The booking validator
    /// </summary>
    public class BookingValidator : AbstractValidator<Booking>
    {
        /// <summary>
        /// Create new instance of booking validator
        /// </summary>
        public BookingValidator()
        {
            RuleFor(booking => booking.Name).NotEmpty().WithMessage("The booking name field is requiered!");
            RuleFor(booking => booking.Notes).NotEmpty().WithMessage("The booking notes field is requiered!");
            RuleFor(booking => booking.Destination).NotEmpty().WithMessage("The booking destination is required!");
        }
    }

    /// <summary>
    /// The booking model
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// The booking id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The external id
        /// </summary>
        public int ExternalId { get; set; }

        /// <summary>
        /// The booking name
        /// </summary>
        public string Name { get; set; }

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
        public TimeSpan? ArrivalTime { get; set; }

        /// <summary>
        /// The booking arrival flight number
        /// </summary>
        public string ArrivalFlightNumber { get; set; }

        /// <summary>
        /// The booking departure time
        /// </summary>
        public TimeSpan? DepartureTime { get; set; }

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