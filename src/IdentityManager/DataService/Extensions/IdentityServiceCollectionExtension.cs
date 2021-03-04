using IdentityManager.DataService.Configs;
using IdentityManager.DataService.IdentityServices;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        
    }
}
