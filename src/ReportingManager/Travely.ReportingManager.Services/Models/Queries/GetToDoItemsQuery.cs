using System.Collections.Generic;
using Travely.ReportingManager.Services.Models.Base;

namespace Travely.ReportingManager.Services.Models.Queries
{
    public class GetToDoItemsQuery
    {
        public ICollection<FilteringBaseModel> Filters { get; set; }
        public ICollection<OrderingBaseModel> Orderings { get; set; }
    }
}
