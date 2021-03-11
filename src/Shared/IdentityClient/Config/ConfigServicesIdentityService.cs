using System.Configuration;
using System.Security.Claims;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServicesIdentityService
    {
        public static IServiceCollection AddTravelyAuthentication(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string authority = configuration.GetSection("TravelyIdentityConfig").GetValue<string>("Authority");
            string audience = configuration.GetSection("TravelyIdentityConfig").GetValue<string>("Audience");
            if (string.IsNullOrWhiteSpace(audience)|| string.IsNullOrWhiteSpace(audience))
            {
                throw new ConfigurationErrorsException("Please check the Authority and Audience values in TravelyIdentityConfig section in configuration file");
            }

            services
                .AddAuthentication(options => {
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
                        ValidateIssuer = true,
                        RoleClaimType = ClaimTypes.Role,
                    };

                    if (!environment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = true;
                    }
                    options.SaveToken = true;
                });

            return services;
        }
    };
}
