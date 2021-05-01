using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;
using Travely.SchedulerManager.Notifier;

namespace Travely.SchedulerManager.API.Services
{
    public class EmailService : EmailGrpc.EmailGrpcBase
    {
        private readonly IEmailService _emailService;
        public EmailService(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async override Task<Empty> Send(SendEmailRequest request, ServerCallContext context)
        {
            await _emailService.SendEmailAsync(request.Receiver, request.Title, request.Subject, request.Subject);
            return new Empty();
        }
    }
}
