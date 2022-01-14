using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class TransportationTypeEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}