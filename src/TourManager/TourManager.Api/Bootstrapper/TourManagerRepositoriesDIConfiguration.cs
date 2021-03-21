using Microsoft.Extensions.DependencyInjection;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.MsSql.Repositories;

namespace TourManager.Api.Bootstrapper
{
    public static class TourManagerRepositoriesDIConfiguration
    {
        public static IServiceCollection AddTourManagerRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            return services;
        }
    }
}