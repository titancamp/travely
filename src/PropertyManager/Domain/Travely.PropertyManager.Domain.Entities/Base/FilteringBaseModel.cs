﻿namespace Travely.PropertyManager.Domain.Entities.Base
{
    public class FilteringBaseModel
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
        public FilteringOperationType Type { get; set; }
    }


    public enum FilteringOperationType
    {
        Equals = 1,
        Contains = 2
    }
}