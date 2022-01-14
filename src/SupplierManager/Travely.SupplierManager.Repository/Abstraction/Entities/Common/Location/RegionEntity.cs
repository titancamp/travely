using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class RegionEntity
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
    }
}