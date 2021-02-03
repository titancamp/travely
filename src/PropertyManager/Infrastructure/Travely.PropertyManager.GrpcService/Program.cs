using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Travely.PropertyManager.GrpcService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //DebugGrpcClient(host).GetAwaiter().GetResult();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        public static async System.Threading.Tasks.Task DebugGrpcClient(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var propertyTypeService = scope.ServiceProvider.GetRequiredService<Domain.Contracts.Services.IPropertyTypeService>();
                var mapper = scope.ServiceProvider.GetRequiredService<AutoMapper.IMapper>();

                var grpcService = new PropertyTypeService(mapper, propertyTypeService);

                await grpcService.GetPropertyTypes(new Contracts.GetPropertyTypesRequest() { }, null, null);


            }
        }

    }
}
