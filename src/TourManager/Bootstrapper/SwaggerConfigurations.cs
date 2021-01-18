using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Travely.TourManager.Bootstrapper
{
    public static class SwaggerConfigurations
    {
        public static IServiceCollection AddTravelySwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travely.TourManager.Api", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder UseTravelySwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travely.TourManager.Api v1"));

            return app;
        }
    }
}