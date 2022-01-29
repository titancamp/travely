using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travely.ClientManager.Grpc;
using Travely.ClientManager.Grpc.Client.Abstraction;
using Travely.ClientManager.Grpc.Client.Implementation;
using Travely.ClientManager.Grpc.Settings;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.PropertyManager.Grpc;
using Travely.PropertyManager.Grpc.Client.Abstraction;
using Travely.PropertyManager.Grpc.Client.Implementation;
using Travely.PropertyManager.Grpc.Settings;
using Travely.SchedulerManager.Grpc;
using Travely.SchedulerManager.Grpc.Client.Abstraction;
using Travely.SchedulerManager.Grpc.Client.Implementation;
using Travely.SchedulerManager.Grpc.Client.Settings;
using Travely.ServiceManager.Grpc;
using Travely.ServiceManager.Grpc.Client.Abstarction;
using Travely.ServiceManager.Grpc.Client.Implementation;
using Travely.ServiceManager.Grpc.Settings;

namespace TourManager.Api.Bootstrapper
{
    public static class TourClientServicesDIConfiguration
    {
        public static IServiceCollection AddTourClientServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            #region ServiceManager

            services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
            services.Configure<GrpcSettings<ActivityProto.ActivityProtoClient>>(
                configuration.GetSection("ActivityGrpcService"));
            services
                .AddScoped<IServiceSettingsProvider<ActivityProto.ActivityProtoClient>,
                    ServiceManagerSettingsProvider>();

            #endregion

            #region ServiceManager

            services.AddScoped<IServiceManagerClient, ServiceManagerClient>();
            services.Configure<GrpcSettings<ActivityProto.ActivityProtoClient>>(
                configuration.GetSection("ServiceGrpcService"));
            services
                .AddScoped<IServiceSettingsProvider<ActivityProto.ActivityProtoClient>,
                    ServiceManagerSettingsProvider>();

            #endregion

            #region EquipmentManager

            #endregion

            #region FileServiceManager

            #endregion

            #region PropertyManager

            services.AddScoped<IPropertyManagerClient, PropertyManagerClient>();
            services.Configure<GrpcSettings<Property.PropertyClient>>(configuration.GetSection("PropertyGrpcService"));
            services.AddScoped<IServiceSettingsProvider<Property.PropertyClient>, PropertyManagerSettingsProvider>();

            #endregion

            #region SchedulerManager

            services.AddScoped<IReminderServiceClient, ReminderServiceClient>();
            services.Configure<GrpcSettings<Reminder.ReminderClient>>(configuration.GetSection("SchedulerGrpcService"));
            services.AddScoped<IServiceSettingsProvider<Reminder.ReminderClient>, SchedulerManagerSettingsProvider>();

            #endregion

            #region ClientManager

            services.AddScoped<IClientManagerServiceClient, ClientManagerServiceClient>();
            services.Configure<GrpcSettings<ClientProtoService.ClientProtoServiceClient>>(
                configuration.GetSection("ClientGrpcService"));
            services
                .AddScoped<IServiceSettingsProvider<ClientProtoService.ClientProtoServiceClient>,
                    ClientManagerSettingsProvider>();

            #endregion

            return services;
        }
    }
}