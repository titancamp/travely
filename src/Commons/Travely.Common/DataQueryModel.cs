using System.Collections.Generic;

namespace Travely.Common
{
    public class DataQueryModel
    {
        public ICollection<FilteringModel> Filters { get; set; }
        public ICollection<OrderingModel> Orderings { get; set; }
        public PagingModel Paging { get; set; }
    }

    public class FilteringModel
    {
        public string FieldName { get; set; }

        public string Value { get; set; }

        public FilteringOperationType Type { get; set; }
    }

    public class OrderingModel
    {
        public string FieldName { get; set; }
        public bool IsDescending { get; set; }
    }

    public class PagingModel
    {
        public int From { get; set; }

        public int Count { get; set; }
    }

    public enum FilteringOperationType
    {
        Equals = 1,
        Contains = 2,
        LessThanOrEqual = 3,
        GreaterThanOrEqual = 4
    }
}
