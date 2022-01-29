using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Travely.IdentityClient.Authorization.Entities;
using Travely.IdentityClient.Extensions;

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
            Claim permissionClaim = context.User?.Claims?.FirstOrDefault(x => x.Type == nameof(Permission));
            //If we can't get permission from claim from frontend, then get it from user details from db
            PermissionAttribute endpointPermissionAttribute = context.GetEndpoint()?.Metadata.GetMetadata<PermissionAttribute>();
            Permission endpointPermission;
            Permission userPermission;

            if (permissionClaim is null)
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }

            if (endpointPermissionAttribute is null)
            {
                await _next(context);
            }

            userPermission = (Permission)Convert.ToInt32(permissionClaim.Value);
            endpointPermission = endpointPermissionAttribute.Permission;

            var notSetPermission = endpointPermission.GetFlags().FirstOrDefault(flag => !userPermission.HasFlag(flag));

            if (notSetPermission != default(Permission))
            {
                throw new UnauthorizedAccessException("Unauthorized");
            }
            
            await _next(context);
        }
    }
}
