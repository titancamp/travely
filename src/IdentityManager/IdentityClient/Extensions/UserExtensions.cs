using System.Linq;
using Microsoft.AspNetCore.Http;
using Travely.Common.Entities;
using Travely.IdentityClient.Authorization.Data;
using Travely.IdentityClient.Common;
using Travely.IdentityClient.Extensions;

namespace Travely.IdentityClient.Extensions
{
    public static class TravelyIdentityHttpContextExtensions
    {
        public static UserContextModel GetUserContext(this HttpContext context)
        {
            var claims = context?.User?.Claims;
            UserContextModel userContext = null;
            
            if (claims != null)
            {
                userContext = new UserContextModel();
                userContext.UserId = int.Parse(claims.First(p => p.Type == "sub").Value);
                userContext.AgencyId = int.Parse(claims.First(p => p.Type == "AgencyId").Value);
                userContext.Permissions = (Permission) int.Parse(claims.First(p => p.Type == "permissions").Value);
            }
            return userContext;
        }
        public static UserInfo GetTravelyUserInfo(this HttpContext httpContext)
        {
            return new UserInfo
            {
                AgancyId = 1,
                EmployeeId = 1,
                UserId = 1,
                Email = "torq@travely.com",
                Name = "Torq Angegh"
            };
            //UserInfo userInfo = new UserInfo();
            //foreach(var prop in userInfo.GetType().GetProperties())
            //{
            //    prop.SetValue(userInfo, httpContext.User.Claims.FirstOrDefault(claim => claim.Type == prop.Name)?.Value);
            //}

            //return userInfo;
        }
    }
}

namespace Grpc.Core
{
    public static class TravelyIdentityServerCallContextExtensions
    {
        public static UserInfo GetTravelyUserInfo(this ServerCallContext context) => context.GetHttpContext().GetTravelyUserInfo();
    }
}
