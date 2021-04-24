using Microsoft.Extensions.DependencyInjection;
using TourManager.Clients.Abstraction.ClientManager;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Clients.Abstraction.SchedulerManager;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.ClientManager;
using TourManager.Clients.Implementation.PropertyManager;
using TourManager.Clients.Implementation.SchedulerManager;
using TourManager.Clients.Implementation.ServiceManager;
using TourManager.Clients.Implementation.Settings;

namespace TourManager.Api.Bootstrapper
{
    public static class TourClientServicesDIConfiguration
    {
        public static IServiceCollection AddTourClientServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceSettingsProvider, ServiceSettingsProvider>();
            services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
            services.AddScoped<IPropertyManagerClient, PropertyManagerClient>();
            services.AddScoped<IReminderServiceClient, ReminderServiceClient>();
            services.AddScoped<IClientManagerServiceClient, ClientManagerServiceClient>();

            return services;
        }
    }
}