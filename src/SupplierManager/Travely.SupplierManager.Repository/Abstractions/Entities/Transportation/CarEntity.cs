using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class CarEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [StringLength(10)]
        public string PlateNumber { get; set; }
        [Range(0, 99)]
        public int NumberOfSeats { get; set; }
        [Range(0, 99)]
        public int NumberOfCarSeats { get; set; }
    }
}