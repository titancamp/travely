using System.ComponentModel.DataAnnotations;
using TourEntities.Service.Transportation;

namespace Travely.SupplierManager.Repository.Entities
{
    public class LicenseTypeEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public LicenseType LicenseType { get; set; }
        
        public DriverEntity Driver { get; set; }
    }
}