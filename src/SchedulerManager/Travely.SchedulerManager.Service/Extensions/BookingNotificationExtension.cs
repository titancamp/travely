using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Travely.SchedulerManager.Common.Enums;

namespace Travely.SchedulerManager.Service.Extensions
{
    public static class BookingNotificationExtension
    {
       public static Task<bool> CreateNotification(this IBookingNotificationService service, BookingExpireNotification model)
       {
           return service.CreateNotification(new CreateNotification()
           {
               RecurseId = model.TourId,
               Module = TravelyModule.Tour,
               JsonData = JsonConvert.SerializeObject(new
               {
                   model.BookingName,
                   model.TourName,
                   model.ExpireDate
               }),
               MessageTemplate = MessageTemplate.BookingExpire,
               ExpirationDate = model.ExpireDate,
               UserIds = model.UserIds
           });
       }
    }
}
