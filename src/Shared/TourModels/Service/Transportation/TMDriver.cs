using System;
using System.Collections.Generic;

namespace TourEntities.Service.Transportation
{
    public partial class Driver
    {
        public Guid Id { get; set; }
        public int TransportationId { get; set; }
        public string Name { get; set; }
        public List<string> Languages { get; set; }
        public List<string> LicenseType { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
