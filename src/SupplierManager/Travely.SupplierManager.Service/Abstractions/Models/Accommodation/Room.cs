using System.Collections.Generic;
using Travely.SupplierManager.Repository.Entities;

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
        public List<RoomService> Services { get; set; }
    }
}