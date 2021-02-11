namespace Travely.PropertyManager.Domain.Contracts.Models.Commands
{
    public class AddPropertyCommand
    {
        public string Name { get; set; }
        public float Stars { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
    }
}
