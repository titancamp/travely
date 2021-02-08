namespace TourManager.Repository.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
    }
}