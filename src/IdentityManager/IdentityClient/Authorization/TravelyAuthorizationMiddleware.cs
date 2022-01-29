using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Travely.Common.Entities;

namespace Travely.IdentityClient.Authorization
{
    internal class TravelyAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public TravelyAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            PermissionAttribute? endpointPermissionAttribute = context.GetEndpoint()?.Metadata.GetMetadata<PermissionAttribute>();

            if (endpointPermissionAttribute != null)
            {
                Claim? permissionClaim = context.User?.Claims?.FirstOrDefault(x => x.Type == nameof(Permission));

                if (permissionClaim is null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
            
                Permission userPermission = (Permission)Convert.ToInt32(permissionClaim.Value);;

                if (userPermission != Permission.Admin && (userPermission | endpointPermissionAttribute.Permission) != endpointPermissionAttribute.Permission)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }
            }
            
            await _next(context);
        }
    }
}
