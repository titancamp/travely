using System.Collections.Generic;

namespace Travely.SupplierManager.Service.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public List<LicenseTypeModel> LicenseTypes { get; set; }
        public List<Language> Languages { get; set; }
    }
}