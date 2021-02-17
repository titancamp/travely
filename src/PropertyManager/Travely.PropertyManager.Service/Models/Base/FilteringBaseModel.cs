namespace Travely.PropertyManager.Service.Models.Base
{
    public class FilteringBaseModel
    {
        public string FieldName { get; set; }

        public string Value { get; set; }

        public FilteringOperationType Type { get; set; }
    }
}
