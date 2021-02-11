using System.Collections.Generic;
using Travely.PropertyManager.Domain.Entities.Base;

namespace Travely.PropertyManager.Domain.Contracts.Models.Queries
{
    public class GetPropertiesQuery
    {
        public IEnumerable<FilteringBaseModel> Filters { get; set; }
        public IEnumerable<SortingBaseModel> Sortings { get; set; }
    }

}
