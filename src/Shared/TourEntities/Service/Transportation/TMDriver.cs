using System;
using System.Collections.Generic;

namespace TourEntities.Service.Transportation
{
    public partial class Driver
    {
        public Guid Id { get; set; }
        //public int TransportationId { get; set; } Might need to add a reference to Transportation
        public string Name { get; set; }
        public List<string> Languages { get; set; }
        public List<string> LicenseType { get; set; }
        public int ContactPhone { get; set; }
        //public ICollection<Car> Car { get; set; } Might need to add a reference to Cars 
    }
}
