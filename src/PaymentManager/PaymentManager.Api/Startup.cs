using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentManager.Extensions.DependencyInjection;
using PaymentManager.Repositories;
using PaymentManager.Repositories.DbContexts;
using PaymentManager.Services;
using PaymentManager.Services.Models;
using Travely.Common.ServiceDiscovery;
using Travely.Shared.IdentityClient.Authorization.Config;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services.Helpers;
using Travely.Common.Extensions;
using PaymentManager.Api.Services;
using Travely.Common.Grpc;
using Travely.PaymentManager.Grpc;

namespace PaymentManager.Api
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
            services.AddSqlServer<PaymentDbContext>(Configuration.GetConnectionString("PaymentDbContext"),
                "PaymentManager.Repositories");
            services.AddPaymentServices();
            services.AddPaymentGrpcServices(Configuration);
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentManager.Api", Version = "v1" });
            });
            services.AddConsul(Configuration, Environment);
            services.AddTravelyAuthentication(Configuration, Environment);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<PaymentDbContext>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentManager.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
                
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<PayableGrpcService>();
                endpoints.MapGrpcService<PayableGrpcService>();
            });
        }
    }
}
