using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Travely.SupplierManager.Repository.Entities
{
    public class TagEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
    }
}