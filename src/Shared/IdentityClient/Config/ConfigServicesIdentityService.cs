using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Security.Claims;

namespace Travely.Shared.IdentityClient.Authorization.Config
{
    public static class ConfigServicesIdentityService
    {
        public static IServiceCollection AddTravelyAuthentication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string authority = configuration.GetSection("TravelyIdentityConfig").GetValue<string>("Authority");
            string audience = configuration.GetSection("TravelyIdentityConfig").GetValue<string>("Audience");
            if (string.IsNullOrWhiteSpace(authority) || string.IsNullOrWhiteSpace(audience))
            {
                throw new ConfigurationErrorsException("Please check the Authority and Audience values in TravelyIdentityConfig section in configuration file");
            }

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = authority;
                    options.Audience = audience;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        RoleClaimType = ClaimTypes.Role,
                    };

                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                });

            return services;
        }
    };
}
