using System;

namespace TourManager.Service.Model.TourManager
{
    public class BookingProperty
    {
        /// <summary>
        /// The property identifier.
        /// </summary>
        public int PropertyId { get; set; }

        /// <summary>
        /// The property name.
        /// </summary>
        public string PropertyName { get; set; }

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
        /// The booking notes
        /// </summary>
        public string Notes { get; set; }
    }
}
