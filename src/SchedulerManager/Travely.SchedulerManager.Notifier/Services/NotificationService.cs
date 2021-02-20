using MailKit.Net.Smtp;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Security.Authentication;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Notifier.Hubs;

namespace Travely.SchedulerManager.Notifier.Services
{
    class NotificationService : INotificationService, IEmailService
    {
        readonly IHubContext<NotificationHub, INotificationHub> _hubContext;
        readonly EmailOptions _emailOptions;
        public NotificationService(IHubContext<NotificationHub, INotificationHub> hub, IOptionsMonitor<EmailOptions> options)
        {
            _hubContext = hub;
            _emailOptions = options.CurrentValue;
        }
        public Task NotifyAsync(NotificationInfoDTO dto)
        {
            //TODO
            return _hubContext.Clients.Client("connectionId").ReceiveNotification(new { message = "Hola" });
        }

        public async Task SendEmailAsync(string receiverEmail, string title, string subject, string content)
        {
            var mimeMessage = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart("plain")
                {
                    Text = content
                }
            };
            mimeMessage.To.Add(new MailboxAddress(title, receiverEmail));
            mimeMessage.From.Add(new MailboxAddress(_emailOptions.Sender, _emailOptions.Username));
            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (_, _, _, _) => true,
                SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12
            };
            await client.ConnectAsync(_emailOptions.Server, _emailOptions.Port, false);
            await client.AuthenticateAsync(_emailOptions.Username, _emailOptions.Password);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }
    }
}
