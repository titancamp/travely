using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.API
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
            return CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .UseSerilog((hostingContext, loggerConfiguration) =>
                {
                    IConfiguration configuration = hostingContext.Configuration;
                    loggerConfiguration.ReadFrom.Configuration(configuration)
                    .WriteTo.Console()
                    .WriteTo.MSSqlServer(
                        connectionString: configuration["SeriLog:ConnectionString"],
                        sinkOptions: new MSSqlServerSinkOptions
                        {
                            TableName = configuration["SeriLog:LogTable"],
                            AutoCreateSqlTable = true
                        });
                });
    }
}
