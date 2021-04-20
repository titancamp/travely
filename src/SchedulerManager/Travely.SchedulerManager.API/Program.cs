using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.API
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            return CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => 
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) => {
                        config.AddJsonFile("appsettings.local.json", optional: true);
                    });
                    webBuilder.UseStartup<Startup>(); 
                });
    }
}
