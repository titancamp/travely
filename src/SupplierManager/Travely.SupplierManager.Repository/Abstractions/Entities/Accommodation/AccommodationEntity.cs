using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TourEntities.Service.Accommodation;
using TourEntities.Service.Common.Location;

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
        public AccommodationType Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        
        public LocationEntity Location { get; set; }
        public TmRegion TmRegion { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public ICollection<AccommodationServiceEntity> Services { get; set; }
        
        [Column(TypeName = "decimal(20,2)")]
        public decimal Cost { get; set; }
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
        public ICollection<AttachmentEntity<AccommodationEntity>> Attachments { get; set; }
        
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