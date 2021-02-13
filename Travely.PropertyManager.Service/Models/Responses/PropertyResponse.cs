namespace Travely.PropertyManager.Service.Models.Responses
{
    public class PropertyResponse
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public float Stars { get; set; }
        public string Address { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
    }
}
