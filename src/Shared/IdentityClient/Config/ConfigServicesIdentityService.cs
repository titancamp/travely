
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, )
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("admin", policy => policy.RequireClaim("Admin"));
                })
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5123";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuerSigningKey = true,
                        //ValidateAudience = true,
                        //ValidateIssuer = true,
                        RoleClaimType = "role",
                        NameClaimType = "sub",
                    };
#if RELEASE
                    options.RequireHttpsMetadata = true;
#endif
                    options.SaveToken = true;
                });

            return services;
        }
    };
}
