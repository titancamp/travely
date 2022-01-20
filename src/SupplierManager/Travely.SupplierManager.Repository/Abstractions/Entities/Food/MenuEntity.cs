using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Travely.SupplierManager.Repository.Entities
{
    public class MenuEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public ICollection<AttachmentEntity<MenuEntity>> Attachments { get; set; }
        public ICollection<TagEntity> Tags { get; set; }
    }
}