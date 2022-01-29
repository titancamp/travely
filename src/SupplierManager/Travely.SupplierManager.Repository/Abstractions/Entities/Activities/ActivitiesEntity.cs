using System;
using System.Collections.Generic;

namespace Travely.SupplierManager.Repository.Entities
{
    public class ActivitiesEntity : IEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string TypeName { get; set; }
        public string Description { get; set; }
        public ICollection<AttributeEntity> Attributes { get; set; }
        public int Duration { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<AttachmentEntity<ActivitiesEntity>> Attachments { get; set; }
    }
}