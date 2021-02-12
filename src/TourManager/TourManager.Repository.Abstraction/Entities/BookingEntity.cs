namespace TourManager.Repository.Entities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int ExternalId { get; set; }
        public TourEntity Tour { get; set; }
    }
}