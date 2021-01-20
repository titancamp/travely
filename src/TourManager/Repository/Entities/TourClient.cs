namespace Travely.TourManager.Repository.Repositories.Entities
{
    public class TourClient
    {
        public long Id { get; set; }

        public long TourId { get; set; }

        public Tour Tour { get; set; }
        
        public long ClientId { get; set; }

        public Client Client { get; set; }
    }
}
