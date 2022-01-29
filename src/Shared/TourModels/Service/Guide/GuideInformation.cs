using System;
using System.Collections.Generic;

namespace TourEntities.Service.Guide
{
    public class GuideInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GuideAgencyId { get; set; }
        public string Image { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public List<string> Languages { get; set; }
        public string Experience { get; set; } //TBD
        public string Skills { get; set; } //TBD
    }
}