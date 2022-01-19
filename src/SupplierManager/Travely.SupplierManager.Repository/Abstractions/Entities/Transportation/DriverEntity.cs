using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class DriverEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [MaxLength(4)]
        public ICollection<LicenseTypeEntity> LicenseType { get; set; }
        [MaxLength(50)]
        public ICollection<LanguageEntity<DriverEntity>> Languages { get; set; }
    }
}