﻿using System.Security.Claims;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using Travely.IdentityClient.Authorization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServicesIdentityService
    {
        public static IServiceCollection IdentityApplicationBuilderExtensions(this IServiceCollection services, IHostEnvironment environment)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(UserTypes.User, policy => policy.RequireAssertion(context => 
                        context.User.HasClaim(userClaim => userClaim.Type == ClaimTypes.Role && userClaim.Value == "User")));
                    options.AddPolicy(UserTypes.Admin, policy => policy.RequireAssertion(context =>
                        context.User.HasClaim(userClaim => userClaim.Type == ClaimTypes.Role && userClaim.Value == "Admin")));
                })
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.Audience = "resourceOwner";
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
