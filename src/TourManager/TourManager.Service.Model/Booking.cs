using FluentValidation;
using TourManager.Common.Types;
using TourManager.Service.Model.TourManager;

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
        /// The tour name
        /// </summary>
        public string TourName { get; set; }

        /// <summary>
        /// The booking type
        /// </summary>
        public BookingType Type { get; set; }

        /// <summary>
        /// The booking status
        /// </summary>
        public BookingStatus Status { get; set; }

        /// <summary>
        /// The booking property
        /// </summary>
        public BookingProperty BookingProperty { get; set; }

        /// <summary>
        /// The booking service
        /// </summary>
        public BookingService BookingService { get; set; }
    }
}