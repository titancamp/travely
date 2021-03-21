using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.EntityFramework;

namespace Travely.IdentityManager.WebApi
{
    public static class HostExtension
    {
        public static async Task<IHost> MigrateDbAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<IdentityServerDbContext>()
             .Database.MigrateAsync();

            return host;
        }
    }
}
