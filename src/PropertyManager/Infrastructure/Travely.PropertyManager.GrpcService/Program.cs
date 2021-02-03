using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Services;

namespace Travely.PropertyManager.GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            Test(host);

            host.Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        
        public static void Test(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var propertyService = scope.ServiceProvider.GetRequiredService<IPropertyTypeService>();

                var command = new AddPropertyTypeCommand
                {
                    Name = "Hotel"
                };
                propertyService.AddAsync(command).Wait();
            }
        }
        
    }
}
