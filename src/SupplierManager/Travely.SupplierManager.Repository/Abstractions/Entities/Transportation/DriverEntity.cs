using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class DriverEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        public ICollection<LicenseTypeEntity> LicenseTypes { get; set; }
        public ICollection<LanguageEntity<DriverEntity>> Languages { get; set; }
        
        public TransportationEntity Transportation { get; set; }
    }
}