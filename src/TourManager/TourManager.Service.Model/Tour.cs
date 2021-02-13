using System;
using System.Collections.Generic;

namespace TourManager.Service.Model
{
    /// <summary>
    /// The tour model
    /// </summary>
    public class Tour
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
        public bool? IsPackage { get; set; }

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
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// The tour end date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The tour pick up time
        /// </summary>
        public DateTime? PickUpTime { get; set; }

        /// <summary>
        /// The tour pick up details
        /// </summary>
        public string PickUpDetails { get; set; }

        /// <summary>
        /// The tour drop off time
        /// </summary>
        public DateTime? DropOffTime { get; set; }

        /// <summary>
        /// The tour drop off details
        /// </summary>
        public string DropOffDetails { get; set; }

        /// <summary>
        /// The tour notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The tour destinations
        /// </summary>
        public List<string> Destinations { get; set; }

        /// <summary>
        /// The tour bookings collection
        /// </summary>
        public List<Booking> Bookings { get; set; }

        /// <summary>
        /// The tour clients collection
        /// </summary>
        public List<Client> Clients { get; set; }
    }
}