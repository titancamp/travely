using System;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.API.Services
{
    public class ReminderService : Reminder.ReminderBase
    {
        private readonly INotificationService _notificationService;

        public ReminderService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {
            var result = await _notificationService.GetNotification(request.TourId, request.BookingId, request.NotificationType);
            //TODO: Fix this and use scheduleId
            return new GetResponse()
            {
                Notification = new Notification()
                {
                    Message = result.Message
                }
            };
        }

        public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            var result = await _notificationService.GetAllNotifications();
            var response = new GetAllResponse();
            response.Notifications.AddRange(result.Select(n => new Notification()
            {
                Message = n.Message
            }));
            return response;
        }

        public override async Task<CreateScheduledNotificationResponse> CreateScheduledNotification(CreateScheduledNotificationRequest request, ServerCallContext context)
        {            
            //TODO: change to BookingExpireNotification model
            //var dto = new CreateNotification
            //{
            //    TourId = request.TourId,
            //    TourName = request.TourName,
            //    BookingId = request.BookingId,
            //    BookingName = request.BookingName,
            //    BookingNotes = request.BookingNotes,
            //    ExpireDate = request.ExpireDate.ToDateTime(),
            //    UserIds = request.AssignedUserIds
            //};
            var result = await _notificationService.CreateScheduledNotification(dto);
            return new CreateScheduledNotificationResponse() { Succeed = result };
        }

        public override async Task<UpdateScheduledNotificationResponse> UpdateScheduledNotification(UpdateScheduledNotificationRequest request, ServerCallContext context)
        {
            //TODO: 
            //var dto = new UpdateNotificationModel
            //{
            //    TourId = request.TourId,
            //    TourName = request.TourName,
            //    BookingId = request.BookingId,
            //    BookingName = request.BookingName,
            //    BookingNotes = request.BookingNotes,
            //    ExpireDate = request.ExpireDate.ToDateTime(),
            //    UserIds = request.AssignedUserIds
            //};
            var result = await _notificationService.UpdateScheduledNotification(dto);
            return new UpdateScheduledNotificationResponse() { Succeed = result};
        }

        public override async Task<DeleteScheduledNotificationResponse> DeleteScheduledNotification(DeleteScheduledNotificationRequest request, ServerCallContext context)
        {
            var result = await _notificationService.DeleteScheduledNotification(request.TourId, request.BookingId, request.NotificationType);
            return new DeleteScheduledNotificationResponse() { Succeed = result};
        }

        public override async Task<CreateFieldChangedNotificationResponse> CreateFieldChangedNotification(CreateFieldChangedNotificationRequest request, ServerCallContext context)
        {
            var result = await _notificationService.CreateFieldChangedNotification();
            return new CreateFieldChangedNotificationResponse() { Succeed = result };
        }
    }
}
