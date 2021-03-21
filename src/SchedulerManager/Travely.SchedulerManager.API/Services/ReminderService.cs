using System;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager.Service;
using Travely.SchedulerManager.Common.Enums;

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
            var msgTemplate = request.NotificationType switch
            {
                NotificationType.BookingCancellationExpiration => MessageTemplate.BookingCancellationExpiration,
                NotificationType.IncompleteBookingRequests => MessageTemplate.IncompleteBookingRequests,
                NotificationType.TourIsApproaching => MessageTemplate.TourIsApproaching,
                _ => MessageTemplate.BookingCancellationExpiration
            };
            var result = await _notificationService.GetNotification(request.TourId, request.BookingId, msgTemplate);
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
            INotificationModel model = request.NotificationType switch
            {
                NotificationType.BookingCancellationExpiration => new BookingCancellationExpirationNotificationModel
                {
                    TourId = request.TourId,
                    BookingId = request.BookingId,
                    TourName = request.TourName,
                    BookingName = request.BookingName,
                    BookingCancellationDate = request.BookingExpireDate.ToDateTime(),
                    UserIds = request.AssignedUserIds
                },

                NotificationType.IncompleteBookingRequests => new IncompleteBookingRequestsNotificationModel
                {
                    TourId = request.TourId,
                    TourName = request.TourName,
                    TourStartDate = request.TourStartDate.ToDateTime(),
                    UserIds = request.AssignedUserIds
                },

                NotificationType.TourIsApproaching => new TourIsApproachingNotificationModel
                {
                    TourId = request.TourId,
                    TourName = request.TourName,
                    TourStartDate = request.TourStartDate.ToDateTime(),
                    UserIds = request.AssignedUserIds
                },

                _ => null
            };

            var result = await _notificationService.CreateNotification(model);
            return new CreateScheduledNotificationResponse() { Succeed = result };
        }

        public override async Task<UpdateScheduledNotificationResponse> UpdateScheduledNotification(UpdateScheduledNotificationRequest request, ServerCallContext context)
        {
            INotificationModel model = request.NotificationType switch
            {
                NotificationType.BookingCancellationExpiration => new BookingCancellationExpirationNotificationModel
                {
                    TourId = request.TourId,
                    BookingId = request.BookingId,
                    TourName = request.TourName,
                    BookingName = request.BookingName,
                    BookingCancellationDate = request.BookingExpireDate.ToDateTime(),
                    UserIds = request.AssignedUserIds
                },

                NotificationType.IncompleteBookingRequests => new IncompleteBookingRequestsNotificationModel
                {
                    TourId = request.TourId,
                    TourName = request.TourName,
                    TourStartDate = request.TourStartDate.ToDateTime(),
                    UserIds = request.AssignedUserIds
                },

                NotificationType.TourIsApproaching => new TourIsApproachingNotificationModel
                {
                    TourId = request.TourId,
                    TourName = request.TourName,
                    TourStartDate = request.TourStartDate.ToDateTime(),
                    UserIds = request.AssignedUserIds
                },

                _ => null
            };

            var result = await _notificationService.UpdateNotification(model);
            return new UpdateScheduledNotificationResponse() { Succeed = result};
        }

        public override async Task<DeleteScheduledNotificationResponse> DeleteScheduledNotification(DeleteScheduledNotificationRequest request, ServerCallContext context)
        {
            var msgTemplate = request.NotificationType switch
            {
                NotificationType.BookingCancellationExpiration => MessageTemplate.BookingCancellationExpiration,
                NotificationType.IncompleteBookingRequests => MessageTemplate.IncompleteBookingRequests,
                NotificationType.TourIsApproaching => MessageTemplate.TourIsApproaching,
                _ => MessageTemplate.BookingCancellationExpiration
            };
                
            var result = await _notificationService.DeleteNotification(request.TourId, request.BookingId, msgTemplate);
            return new DeleteScheduledNotificationResponse() { Succeed = result};
        }

        public override async Task<CreateFieldChangedNotificationResponse> CreateFieldChangedNotification(CreateFieldChangedNotificationRequest request, ServerCallContext context)
        {
            var model = new ChangeInTourFieldNotificationModel
            {
                TourId = request.TourId,
                TourName = request.TourName,
                UserIdWhoMadeTheChange = request.User.UserId,
                UserWhoMadeTheChange = request.User.UserName,
                ChangedFieldName = request.FieldName,
                OldValue = request.OldValue,
                NewValue = request.NewValue,
                UserIds = request.AssignedUserIds
            };
            var result = await _notificationService.CreateNotification(model);
            return new CreateFieldChangedNotificationResponse() { Succeed = result };
        }
    }
}
