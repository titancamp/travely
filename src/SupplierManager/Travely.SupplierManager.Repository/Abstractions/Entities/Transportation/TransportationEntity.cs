using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Transportation;

namespace Travely.SupplierManager.Repository.Entities
{
    public class TransportationEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public TransportationType Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public LocationEntity Location { get; set; }
        public TmRegion TmRegion { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [MaxLength(50)]
        public ICollection<DriverEntity> Drivers { get; set; }
        public ICollection<CarEntity> Cars { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [MaxLength(5)]
        public ICollection<AttachmentEntity> Attachments { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(50)]
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}