using System.Linq;

using Travely.IdentityClient.Authorization.Data;

namespace Microsoft.AspNetCore.Http
{
    public static class UserExtensions
    {
        public static UserInfo GetTravelyUserInfo(this HttpContext httpContext)
        {
            UserInfo userInfo = new UserInfo();
            foreach(var prop in userInfo.GetType().GetProperties())
            {
                prop.SetValue(userInfo, httpContext.User.Claims.FirstOrDefault(claim => claim.Type == prop.Name)?.Value);
            }

            return userInfo;
        }
    }
}
