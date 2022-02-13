using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.SchedulerManager.API.Helpers;
using Travely.SchedulerManager.API.Services;
using Travely.SchedulerManager.Job;
using Travely.SchedulerManager.Notifier.Helpers;
using Travely.SchedulerManager.Repository;
using Travely.SchedulerManager.Service.Extensions;
using Serilog;
using Travely.Common.Extensions;
using Travely.Shared.IdentityClient.Authorization.Config;

namespace Travely.SchedulerManager.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins("http://localhost:3000", "https://travely.am");
                    });
            });

            services.Configure<NotifierOptions>(_configuration.GetSection(NotifierOptions.Section));
            services.Configure<JobOptions>(_configuration.GetSection(JobOptions.Section));
            services.Configure<RepositoryOptions>(_configuration.GetSection(RepositoryOptions.Section));

            services.AddGrpc();
            services.AddJobService(_configuration);
            services.AddRepositoryLayer(_configuration);
            services.AddNotifier(_configuration);
            services.AddBusinessServices();
            services.AddTravelyAuthentication(_configuration, _environment);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<SchedulerDbContext>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseCors();
            app.ConfigureTravelyAuthentication();
            app.ConfigureRepositoryLayer(env.IsDevelopment());
            app.UseJobClient();
            app.UseNotifier();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ReminderService>();
                endpoints.MapGrpcService<EmailService>();
                endpoints.MapGet("/", async context => await context.Response.WriteAsync("Service running"));
            });
        }
    }
}