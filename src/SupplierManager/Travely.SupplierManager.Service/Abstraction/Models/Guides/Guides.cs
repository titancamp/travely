﻿using System;
using System.Collections.Generic;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Guide;

namespace Travely.SupplierManager.Service.Models
{
    public class Guides
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public GuideType Type { get; set; }
        public string Name { get; set; }
        
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; } 
        public string ContactEmail { get; set; }
        
        public Location Location { get; set; }
        public TmRegion TmRegion { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        
        public List<Guide> Guide { get; set; }
        
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}