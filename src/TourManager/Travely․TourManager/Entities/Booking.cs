using System;
using Travely.TourManager.Common;

namespace Travely.TourManager.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public BookType Type { get; set; }
        public BookStatus Status { get; set; }
        public DateTime CancellationDeadline { get; set; }
    }
}
