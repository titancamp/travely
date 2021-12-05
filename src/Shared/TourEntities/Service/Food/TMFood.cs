using System;
using System.Collections.Generic;

namespace TourEntities.Service.Food
{
    public partial class Food
    {
        public Guid Id { get; set; }
        public FoodType Type { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public Accommodation.Location Location { get; set; }
        public ICollection<MenuType> Menu { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEditedAt { get; set; }
    }
}
