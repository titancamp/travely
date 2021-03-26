using System;

namespace TourManager.Repository.Models
{
    public class GetBookingFilter
    {
        public int AgencyId { get; set; }

        public int? TourId { get; set; }

        public DateTime? CancellationDeadlineFrom { get; set; }
    }
}