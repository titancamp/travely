using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AccommodationTypeEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}