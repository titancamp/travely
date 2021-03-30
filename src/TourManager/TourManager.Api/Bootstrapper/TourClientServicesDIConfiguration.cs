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
			#region ServiceManager

			services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
			services.AddScoped<IServiceSettingsProvider, ServiceSettingsProvider>();

			#endregion

			#region ClientManager

			#endregion

			#region EquipmentManager

			#endregion

			#region FileServiceManager

			#endregion

			#region PropertyManager

			#endregion

			#region SchedulerManager

			#endregion

			#region ClientManager

			services.AddScoped<IClientManagerServiceClient, ClientManagerServiceClient>();

			#endregion

			return services;
		}
	}
}