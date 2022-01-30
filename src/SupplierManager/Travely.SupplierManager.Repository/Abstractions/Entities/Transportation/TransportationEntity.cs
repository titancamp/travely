using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Transportation;

namespace Travely.SupplierManager.Repository.Entities
{
    public class TransportationEntity : IEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public TransportationType Type { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public LocationEntity Location { get; set; }
        public TmRegion TmRegion { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public ICollection<DriverEntity> Drivers { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<AttachmentEntity<TransportationEntity>> Attachments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}