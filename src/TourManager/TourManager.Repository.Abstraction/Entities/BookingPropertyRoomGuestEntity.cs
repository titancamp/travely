namespace TourManager.Repository.Entities
{
    public class BookingPropertyRoomGuestEntity
    {
        public int Id { get; set; }

        public int BookingPropertyRoomId { get; set; }

        public int ClientId { get; set; }

        public BookingPropertyRoomEntity BookingPropertyRoom { get; set; }

        public ClientEntity Client { get; set; }
    }
}