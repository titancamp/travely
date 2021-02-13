using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager;


namespace Travely.SchedulerManager.API.Services
{
    public class ReminderService : Reminder.ReminderBase
    {
        private readonly IReminderService _reminderService;

        public ReminderService(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public override Task<GetResponse> Get(GetRequest request, ServerCallContext context)
        {
            _reminderService.Get(request.BookingId);
            return Task.FromResult<GetResponse>(new GetResponse());
            
        }

        public override Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
        {
            _reminderService.GetAll();
            return Task.FromResult<GetAllResponse>(new GetAllResponse());
        }

        public override Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
        {
            var succeed = _reminderService.Create();
            return Task.FromResult<CreateResponse>(new CreateResponse() { Succeed = succeed });
        }

        public override Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
        {
            var succeed = _reminderService.Update();
            return Task.FromResult<UpdateResponse>(new UpdateResponse() { Succeed = succeed });
        }

        public override Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
        {
            var succeed = _reminderService.Delete(request.BookingId);
            return Task.FromResult<DeleteResponse>(new DeleteResponse() { Succeed = succeed });
        }
    }
}
