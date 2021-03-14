using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Infrastructure.Seeding
{
    public static partial class DbSeeding
    {
        internal static async Task ScheduleMessageTemplateSeeding(IScheduleMessageTemplateRepository scheduleMessageTemplateRepository)
        {
            var allScheduleMessageTemplates = new Dictionary<MessageTemplate, ScheduleMessageTemplate>
            {
                {
                    MessageTemplate.BookingExpire,
                    new ScheduleMessageTemplate()
                    {
                        TemplateName = MessageTemplate.BookingExpire,
                        Template = "Your booking {@Model.BookingName} for {@Model.TourName} tour will expire on {@Model.ExpireDate}"
                    }
                }
            };

            //TODO: Look at it after release maybe we can optimize it.
            var messageTemplates = allScheduleMessageTemplates.Select(s => s.Key).ToList();
            var existedMessageTemplatesInTable = (await scheduleMessageTemplateRepository.GetListAsync(f => messageTemplates.Contains(f.TemplateName))).Select(s => s.TemplateName).ToList();
            var notExistedMessageTemplates = messageTemplates.Except(existedMessageTemplatesInTable).ToList();
            if (notExistedMessageTemplates.Any())
            {
                var needToBeInserted = allScheduleMessageTemplates.Where(s => notExistedMessageTemplates.Contains(s.Key)).Select(s => s.Value).ToList();
                await scheduleMessageTemplateRepository.AddRangeAsync(needToBeInserted);
                await scheduleMessageTemplateRepository.SaveAsync();
            }

        }
    }
}
