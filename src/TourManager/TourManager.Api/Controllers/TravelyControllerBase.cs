using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travely.IdentityClient.Authorization.Data;

namespace TourManager.Api.Controllers
{
    [ApiController]
    public class TravelyControllerBase : ControllerBase
    {
        private UserInfo _userInfo;
        public UserInfo UserInfo
        {
            get
            {
                if (_userInfo == null)
                    _userInfo = HttpContext.GetTravelyUserInfo();

                return _userInfo;
            }
        }
    }
}