using System.Collections.Generic;

namespace Travely.SupplierManager.Repository.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int NumberOfBeds { get; set; }
        public int AdditionalBeds { get; set; }
        public ICollection<RoomServiceEntity> Services { get; set; }
    }
}