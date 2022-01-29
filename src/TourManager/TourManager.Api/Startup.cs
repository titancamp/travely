using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using TourManager.Api.Helpers;
using TourManager.Api.Utils;
using TourManager.Repository.EfCore.Context;
using TourManager.Service.Model;
using Travely.ClientManager.Grpc.Validators;
using Travely.Common.Api.Extensions;
using Travely.Common.Extensions;
using Travely.Common.ServiceDiscovery;
using Travely.Common.Swagger;
using Travely.Shared.IdentityClient.Authorization.Config;

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
                .AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanConverter()))
                .AddFluentValidation(opt =>
                { 
                    opt.RegisterValidatorsFromAssemblyContaining<TourValidator>();
                    opt.RegisterValidatorsFromAssemblyContaining<ClientValidator>();
                });
            
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(new[]
                    {
                        "http://localhost:3000"
                    });
                });
            });

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
            //Shows Only the first error message
            services.Configure<ApiBehaviorOptions>(opt => opt.InvalidModelStateResponseFactory =
                context => new BadRequestObjectResult(context.ModelState.GetFirstErrorResponse()));

            services.AddConsul(Configuration, Environment);

            services
                .AddSqlServer<TourDbContext>(Configuration.GetConnectionString("TourDbContext"), "TourManager.Repository.EfCore.MsSql" )
                .AddSwagger("TourManager API")
                .AddTourManagerServices()
                .AddTourManagerRepositories()
                .AddTourClientServices(Configuration)
                .AddTravelyAuthentication(Configuration, Environment);

            services.ConfigureAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ApplyDatabaseMigrations<TourDbContext>();

            if (Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI("TourManager API");
            }

            app.UseWebApiExceptionHandler();

            app.UseCors(conf => conf.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .SetIsOriginAllowed(_ => true));
            
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.ConfigureTravelyAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}