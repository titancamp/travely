using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.Common.Extensions;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;
using Travely.PropertyManager.API.Helpers;
using Travely.PropertyManager.API.Interceptors;
using Travely.PropertyManager.API.Services;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Grpc;
using Travely.PropertyManager.Grpc.Client.Abstraction;
using Travely.PropertyManager.Grpc.Client.Implementation;
using Travely.PropertyManager.Grpc.Models;
using Travely.PropertyManager.Grpc.Settings;

namespace Travely.PropertyManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<AddEditPropertyRequestModelValidator>());

            ConfigureServicesCore(services);
            services.ConfigureAutoMapper();

            services.AddGrpc(options =>
            {
                options.Interceptors.Add<ErrorHandlingInterceptor>();
            });

            services.AddScoped<IPropertyManagerClient, PropertyManagerClient>();
            services.Configure<GrpcSettings<Property.PropertyClient>>(Configuration.GetSection("PropertyGrpcService"));
            services.AddScoped<IServiceSettingsProvider<Property.PropertyClient>, PropertyManagerSettingsProvider>();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddConsul(Configuration, Environment);
            services.AddSwagger("PropertyManager API");
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ApplyDatabaseMigrations<PropertyDbContext>();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // UseSwaggerUI needs only when running microservice without gateway
                //app.UseSwaggerUI("PropertyManager API");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<PropertyService>();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Property Manager gRPC service is up.");
                //});
            });
        }

        private void ConfigureServicesCore(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration.GetConnectionString("PropertyDbConnection"));

            services.RegisterServices();
        }
    }
}
