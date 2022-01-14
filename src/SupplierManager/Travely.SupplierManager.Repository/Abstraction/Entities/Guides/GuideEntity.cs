using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class GuideEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public AttachmentEntity Image { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        public ICollection<LanguageEntity> Languages { get; set; }
        // public int Experience { get; set; } // TODO TBD
        // public List<string> Skills { get; set; } // TODO TBD
    }
}