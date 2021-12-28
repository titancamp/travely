using Microsoft.Extensions.Options;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;

namespace Travely.SchedulerManager.Grpc.Client.Settings
{
    public class SchedulerManagerSettingsProvider : IServiceSettingsProvider<Reminder.ReminderClient>
    {

        public SchedulerManagerSettingsProvider(IOptions<GrpcSettings<Reminder.ReminderClient>> settings)
        {
            Settings = settings.Value;
        }

        public GrpcSettings<Reminder.ReminderClient> Settings { get; }
    }
}
