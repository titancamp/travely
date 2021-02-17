using IdentityManager.DataService.IdentityServices;
using IdentityServer4.Services;
using IdentityServer4.Validation;
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
    public static class ServiceInstallerExtension
    {
        public static void InstallIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                   .AddScoped<IProfileService, ProfileService>();
        }

        public static void InstallRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
                   
        }

    }
}
