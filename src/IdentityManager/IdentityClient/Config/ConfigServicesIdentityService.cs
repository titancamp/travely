using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Travely.IdentityClient.Config
{
    public static class ConfigServicesIdentityService
    {
        public static IServiceCollection ConfigureTravelyAuthorization(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            string authority = configuration.GetSection("TravelyIdentityConfig").GetValue<string>("Authority");
            
            if (string.IsNullOrWhiteSpace(authority))
            {
                throw new ConfigurationErrorsException("Please check the Authority and Audience values in TravelyIdentityConfig section in configuration file");
            }
            
            services.AddAuthorization()
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = authority;
                    options.Authority = "api1";
                });

            return services;
        }
    };
}
