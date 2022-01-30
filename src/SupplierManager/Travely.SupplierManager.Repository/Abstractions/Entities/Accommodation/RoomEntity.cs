using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourEntities.Service.Accommodation.Room;

namespace Travely.SupplierManager.Repository.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public RoomType Type { get; set; }
        [Range(0, 99)]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        [Range(0, 99)]
        public int NumberOfBeds { get; set; }
        [Range(0, 99)]
        public int AdditionalBeds { get; set; }
        public ICollection<RoomServiceEntity> Services { get; set; }
        
        public AccommodationEntity Accommodation { get; set; }
    }
}