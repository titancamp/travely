namespace Travely.TourManager.Repository.Repositories.Entities
{
    public class Booking
    {
        public long Id { get; set; }

        public long ExternalId { get; set; }

        public long TourId { get; set; }

        public Tour Tour { get; set; }
    }
}
