using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using Travely.ClientManager.Repository;
using Travely.ClientManager.Service.Extensions.ServiceCollectionExtensions;
using Travely.ClientManager.Service.Services;
using Travely.Services.Common.Extensions;

namespace Travely.ClientManager.Service
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();

            services.ConfigureAutoMapper();
            services.AddSqlServer<TouristContext>(_configuration.GetConnectionString("TouristDB"),
                "Travely.ClientManager.Repository");
            services.InstallRepositoryServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<TouristContext>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
			app.UseGRPCExceptionHandler();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ClientService>();
                endpoints.MapGrpcService<PreferenceService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
