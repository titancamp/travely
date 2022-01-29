using System.Collections.Generic;
using TourEntities.Service.Accommodation.Room;

namespace Travely.SupplierManager.Service.Models
{
    public class Room
    {
        public int Id { get; set; }
        public RoomType Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int NumberOfBeds { get; set; }
        public int AdditionalBeds { get; set; }
        public List<RoomServiceModel> Services { get; set; }
    }
}