using System;
using System.Collections.Generic;

namespace TourEntities.Service.Guide
{
    public class GuideInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //Might need to add a reference to Guide
        public string Image { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public List<string> Languages { get; set; }
        public string Experience { get; set; } //TBD
        public string Skills { get; set; } //TBD
    }
}