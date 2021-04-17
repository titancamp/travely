using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using TourManager.Api.Utils;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Clients.Abstraction.SchedulerManager;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.PropertyManager;
using TourManager.Clients.Implementation.SchedulerManager;
using TourManager.Clients.Implementation.ServiceManager;
using TourManager.Clients.Implementation.Settings;
using TourManager.Common.Settings;
using TourManager.Service.Abstraction;
using TourManager.Service.Implementation;
using TourManager.Service.Model;
using Travely.Services.Common.Extensions;

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
            services.Configure<ApiBehaviorOptions>(opt => opt.InvalidModelStateResponseFactory =
                context => new BadRequestObjectResult(context.ModelState.GetFirstErrorResponse()));
            services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
            services.AddScoped<IServiceSettingsProvider, ServiceSettingsProvider>();
            services.AddScoped<IPropertyManagerClient, PropertyManagerClient>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IReminderServiceClient, ReminderServiceClient>();
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
            app.ApplyDatabaseMigrations();

            if (env.IsDevelopment())
            {
                app.UseSwaggerDevUI();
            }

            app.UseWebApiExceptionHandler();

            app.UseCors(conf => conf.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .SetIsOriginAllowed(_ => true));
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