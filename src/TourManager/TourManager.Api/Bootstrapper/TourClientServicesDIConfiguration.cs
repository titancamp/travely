using Microsoft.Extensions.DependencyInjection;
using TourManager.Clients.Abstraction.ClientManager;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.ClientManager;
using TourManager.Clients.Implementation.ServiceManager;
using TourManager.Clients.Implementation.Settings;

namespace TourManager.Api.Bootstrapper
{
    public static class TourClientServicesDIConfiguration
    {
        public static IServiceCollection AddTourClientServices(this IServiceCollection services)
        {
			#region Common

			services.AddScoped<IServiceSettingsProvider, ServiceSettingsProvider>();

			#endregion

			#region ServiceManager

			services.AddScoped<IServiceManagerClient, ServiceManagerClient>();

            #endregion

            #region ClientManager

            services.AddScoped<IClientManagerServiceClient, ClientManagerServiceClient>();

            #endregion

            #region EquipmentManager

            #endregion

            #region FileServiceManager

            #endregion

            #region PropertyManager

            #endregion

            #region SchedulerManager

            #endregion

            return services;
        }
    }
}