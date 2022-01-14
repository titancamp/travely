using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AccommodationEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public AccommodationTypeEntity Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        
        public LocationEntity Location { get; set; }
        public RegionEntity Region { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public ICollection<AccommodationServiceEntity> Services { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }

        [MaxLength(50)]
        public ICollection<RoomEntity> Rooms { get; set; }

        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }

        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<AttachmentEntity> Attachments { get; set; }
        
        public bool AllInclusive { get; set; }
        
        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(50)]
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }

        // “draft”,”ready”,”no price”
        [StringLength(50)]
        public string Status { get; set; }
    }
}