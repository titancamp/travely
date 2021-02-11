namespace Travely.PropertyManager.Domain.Entities.Base
{
    public class FilteringBaseModel
    {
        public string FieldName { get; set; }
        public FilterOperationType Type { get; set; }
    }
}
