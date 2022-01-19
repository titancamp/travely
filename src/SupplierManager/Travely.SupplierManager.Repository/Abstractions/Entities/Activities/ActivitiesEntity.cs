using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Travely.SupplierManager.Repository.Entities
{
    public class ActivitiesEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [StringLength(50)]
        public string TypeName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [MaxLength(10)]
        public ICollection<AttributeEntity> Attributes { get; set; }
        public int Duration { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public decimal Cost { get; set; }
        
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [MaxLength(5)]
        public ICollection<AttachmentEntity> Attachments { get; set; }
    }
}