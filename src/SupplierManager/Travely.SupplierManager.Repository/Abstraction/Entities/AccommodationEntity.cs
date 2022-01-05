using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AccommodationEntity : IEntity
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public LocationEntity Location { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPerson { get; set; }
        public bool AllInclusive { get; set; }
        public ICollection<RoomEntity> Rooms { get; set; }
        public ICollection<AccommodationServiceEntity> Services { get; set; }
        public ICollection<AttachmentEntity> Attachments { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}
