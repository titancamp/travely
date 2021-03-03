using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.EntityFramework;

namespace IdentityManager.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = await CreateHostBuilder(args).Build().MigrateDbAsync();
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((ctx, conf) =>
                    {
                        conf.AddJsonFile($"appsettings.local.json", optional: true, reloadOnChange: true);
                    })
                        .UseStartup<Startup>();
                });


    }
}
