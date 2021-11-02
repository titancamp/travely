using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.SchedulerManager;
using TourManager.Clients.Abstraction.Settings;
using TourManager.Clients.Implementation.Mappers;
using TourManager.Service.Model.SchedulerManager.Reminders;
using Travely.SchedulerManager.API;

namespace TourManager.Clients.Implementation.SchedulerManager
{
    public class ReminderServiceClient : GrpcClientBase<Reminder.ReminderClient>, IReminderServiceClient
    {
        public ReminderServiceClient(IServiceSettingsProvider serviceSettingsProvider)
            : base(serviceSettingsProvider)
        {
        }

        public Task<bool> CreateAsync(CreateUpdateReminderRequest request)
        {
            return HandleAsync(async client =>
            {
                var model = Mapping.Mapper.Map<CreateRequest>(request);

                var result = await client.CreateAsync(model);

                return result.Succeed;
            });
        }

        public Task<bool> DeleteAsync(int bookingId)
        {
            return HandleAsync(async client =>
            {
                var result = await client.DeleteAsync(new DeleteRequest { BookingId = bookingId });

                return result.Succeed;
            });
        }

        public Task<IEnumerable<ReminderNotification>> GetAllAsync()
        {
            return HandleAsync(async client =>
            {
                var result = await client.GetAllAsync(new GetAllRequest());

                return Mapping.Mapper.Map<IEnumerable<ReminderNotification>>(result.Notifications);
            });
        }

        public Task<ReminderNotification> GetAsync(int bookingId)
        {
            return HandleAsync(async client =>
            {
                var result = await client.GetAsync(new GetRequest { BookingId = bookingId });

                return Mapping.Mapper.Map<ReminderNotification>(result.Notification);
            });
        }

        public Task<bool> UpdateAsync(CreateUpdateReminderRequest request)
        {
            return HandleAsync(async client =>
            {
                var model = Mapping.Mapper.Map<UpdateRequest>(request);

                var result = await client.UpdateAsync(model);

                return result.Succeed;
            });
        }

        protected override Reminder.ReminderClient CreateGrpcClient()
        {
            var channel = GetClientGrpcChannel(ServiceSettingsProvider.ComposeSchedulerServiceUrl());

            return new Reminder.ReminderClient(channel);
        }
    }
}
