using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using Travely.ClientManager.Grpc;
using Travely.ClientManager.Grpc.Client.Abstraction;
using Travely.ClientManager.Grpc.Client.Implementation;
using Travely.ClientManager.Grpc.Settings;
using Travely.ClientManager.Grpc.Validators;
using Travely.ClientManager.Repository;
using Travely.ClientManager.Service.Extensions.ServiceCollectionExtensions;
using Travely.ClientManager.Service.Services;
using Travely.Common.Api.Extensions;
using Travely.Common.Extensions;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;

namespace Travely.ClientManager.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddFluentValidation(opt => opt.RegisterValidatorsFromAssemblyContaining<ClientValidator>());

            services.AddGrpc();

            services.ConfigureAutoMapper();
            services.AddSqlServer<TouristContext>(Configuration.GetConnectionString("TouristDB"),
                "Travely.ClientManager.Repository");
            services.InstallRepositoryServices();

            services.AddScoped<IClientManagerServiceClient, ClientManagerServiceClient>();
            services.Configure<GrpcSettings<ClientProtoService.ClientProtoServiceClient>>(Configuration.GetSection("ClientGrpcService"));
            services.AddScoped<IServiceSettingsProvider<ClientProtoService.ClientProtoServiceClient>, ClientManagerSettingsProvider>();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddSwagger("ClientManager API");

            services.AddConsul(Configuration, Environment);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.ApplyDatabaseMigrations<TouristContext>();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // UseSwaggerUI needs only when running microservice without gateway
                //app.UseSwaggerUI("ClientManager API");
            }

			app.UseGRPCExceptionHandler();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<ClientService>();
                endpoints.MapGrpcService<PreferenceService>();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                //});
            });
        }
    }
}
