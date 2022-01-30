using IdentityManager.DataService.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using IdentityManager.DataService.Extensions;
using TourManager.Api.Bootstrapper;
using Travely.IdentityClient.Config;
using Travely.IdentityManager.Repository.EntityFramework;
using Travely.IdentityManager.Repository.Extensions;
using Travely.IdentityManager.WebApi.Extensions;
using Travely.IdentityClient.Extensions;

namespace Travely.IdentityManager.WebApi
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.ConfigureFilterServices();

            services.ConfigureSqlContext(Configuration);
            services.AddTravelyIdentityService(Environment);
            services.ConfigureAutoMapper();
            services.AddRepositoryServices();

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwagger("IdentityManager.WebApi");

            services.AddConsul(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ApplyDatabaseMigrations<IdentityServerDbContext>();
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                // UseSwaggerUI needs only when running microservice without gateway
                //app.UseSwaggerUI("IdentityManager.WebApi v1");
            }
          
            app.UseRouting();
            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseIdentityServer();
            
            app.UseTravelyAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
