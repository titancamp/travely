using System;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AttachmentEntity<TEntity>
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        
        public TEntity User { get; set; }
    }
}