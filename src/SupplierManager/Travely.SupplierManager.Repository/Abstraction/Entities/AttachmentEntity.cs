using System;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AttachmentEntity
    {
        public int Id { get; set; }
        public AccommodationEntity Accommodation {get; set; }
        public Guid AttachmentGuid { get; set; }
    }
}
