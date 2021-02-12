namespace TourManager.Repository.Entities
{
    public class TourClientEntity
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public TourEntity Tour { get; set; }
        public int ClientId { get; set; }
        public ClientEntity Client { get; set; }
    }
}