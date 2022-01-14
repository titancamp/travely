namespace Travely.SupplierManager.Repository.Entities
{
    public class RoomServiceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public RoomEntity RoomEntity { get; set; }
    }
}