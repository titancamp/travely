using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Implementation.ServiceManager;
using TourManager.Common.Settings;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Settings;
using TourManager.Api.Bootstrapper;
using TourManager.Service.Model;

namespace TourManager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

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

            services.Configure<GrpcServiceSettings>(Configuration.GetSection("GrpcServiceSettings"));

            services
                .AddSqlServer(Configuration)
                .AddAutoMapper(typeof(Startup))
                .AddSwagger()
                .AddTourManagerServices()
                .AddTourManagerRepositories()
                .AddTourClientServices()
                .AddTravelyAuthentication(Configuration, Environment);
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

            app.ConfigureTravelyAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}