using System;
using System.Collections.Generic;

namespace TourModels.Tour
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfParticipants { get; set; }
        public int NumberOfChildren { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public List<string> Preferences { get; set; }
        public List<string> Attachments { get; set; }
    }
}
