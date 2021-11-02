using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travely.IdentityClient.Authorization.Data;

namespace TourManager.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TravelyControllerBase : ControllerBase
    {
        private UserInfo _userInfo;

        protected UserInfo UserInfo => _userInfo ??= HttpContext.GetTravelyUserInfo();
    }
}