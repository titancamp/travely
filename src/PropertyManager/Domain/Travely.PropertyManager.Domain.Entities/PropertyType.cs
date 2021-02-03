using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.PropertyManager.Domain.Entities
{
    public class PropertyType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Property> Properties { get; set; }
    }
}
