using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travely.Shared.IdentityClient.Authorization.Common;
using Travely.Shared.IdentityClient.Authorization.Extensions;

namespace Travely.Common.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TravelyControllerBase : ControllerBase
    {
        private UserInfo _userInfo;

        protected UserInfo UserInfo => _userInfo ??= HttpContext.GetTravelyUserInfo();
    }
}