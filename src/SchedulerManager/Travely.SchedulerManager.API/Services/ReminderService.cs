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
            var result = await _notificationService.GetNotification(request.BookingId); 
            //TODO: Fix this and use scheduleId
            return new GetResponse()
            {
                Notification = new Notification()
                {
                    BookingId = result.RecurseId,
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
                BookingId = n.RecurseId,
                Message = n.Message
            }));
            return response;
        }

        public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
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
            //var result = await _notificationService.CreateNotification(dto);
            //return new CreateResponse() { Succeed = result };
            throw new NotImplementedException();
        }

        public override async Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
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
            await _notificationService.UpdateNotification(dto);
            return new UpdateResponse() { };
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            await _notificationService.DeleteNotification(request.BookingId);
            return new DeleteResponse() { };
        }
    }
}
