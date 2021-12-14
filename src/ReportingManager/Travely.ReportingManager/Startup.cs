using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using Travely.ReportingManager.Data;
using Travely.ReportingManager.Helpers;
using Travely.ReportingManager.Interceptors;
using Travely.ReportingManager.Services;
using Travely.ReportingManager.Services.Abstractions;
using Travely.ReportingManager.Services.Implementations;

namespace Travely.ReportingManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServicesCore(services);
            services.ConfigureAutoMapper();
            services.AddGrpc(options =>
            {
                options.Interceptors.Add<ErrorHandlingInterceptor>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplyDatabaseMigrations<ToDoDbContext>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ToDoService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Reporting Manager gRPC service is up.");
                });
            });
        }

        private void ConfigureServicesCore(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration.GetConnectionString("ReportingDbConnection"));

            services.RegisterServices();
        }
    }
}
