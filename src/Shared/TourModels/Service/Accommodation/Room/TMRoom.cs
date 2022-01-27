using System;
using System.Collections.Generic;

namespace TourEntities.Service.Accommodation.Room
{
    public partial class Room
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int NumberOfBeds { get; set; }
        public int AdditionalBeds { get; set; }
        public List<string> Services { get; set; }
    }
}