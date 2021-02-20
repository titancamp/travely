using IdentityManager.DataService.Configs;
using IdentityManager.DataService.IdentityServices;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository;
using Travely.IdentityManager.Repository.Abstractions;

namespace IdentityManager.DataService.Extensions
{
    public static class IdentityServiceCollectionExtension
    {
        public static void AddTravelyIdentityService(this IServiceCollection services)
        {
            services.AddScoped<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                   .AddScoped<IProfileService, ProfileService>();
        }

        

        public static void InitialConfigIdentityServices(this IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()//  AddSigningCredential()
                .AddInMemoryApiResources(AuthConfigs.GetApiResources())
                .AddInMemoryClients(AuthConfigs.GetClients())
                .AddInMemoryApiScopes(AuthConfigs.GetScopes());
        }

    }
}
