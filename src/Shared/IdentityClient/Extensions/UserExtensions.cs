using System;
using System.ComponentModel;
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
                Type tProp = prop.PropertyType;
                var value = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == prop.Name)?.Value;
                if (tProp.IsGenericType && tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    if (value == null)
                    {
                        prop.SetValue(userInfo, null);
                        continue;
                    }

                    tProp = new NullableConverter(prop.PropertyType).UnderlyingType;
                }

                prop.SetValue(userInfo, Convert.ChangeType(value, tProp));
            }

            return userInfo;
        }
    }
}
