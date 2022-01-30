using Microsoft.AspNetCore.Builder;

namespace Travely.Shared.IdentityClient.Authorization.Config
{
    public static class ConfigIdentityService
    {
        public static IApplicationBuilder ConfigureTravelyAuthentication(this IApplicationBuilder app)
        {
            app
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }
    };
}
