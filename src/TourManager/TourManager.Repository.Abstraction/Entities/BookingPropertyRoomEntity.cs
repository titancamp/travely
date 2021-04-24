using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    public class BookingPropertyRoomEntity
    {
        public int Id { get; set; }

        public int BookingPropertyId { get; set; }

        public int RoomTypeId { get; set; }

        public int RoomCount { get; set; }

        public BookingPropertyEntity BookingProperty { get; set; }

        public ICollection<BookingPropertyRoomGuestEntity> BookingPropertyRoomGuests { get; set; } = new List<BookingPropertyRoomGuestEntity>();
    }
}