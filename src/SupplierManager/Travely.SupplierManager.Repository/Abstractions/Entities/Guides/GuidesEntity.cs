using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TourEntities.Service.Common.Location;
using TourEntities.Service.Guide;

namespace Travely.SupplierManager.Repository.Entities
{
    public class GuidesEntity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int AgencyId { get; set; }
        [Required]
        public GuideType Type { get; set; }
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
        [Column(TypeName = "decimal(20,2)")]
        public decimal Cost { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        public ICollection<GuideEntity> Guide { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public ICollection<AttachmentEntity<GuidesEntity>> Attachments { get; set; }
    }
}