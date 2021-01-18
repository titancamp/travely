using System;
using Travely.TourManager.Enums;

namespace Travely.TourManager.Repository.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public BookType Type { get; set; }
        public BookStatus Status { get; set; }
        public DateTime CancellationDeadline { get; set; }
    }
}
