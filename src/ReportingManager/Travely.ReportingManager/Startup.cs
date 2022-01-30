using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.Common.Extensions;
using Travely.Common.Grpc;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;
using Travely.ReportingManager.Data;
using Travely.ReportingManager.Helpers;
using Travely.ReportingManager.Interceptors;
using Travely.ReportingManager.Protos;
using Travely.ReportingManager.Services;
using FluentValidation.AspNetCore;
using Travely.ReportingManager.Grpc.Models;
using Travely.Shared.IdentityClient.Authorization.Config;

namespace Travely.ReportingManager
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
            services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<CreateToDoModelValidator>());

            ConfigureServicesCore(services);
            services.ConfigureAutoMapper();
            services.AddGrpc(options =>
            {
                options.Interceptors.Add<ErrorHandlingInterceptor>();
            });
            services.Configure<GrpcSettings<ToDoItemProtoService.ToDoItemProtoServiceClient>>(Configuration.GetSection("ReportingGrpcService"));
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddConsul(Configuration, Environment);
            services.AddSwagger("ReportingManager API");
            services.AddTravelyAuthentication(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<ToDoDbContext>();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // UseSwaggerUI needs only when running microservice without gateway
                //app.UseSwaggerUI("ReportingManager API");
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<ToDoService>();
            });
        }

        private void ConfigureServicesCore(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration.GetConnectionString("ReportingDbConnection"));

            services.RegisterServices();
        }
    }
}
