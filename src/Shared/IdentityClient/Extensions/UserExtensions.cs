﻿using System;
using System.ComponentModel;
using System.Linq;
using Travely.IdentityClient.Authorization;
using Travely.IdentityClient.Authorization.Data;

namespace Microsoft.AspNetCore.Http
{
    public static class UserExtensions
    {
        public static UserInfo GetTravelyUserInfo(this HttpContext httpContext)
        {
            var claims = httpContext.User.Claims;

            UserInfo userInfo = new UserInfo() {
                UserId = Convert.ToInt32(claims.FirstOrDefault(claim => claim.Type == TravelyClaims.UserId)?.Value),
                AgencyId = Convert.ToInt32(claims.FirstOrDefault(claim => claim.Type == TravelyClaims.AgencyId)?.Value),
                EmployeeId = Convert.ToInt32(claims.FirstOrDefault(claim => claim.Type == TravelyClaims.EmployeeId)?.Value),
                Role = claims.FirstOrDefault(claim => claim.Type == TravelyClaims.Role)?.Value,
                Name = claims.FirstOrDefault(claim => claim.Type == TravelyClaims.Name)?.Value,
                Email = claims.FirstOrDefault(claim => claim.Type == TravelyClaims.Email)?.Value,
            };

            return userInfo;
        }
    }
}
