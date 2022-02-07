using Microsoft.AspNetCore.Builder;
using Travely.IdentityClient.Authorization;

namespace Travely.IdentityClient.Config
{
    public static class ConfigIdentityService
    {
        public static IApplicationBuilder UseTravelyAuthorization(this IApplicationBuilder builder)
        {
            builder.UseAuthorization();
            return builder.UseMiddleware<TravelyAuthorizationMiddleware>();
        }
    };
}
