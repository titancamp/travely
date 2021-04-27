using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using Travely.SchedulerManager.API.Helpers;
using Travely.SchedulerManager.API.Services;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Job;
using Travely.SchedulerManager.Notifier.Helpers;
using Travely.SchedulerManager.Repository;
using Travely.SchedulerManager.Service.Extensions;

namespace Travely.SchedulerManager.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
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

            // todo use identity package
            // services.AddAuthentication();

            services.Configure<NotifierOptions>(_configuration.GetSection(NotifierOptions.Section));
            services.Configure<JobOptions>(_configuration.GetSection(JobOptions.Section));
            services.Configure<RepositoryOptions>(_configuration.GetSection(RepositoryOptions.Section));

            services.AddGrpc();
            services.AddJobService(_configuration);
            services.AddRepositoryLayer(_configuration);
            services.AddNotifier(_configuration);
            services.AddBusinessServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<SchedulerDbContext>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseJobClient();
            app.UseNotifier();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ReminderService>();
                endpoints.MapGet("/", async context => await context.Response.WriteAsync("Service running"));
            });
        }
    }
}