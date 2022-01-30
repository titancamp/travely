using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.Common.Grpc;
using Travely.Common.Grpc.Abstraction;
using Travely.SchedulerManager.Grpc.Client.Abstraction;
using Travely.SchedulerManager.Grpc.Client.Models;

namespace Travely.SchedulerManager.Grpc.Client.Implementation
{
    public class ReminderServiceClient : GrpcClientBase<Reminder.ReminderClient>, IReminderServiceClient
    {
        private readonly IMapper _mapper;

        public ReminderServiceClient(
            IServiceSettingsProvider<Reminder.ReminderClient> serviceSettingsProvider,
            IMapper mapper)
            : base(serviceSettingsProvider)
        {
            _mapper = mapper;
        }

        public Task<bool> CreateAsync(CreateUpdateReminderRequest request)
        {
            return HandleAsync(async client =>
            {
                var model = _mapper.Map<CreateScheduledNotificationRequest>(request);

                var result = await client.CreateScheduledNotificationAsync(model);

                return result.Succeed;
            });
        }

        public Task<bool> DeleteAsync(int bookingId)
        {
            return HandleAsync(async client =>
            {
                var result = await client.DeleteScheduledNotificationAsync(new DeleteScheduledNotificationRequest { BookingId = bookingId });

                return result.Succeed;
            });
        }

        public Task<IEnumerable<ReminderNotification>> GetAllAsync()
        {
            return HandleAsync(async client =>
            {
                var result = await client.GetAllAsync(new GetAllRequest());

                return _mapper.Map<IEnumerable<ReminderNotification>>(result.Notifications);
            });
        }

        public Task<ReminderNotification> GetAsync(int bookingId)
        {
            return HandleAsync(async client =>
            {
                var result = await client.GetAsync(new GetRequest { BookingId = bookingId });

                return _mapper.Map<ReminderNotification>(result.Notification);
            });
        }

        public Task<bool> UpdateAsync(CreateUpdateReminderRequest request)
        {
            return HandleAsync(async client =>
            {
                var model = _mapper.Map<UpdateScheduledNotificationRequest>(request);

                var result = await client.UpdateScheduledNotificationAsync(model);

                return result.Succeed;
            });
        }
    }
}
