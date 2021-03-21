
using IdentityManager.DataService.Configs;
using IdentityManager.DataService.IdentityServices;
using IdentityManager.DataService.Mappers;
using IdentityServer4;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using static IdentityServer4.IdentityServerConstants;

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
        }



    }
}
