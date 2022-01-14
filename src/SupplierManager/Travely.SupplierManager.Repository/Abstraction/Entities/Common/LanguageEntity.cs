using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class LanguageEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}