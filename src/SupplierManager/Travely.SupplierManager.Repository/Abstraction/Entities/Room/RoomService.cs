namespace Travely.SupplierManager.Repository.Entities
{
    public class RoomServiceEntity
    {
        public int Id { get; set; }
        public RoomEntity Room {get; set; }
        public string Name { get; set; }
    }
}