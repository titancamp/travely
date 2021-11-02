using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using Travely.PropertyManager.API.Helpers;
using Travely.PropertyManager.API.Interceptors;
using Travely.PropertyManager.API.Services;
using Travely.PropertyManager.Bootstrapper.Helpers;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.Services.Common.Extensions;

namespace Travely.PropertyManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServicesCore(services);
            services.ConfigureAutoMapper();

            services.AddGrpc(options =>
            {
                options.Interceptors.Add<ErrorHandlingInterceptor>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<PropertyDbContext>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<PropertyService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Property Manager gRPC service is up.");
                });
            });
        }

        private void ConfigureServicesCore(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration.GetConnectionString("PropertyDbConnection"));

            services.RegisterServices();
        }

    }
}
