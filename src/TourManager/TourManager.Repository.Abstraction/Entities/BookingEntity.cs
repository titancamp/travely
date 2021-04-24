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
        /// The booking type
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// The booking status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// The booking notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The tour entity of the booking
        /// </summary>
        public TourEntity Tour { get; set; }

        public BookingPropertyEntity BookingProperty { get; set; }

        public BookingServiceEntity BookingService { get; set; }

        public BookingTransportationEntity BookingTransportation { get; set; }
    }
}