using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string PlateNumber { get; set; }
        [Range(0, 99)]
        public int NumberOfSeats { get; set; }
        [Range(0, 99)]
        public int NumberOfCarSeats { get; set; }
        
        public TransportationEntity Transportation { get; set; }
    }
}