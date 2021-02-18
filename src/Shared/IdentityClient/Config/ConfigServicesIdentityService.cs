
using Microsoft.IdentityModel.Tokens;

using Microsoft.Extensions.DependencyInjection;

namespace Travely.IdentityClient.Authorization
{
    public static class ConfigServicesIdentityService
    {
        //
        // Summary:
        //     Registers services required by authentication services with JWTBearer. 
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Returns:
        //     A Microsoft.Extensions.DependencyInjection.IServiceCollection that can be used
        //     to further configure Service.
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("admin", policy => policy.RequireClaim("Admin"));
                })
                .AddAuthentication(ApplicationInfo.Bearer)
                .AddJwtBearer(ApplicationInfo.Bearer, options =>
                {
                    options.Authority = ApplicationInfo.IdentityServerUrl; //IdentityServerApiUrl

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            return services;
        }
    };
}
