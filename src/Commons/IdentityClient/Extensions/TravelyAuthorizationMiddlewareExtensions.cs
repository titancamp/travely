using Microsoft.AspNetCore.Builder;
using Travely.IdentityClient.Authorization;

namespace Travely.IdentityClient.Extensions
{
    public static class TravelyAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTravelyAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TravelyAuthorizationMiddleware>();
        }
    }
}
