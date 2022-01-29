using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.Common.Extensions;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;
using Travely.ServiceManager.Abstraction.Interfaces.UnitOfWorks;
using Travely.ServiceManager.DAL;
using Travely.ServiceManager.DAL.UnitOfWorks;
using Travely.ServiceManager.Grpc;
using Travely.ServiceManager.Grpc.Client.Abstarction;
using Travely.ServiceManager.Grpc.Client.Implementation;
using Travely.ServiceManager.Grpc.Settings;
using Travely.ServiceManager.Service.Managers;
using Travely.ServiceManager.Service.Mappers;

namespace Travely.ServiceManager.Service
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

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContextPool<ServiceManagerDbContext>(options =>
                options.UseServiceManagerDatabaseServer(Configuration));

            services.AddGrpc();
            services.AddAutoMapper(typeof(ActivityProfile));
            services.AddScoped<IActivityManager, ActivityManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
            services.Configure<GrpcSettings<ActivityProto.ActivityProtoClient>>(Configuration.GetSection("ActivityGrpcService"));
            services.AddScoped<IServiceSettingsProvider<ActivityProto.ActivityProtoClient>, ServiceManagerSettingsProvider>();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddSwagger("ServiceManager API");

            services.AddConsul(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ApplyDatabaseMigrations<ServiceManagerDbContext>();
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // UseSwaggerUI needs only when running microservice without gateway
                //app.UseSwaggerUI("ServiceManager API");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<ActivityService>();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                //});
            });
        }
    }
}
