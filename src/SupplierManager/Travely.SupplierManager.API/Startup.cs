using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Travely.Common.Extensions;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;
using Travely.Shared.IdentityClient.Authorization.Config;
using Travely.SupplierManager.Extensions.DependencyInjection;
using Travely.SupplierManager.Repository.DbContexts;

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

            services.AddSqlServer<SupplierDbContext>(Configuration.GetConnectionString("SupplierDbContext"),
                "Travely.SupplierManager.Repository");
            
            services.AddSupplierServices();
            services.ConfigureAutoMapper();
            
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
            
            services.AddConsul(Configuration, Environment);
            services.AddSwagger("SupplierManager API");
            services.AddTravelyAuthentication(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<SupplierDbContext>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
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