using System.ComponentModel.DataAnnotations;

namespace Travely.SupplierManager.Repository.Entities
{
    public class AttributeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ActivitiesEntity Activities { get; set; }
    }
}