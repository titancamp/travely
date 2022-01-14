using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Travely.Common.Extensions;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;
using Travely.Shared.IdentityClient.Authorization.Config;
using Travely.SupplierManager.API.Mappers;
using Travely.SupplierManager.Extensions.DependencyInjection;
using Travely.SupplierManager.Grpc;
using Travely.SupplierManager.Grpc.Client.Abstraction;
using Travely.SupplierManager.Grpc.Client.Implementation;
using Travely.SupplierManager.Grpc.Settings;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Service;
using Travely.SupplierManager.Service.Helpers;
using Travely.SupplierManager.Service.Models;

namespace Travely.SupplierManager.API
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddGrpc();

            services.AddDbContext<SupplierDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SupplierDbContext")));
            
            services.AddSupplierServices();
            services.ConfigureAutoMapper();
            
            services.Configure<GrpcSettings<SupplierProto.SupplierProtoClient>>(
                Configuration.GetSection("SupplierGrpcService"));
            services
                .AddScoped<IServiceSettingsProvider<SupplierProto.SupplierProtoClient>,
                    SupplierManagerSettingsProvider>();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SupplierManager.Api", Version = "v1"});
            });
            
            services.AddConsul(Configuration, Environment);
            services.AddTravelyAuthentication(Configuration, Environment);
            // services.AddSwagger("SupplierManager API");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<SupplierDbContext>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupplierManager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
} 