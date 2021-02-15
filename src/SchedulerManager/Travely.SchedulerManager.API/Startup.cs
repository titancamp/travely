using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Configuration;
using Travely.SchedulerManager.API.ConfigManager;
using Travely.SchedulerManager.API.Services;
using Travely.SchedulerManager.Notifier;

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
                options.AddPolicy("CORS",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins("http://localhost:3000");
                    });
            });


            services.Configure<ConnectionStrings>(_configuration.GetSection(ConnectionStrings.Section));
            var settings = new ConnectionStrings();
            _configuration.GetSection(ConnectionStrings.Section).Bind(settings);
            //use settings properties to send as a parapeter when adding service

            services.AddNotifier();
            services.AddGrpc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CORS");
            app.UseRouting();

            app.UseNotifier();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ReminderService>();
                endpoints.MapGet("/", async context => await context.Response.WriteAsync("Service running"));
            });
        }
    }
}
