using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Travely.SchedulerManager.Repository;

namespace Travely.SchedulerManager.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await (await CreateHostBuilder(args).Build().SeedData()).RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
