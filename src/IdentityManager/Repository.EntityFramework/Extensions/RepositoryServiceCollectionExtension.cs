using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.EntityFramework;

namespace Travely.IdentityManager.Repository.Extensions
{
    public static class RepositoryServiceCollectionExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityServerDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("IdentityServerDB")));
        }

        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
