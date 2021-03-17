using System.Collections.Generic;
using Travely.PropertyManager.Service.Models.Base;

namespace Travely.PropertyManager.Service.Models.Queries
{
    public class GetPropertiesQuery
    {
        public ICollection<FilteringBaseModel> Filters { get; set; }
        public ICollection<OrderingBaseModel> Orderings { get; set; }
    }

}
