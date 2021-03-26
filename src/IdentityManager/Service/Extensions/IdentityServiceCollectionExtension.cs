﻿using IdentityManager.DataService.Configs;
using IdentityManager.DataService.IdentityServices;
using IdentityManager.Service.Abstractions;
using IdentityManager.Service.Services;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.DataService.Extensions
{
    public static class IdentityServiceCollectionExtension
    {
        public static void AddTravelyIdentityService(this IServiceCollection services)
        {
            services.AddScoped<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                   .AddScoped<IProfileService, ProfileService>();
            //.AddScoped<IExtensionGrantValidator, DelegationGrantValidator>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                                                //.AddSigningCredential()
                                                .AddPersistedGrantStore<PersistedGrantStore>()
                .AddInMemoryApiResources(AuthConfigs.GetApiResources())
                .AddInMemoryClients(AuthConfigs.GetClients())
                .AddInMemoryApiScopes(AuthConfigs.GetScopes())
                ;

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy.RequireClaim("Admin"));
            })
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddLocalApi(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.ExpectedScope = null;
                    
                });

            services.AddScoped<IEmailTokenService, EmailTokenService>();
            
        }
    }
}
