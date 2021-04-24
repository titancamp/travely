using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class PropertyEntity
    {
        public int Id { get; set; }

        public int AgencyId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<BookingPropertyEntity> BookingProperties { get; set; } = new List<BookingPropertyEntity>();

        public ICollection<BookingTransportationEntity> BookingTransportations { get; set; } = new List<BookingTransportationEntity>();
    }
}