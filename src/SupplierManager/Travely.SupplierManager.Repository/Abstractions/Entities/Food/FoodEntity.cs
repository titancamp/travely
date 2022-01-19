using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TourEntities.Service.Common.Location;

namespace Travely.SupplierManager.Repository.Entities
{
    public class FoodEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public FoodTypeEntity Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public LocationEntity Location { get; set; }
        public TmRegion TmRegion { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        public bool WorkingDays { get; set; }
        public TimeSpan OpeningHoursWd { get; set; }
        public TimeSpan ClosingHoursWd { get; set; }
        public bool Weekends { get; set; }
        public TimeSpan OpeningHoursW { get; set; }
        public TimeSpan ClosingHoursW { get; set; }
        [Column(TypeName = "decimal(20,2)")]
        public decimal Cost { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [StringLength(50)]
        public string ContactPerson { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        public MenuEntity Menu { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [MaxLength(10)]
        public ICollection<AttachmentEntity> Attachments { get; set; }
    }
}