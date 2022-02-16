using Microsoft.Extensions.DependencyInjection;
using Travely.TourManager.BLL;

namespace Travely.TourManager.Core.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTourServices(this IServiceCollection services)
        {
            services.AddScoped<ITourTypeService, TourTypeService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<ITourStatusService, TourStatusService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IGenderService, GenderService>();
            return services;
        }
    }
}
