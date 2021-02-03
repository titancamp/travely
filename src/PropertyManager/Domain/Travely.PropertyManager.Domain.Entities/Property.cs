﻿namespace Travely.PropertyManager.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual PropertyType Type { get; set; }
        public int TypeId { get; set; }


    }
}
