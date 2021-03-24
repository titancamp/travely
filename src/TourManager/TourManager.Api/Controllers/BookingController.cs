using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourManager.Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Travely.IdentityClient.Authorization;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
    //[Authorize(Roles = UserRoles.User)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookingController : TravelyControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? tourId, DateTime? cancellationDeadlineFrom)
        {
            var data = await _bookingService.GetBookings(UserInfo.AgencyId, tourId, cancellationDeadlineFrom);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _bookingService.GetBookingById(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }
    }
}