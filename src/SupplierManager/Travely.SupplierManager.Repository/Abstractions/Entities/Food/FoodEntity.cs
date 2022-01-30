using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Guide;

namespace Travely.SupplierManager.Repository.Entities
{
    public class FoodEntity : IEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public FoodType Type { get; set; }
        public string Name { get; set; }
        public LocationEntity Location { get; set; }
        public TmRegion TmRegion { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool WorkingDays { get; set; }
        public TimeSpan OpeningHoursWd { get; set; }
        public TimeSpan ClosingHoursWd { get; set; }
        public bool Weekends { get; set; }
        public TimeSpan OpeningHoursW { get; set; }
        public TimeSpan ClosingHoursW { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public string ContactPerson { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public MenuEntity Menu { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<AttachmentEntity<FoodEntity>> Attachments { get; set; }
    }
}