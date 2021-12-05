using System;
using System.Collections.Generic;

namespace TourEntities.Service.Transportation
{
    public partial class Driver
    {
        public Guid Id { get; set; }
        //public int TransportationId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string LicenseType { get; set; }
        public int ContactNumber { get; set; }
        //public ICollection<Car> Car { get; set; }

    }
}
