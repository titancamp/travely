using System.Collections.Generic;
using Travely.PropertyManager.Domain.Entities.Base;

namespace Travely.PropertyManager.Domain.Models.Queries
{
    public class GetPropertiesQuery
    {
        public ICollection<FilteringBaseModel> Filters { get; set; }
        public ICollection<OrderingBaseModel> Orderings { get; set; }
    }

}
