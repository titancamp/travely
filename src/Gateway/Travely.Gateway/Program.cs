using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Travely.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration((context, config) => config.AddJsonFile("ocelot.json")
                                                                                    .AddJsonFile("ocelot.SwaggerEndPoints.json")
                                                                                    .AddJsonFile($"ocelot.SwaggerEndPoints.{context.HostingEnvironment.EnvironmentName}.json", , optional: true)
                                                                                    .AddEnvironmentVariables())
                .UseStartup<Startup>());
    }
}
