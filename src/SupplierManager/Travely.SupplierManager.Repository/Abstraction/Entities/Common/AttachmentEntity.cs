using System;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AttachmentEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
    }
}