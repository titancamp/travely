using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AttributeEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
    }
}