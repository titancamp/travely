using System;
using System.Collections.Generic;
using TourEntities.Service.Common.Location;

namespace TourEntities.Service.Activity
{
    public partial class TMActivity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string Description { get; set; }
        public string Attributes { get; set; }
        public int Duration { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string StartPoint { get; set; }
        public Location StartLocation { get; set; }
        public List<string> Attachments { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}
