﻿using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager;

namespace Travely.SchedulerManager.API.Services
{
    public class ReminderService : Reminder.ReminderBase
    {
        private readonly IBookingNotificationService _notificationService;

        public ReminderService(IBookingNotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {
            var result = await _notificationService.GetNotification(request.BookingId);
            return new GetResponse()
            {
                Notification = new Notification()
                {
                    BookingId = result.BookingId,
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
                BookingId = n.BookingId,
                Message = n.Message
            }));
            return response;
        }

        public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            var result = await _notificationService.CreateNotification(request.TourId, request.BookingId, request.TourName, request.BookingName, request.BookingNotes, request.ExpireDate, request.AssignedUserIds);
            return new CreateResponse() { Succeed = result };
        }

        public override async Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {
            var result = await _notificationService.UpdateNotification(request.TourId, request.BookingId, request.TourName, request.BookingName, request.BookingNotes, request.ExpireDate, request.AssignedUserIds);
            return new UpdateResponse() { Succeed = result };
        }

        public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var result = await _notificationService.DeleteNotification(request.BookingId);
            return new DeleteResponse() { Succeed = result };
        }
    }
}
