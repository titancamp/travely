using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.SchedulerManager.Job;
using Travely.SchedulerManager.Notifier;
using Travely.SchedulerManager.Repository;

namespace Travely.SchedulerManager.API
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
            services.ConfigureEmailing(Configuration.GetSection("Messaging:Email"));
            services.AddNotifier();
            services.AddGrpc();

            services.AddJobService(Configuration);
            services.AddRepositoryLayer(Configuration.GetConnectionString("DefaultConnection"));
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
            app.UseJobClient();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGet("/", async context => await context.Response.WriteAsync("Service running"));
            });

            //xx.StartJobAsync(new InformationJob(), new InformationJobParameter { TourName = "Enqueue Job" }).GetAwaiter().GetResult();
            //yy.StartJobAsync(new InformationJob(), TimeSpan.FromSeconds(5), new InformationJobParameter { TourName = "Scheduled Job" }).GetAwaiter().GetResult();
            //zz.StartJobAsync(new InformationJob(), "Recurrent Job", "* * * * *", new InformationJobParameter { TourName = "Recurrent Job" });

        }
    }
}
