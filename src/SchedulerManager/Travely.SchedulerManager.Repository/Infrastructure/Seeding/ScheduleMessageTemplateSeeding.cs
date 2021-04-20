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
                    MessageTemplate.BookingCancellationExpiration,
                    new ScheduleMessageTemplate()
                    {
                        TemplateName = MessageTemplate.BookingCancellationExpiration,
                        Template = "Booking Cancellation Date is approaching for the tour {@Model.TourName} in {@Model.NumberOfDaysUntilExpiration} day(s) for the {@Model.HotelName} hotel. The cancellation is due {@Model.BookingCancellationDate}"
                    }
                },
                {
                    MessageTemplate.IncompleteBookingRequests,
                    new ScheduleMessageTemplate()
                    {
                        TemplateName = MessageTemplate.IncompleteBookingRequests,
                        Template = "Tour {@Model.TourName} is starting on {@Model.TourStartDate} and has incomplete bookings. Please check to make sure everything is ready for the tour."
                    }
                },
                {
                    MessageTemplate.TourIsApproaching,
                    new ScheduleMessageTemplate()
                    {
                        TemplateName = MessageTemplate.TourIsApproaching,
                        Template = "Tour {@Model.TourName} is starting on {@Model.TourStartDate}. Please go through the tour details to make sure everything is ready"
                    }
                },
                {
                    MessageTemplate.ChangeInTourField,
                    new ScheduleMessageTemplate()
                    {
                        TemplateName = MessageTemplate.ChangeInTourField,
                        Template = "A change has been made in {@Model.ChangedFieldName} in the tour {@Model.TourName} by {@Model.UserWhoMadeTheChange}."
                    }
                },
                {
                    MessageTemplate.TourStartDateChange,
                    new ScheduleMessageTemplate()
                    {
                        TemplateName = MessageTemplate.TourStartDateChange,
                        Template = "The start date of the tour {@Model.TourName} has been changed from {@Model.OldStartDate} to {@Model.StartDate} by {@Model.UserWhoMadeTheChange}."
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
