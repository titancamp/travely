using System.Collections.Generic;

namespace Travely.SupplierManager.Repository.Entities
{
    public class MenuEntity
    {
        public int Id { get; set; }
        public ICollection<AttachmentEntity<MenuEntity>> Attachments { get; set; }
        public ICollection<TagEntity> Tags { get; set; }
    }
}