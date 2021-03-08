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
            foreach(var propInfo in userInfo.GetType().GetProperties())
            {
                Type typeProp = propInfo.PropertyType;
                var value = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == propInfo.Name)?.Value;
                if (Attribute.IsDefined(propInfo, typeof(DisplayNameAttribute)))
                {
                    DisplayNameAttribute displayName = (DisplayNameAttribute)Attribute.GetCustomAttribute(propInfo, typeof(DisplayNameAttribute));
                    value = httpContext.User.Claims.FirstOrDefault(claim => claim.Type == displayName.DisplayName)?.Value;
                }

                if (typeProp.IsGenericType && typeProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    if (value == null)
                    {
                        propInfo.SetValue(userInfo, null);
                        continue;
                    }

                    typeProp = new NullableConverter(propInfo.PropertyType).UnderlyingType;
                }

                propInfo.SetValue(userInfo, Convert.ChangeType(value, typeProp));
            }

            return userInfo;
        }
    }
}
