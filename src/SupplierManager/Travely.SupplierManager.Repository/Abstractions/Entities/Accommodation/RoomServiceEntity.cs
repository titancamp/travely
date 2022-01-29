using TourEntities.Service.Accommodation.Room;

namespace Travely.SupplierManager.Repository.Entities
{
    public class RoomServiceEntity
    {
        public int Id { get; set; }
        public RoomService Service { get; set; }
        
        public RoomEntity Room { get; set; }
    }
}