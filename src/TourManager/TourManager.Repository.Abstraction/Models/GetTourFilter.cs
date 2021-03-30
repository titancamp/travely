using System;

namespace TourManager.Repository.Models
{
    public class GetTourFilter
    {
        public int AgencyId { get; set; }

        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
    }
}