﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using MimeKit;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common;
using Travely.SchedulerManager.Notifier.Hubs;

namespace Travely.SchedulerManager.Notifier.Services
{
    class NotifierService : INotifierService, IEmailService
    {
        private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;
        private readonly NotifierOptions _notifierOptions;
        public NotifierService(IHubContext<NotificationHub, INotificationHub> hub, IOptionsMonitor<NotifierOptions> options)
        {
            _hubContext = hub;
            _notifierOptions = options.CurrentValue;
        }
        public async Task<IEnumerable<string>> NotifyAsync(NotificationModel model)
        {
            var shouldGet = (await GetOnlineUsers()).Intersect(model.UserIds.Select(id => id.ToString())).ToList();
            await _hubContext.Clients.Users(shouldGet).ReceiveNotification(model);
            return shouldGet;
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
            mimeMessage.From.Add(new MailboxAddress(_notifierOptions.EmailOptions.Sender, _notifierOptions.EmailOptions.Username));
            using var client = new SmtpClient
            {
                ServerCertificateValidationCallback = (_, _, _, _) => true,
                SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12
            };
            await client.ConnectAsync(_notifierOptions.EmailOptions.Server, _notifierOptions.EmailOptions.Port, false);
            await client.AuthenticateAsync(_notifierOptions.EmailOptions.Username, _notifierOptions.EmailOptions.Password);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }

        private async Task<IEnumerable<string>> GetOnlineUsers()
        {
            using var redis = await ConnectionMultiplexer.ConnectAsync(_notifierOptions.RedisConnectionString);
            var db = redis.GetDatabase();
            var keys = redis.GetServer(_notifierOptions.RedisConnectionString).Keys();
            return keys.Select(key => key.ToString()).ToList();
        }
    }
}
