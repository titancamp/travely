﻿using System;

namespace TourEntities.Service.Transportation
{
    public partial class Transporation
    {
        public Guid Id { get; set; }
        public TransportationType Type { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Accommodation.Location Location { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}
