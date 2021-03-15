using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travely.PropertyManager.Data.EntityFramework;

namespace Travely.PropertyManager.API.Helpers
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyDatabaseMigrations(this IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<PropertyDbContext>();

            context.Database.Migrate();

            return applicationBuilder;
        }
    }
}
