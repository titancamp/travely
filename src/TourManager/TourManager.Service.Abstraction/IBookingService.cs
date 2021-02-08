using System.Threading.Tasks;
using TourManager.Service.Model;
using System.Collections.Generic;

namespace TourManager.Service.Abstraction
{
    public interface IBookingService
    {
        public Task<List<Booking>> GetBookings(int tenantId);
        public Task CancelBooking(int bookingId);
        public Task UpdateBooking(Booking booking);
    }
}