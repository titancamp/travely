using System;
using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class TourEntity
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TenantEntity Tenant { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; }
        public ICollection<TourClientEntity> TourClients { get; set; }
	}
}