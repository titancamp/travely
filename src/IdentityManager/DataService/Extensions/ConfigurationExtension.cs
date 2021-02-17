using IdentityManager.DataService.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Model.Context;

namespace IdentityManager.DataService.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityServerDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("IdentityServerDB")));
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
