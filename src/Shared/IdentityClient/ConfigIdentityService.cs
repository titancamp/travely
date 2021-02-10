using Microsoft.Extensions.DependencyInjection;

namespace Travely.IdentityManager.IdentityService.Authorization
{
    public static class ConfigIdentityService
    {
        public static IIdentityServerBuilder AddIdentityServerConfiguration(this IServiceCollection services)
        {
            var builder = services.AddIdentityServerBuilder();

            // set up IdentityServer Configuration for project

            return builder;
        }
    };
}
