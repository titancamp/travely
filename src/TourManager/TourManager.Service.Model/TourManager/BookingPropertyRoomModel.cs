using System.Collections.Generic;

namespace TourManager.Service.Model.TourManager
{
    public class BookingPropertyRoomModel
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int RoomTypeId { get; set; }

        public int RoomCount { get; set; }

        public ICollection<BookingPropertyRoomGuestModel> BookingPropertyRoomGuests { get; set; } = new List<BookingPropertyRoomGuestModel>();
    }
}