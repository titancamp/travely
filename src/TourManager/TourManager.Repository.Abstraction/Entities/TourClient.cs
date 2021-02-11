namespace TourManager.Repository.Entities
{
    public class TourClient
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}