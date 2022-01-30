using Microsoft.Extensions.DependencyInjection;
using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.EfCore.MsSql.Repositories;
using TourManager.Repository.Entities;

namespace TourManager.Api.Bootstrapper
{
    public static class TourManagerRepositoriesDIConfiguration
    {
        public static IServiceCollection AddTourManagerRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRepository<TourClientEntity>, BaseRepository<TourDbContext, TourClientEntity>>();

            return services;
        }
    }
}