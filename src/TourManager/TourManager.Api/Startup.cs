using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TourManager.Api.Bootstrapper;
using TourManager.Api.Utils;
using TourManager.Common.Settings;
using TourManager.Repository.EfCore.Context;
using Travely.Services.Common.Extensions;
using TourManager.Service.Model.TourManager;


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
                .AddFluentValidation(opt => opt.RegisterValidatorsFromAssembly(typeof(AddEditTourRequestModelValidator).Assembly));

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
            services.Configure<ApiBehaviorOptions>(opt => opt.InvalidModelStateResponseFactory =
                context => new BadRequestObjectResult(context.ModelState.GetFirstErrorResponse()));

            services.Configure<GrpcServiceSettings>(Configuration.GetSection("GrpcServiceSettings"));

            services
                .AddSqlServer<TourDbContext>(Configuration.GetConnectionString("TourDbContext"), "TourManager.Repository.EfCore.MsSql")
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
            //app.ApplyDatabaseMigrations<TourDbContext>();

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