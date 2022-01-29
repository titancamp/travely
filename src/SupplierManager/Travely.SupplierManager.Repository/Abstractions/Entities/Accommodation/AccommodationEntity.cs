using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourEntities.Service.Accommodation;
using TourEntities.Service.Common.Location;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AccommodationEntity : IEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public AccommodationType Type { get; set; }
        public string Name { get; set; }
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public LocationEntity Location { get; set; }
        public TmRegion TmRegion { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public ICollection<AccommodationServiceEntity> Services { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public ICollection<RoomEntity> Rooms { get; set; }
        public string ContactPerson { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<AttachmentEntity<AccommodationEntity>> Attachments { get; set; }
        public bool AllInclusive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastEditedBy { get; set; }
        public DateTime LastEditedAt { get; set; }
        public AccommodationStatus Status { get; set; }
    }
}