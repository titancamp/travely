using System;
using System.Collections.Generic;

namespace TourModels.Tour
{
    public partial class Tour
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }
        public string PartnerName { get; set; }
        public Group Group { get; set; }
        public List<Participant> Participants { get; set; }
        public Arrival Arrival { get; set; }
        public Departure Departure { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}