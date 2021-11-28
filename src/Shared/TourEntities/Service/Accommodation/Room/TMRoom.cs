using System;

namespace TourEntities.Service.Accommodation.Room
{
    public partial class Room
    {
        public Guid Id { get; set; }
        public RoomType Type { get; set; }
        public int Quantity { get; set; }
        public int NumberOfBeds { get; set; }
        public int AdditionalBeds { get; set; }
    }
}