using System;

namespace TourModels.Tour
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string PassportNumber { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string SpecialPreferences { get; set; }
        public bool AllInclusive { get; set; }
    }
}
