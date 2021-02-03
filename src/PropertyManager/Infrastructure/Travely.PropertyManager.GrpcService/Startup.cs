using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.PropertyManager.Bootstrapper.Helpers;
using Travely.PropertyManager.GrpcService.MappingProfiles;

namespace Travely.PropertyManager.GrpcService
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

            ConfigureLocalAutoMapper(services);
            services.ConfigureAutoMapper();

            services.AddGrpc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<PropertyService>();
                endpoints.MapGrpcService<PropertyTypeService>();

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
        private void ConfigureLocalAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PropertyMappingProfile));
            services.AddAutoMapper(typeof(PropertyTypeMappingProfile));
        }
    }
}
