using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TourManager.Repository.EfCore.Context;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Implementation.ServiceManager;
using TourManager.Common.Settings;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Settings;

using System.Reflection;
using TourManager.Api.Bootstrapper;
using TourManager.Service.Model;

namespace TourManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors()
                .AddControllers()
                .AddFluentValidation(opt => opt.RegisterValidatorsFromAssembly(typeof(TourValidator).Assembly));

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TourManager.Api", Version = "v1" });
            });

            services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
            services.AddScoped<IServiceSettingsProvider, ServiceSettingsProvider>();
            services.Configure<GrpcServiceSettings>(Configuration.GetSection("GrpcServiceSettings"));


            services
                .AddSqlServer(Configuration)
                .AddAutoMapper(typeof(Startup))
                .AddSwagger()
                .AddTourManagerServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDevUI();
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