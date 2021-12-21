﻿using System;
using System.Collections.Generic;

namespace TourEntities.Service.Food
{
    public partial class Food
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public Location.Location Location { get; set; }
        public List<string> Menu { get; set; }
        public List<string> MenuAttachments { get; set; }
        public string Notes { get; set; }
        public List<string> Attachments { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}
