using System;
using System.Collections.Generic;

namespace Travely.TourManager.Repository.Repositories.Entities
{
    public class Tour
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<TourClient> TourClients { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
