using System;
using Travely.TourManager.Service.Enums;

namespace Travely.TourManager.Service.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public BookType Type { get; set; }
        public BookStatus Status { get; set; }
        public DateTime CancellationDeadline { get; set; }
    }
}
