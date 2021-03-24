using System;
using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    /// <summary>
    /// The tour entity
    /// </summary>
    public class TourEntity
    {
        /// <summary>
        /// The tour id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The tour tenant id
        /// </summary>
        public int TenantId { get; set; }

        /// <summary>
        /// Is tour package
        /// </summary>
        public bool IsPackage { get; set; }

        /// <summary>
        /// The tour name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
		/// The tour price
		/// </summary>
		public decimal Price { get; set; }

        /// <summary>
		/// The tour origin
		/// </summary>
		public string Origin { get; set; }

        /// <summary>
        /// The tour start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The tour end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
		/// The tour pick up time
		/// </summary>
		public DateTime PickUpTime { get; set; }

        /// <summary>
        /// The tour pick up details
        /// </summary>
        public string PickUpDetails { get; set; }

        /// <summary>
		/// The tour drop off time
		/// </summary>
		public DateTime DropOffTime { get; set; }

        /// <summary>
        /// The tour drop off details
        /// </summary>
        public string DropOffDetails { get; set; }

        /// <summary>
        /// The tour notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The tour tenant entity
        /// </summary>
        public TenantEntity Tenant { get; set; }

        /// <summary>
        /// The tour bookings collection
        /// </summary>
        public ICollection<BookingEntity> Bookings { get; set; }

        /// <summary>
        /// The tour clients collection
        /// </summary>
        public ICollection<TourClientEntity> TourClients { get; set; }
    }
}