using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.SchedulerManager.Common.Enums;
using Travely.SchedulerManager.Repository.Entities;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class UserScheduleRepository : Repository<UserSchedule>, IUserScheduleRepository
    {
        public UserScheduleRepository(SchedulerDbContext context):base(context)
        {}

        public async void MarkAllAs(NotificationStatus status, long scheduleInfoId)
        {
            var userScheduleList = await GetListAsync(o => o.ScheduleInfoId == scheduleInfoId,true);
            foreach(var userSchedule in userScheduleList)
            {
                userSchedule.Status = status;
            }
            await SaveAsync();
        }

        public async void MarkAs(NotificationStatus status, params long[] ids)
        {
            foreach(var id in ids)
            {
                var userSchedule = await FindAsync(id,true);
                userSchedule.Status = status;
            }
            await SaveAsync();
        }

        public async void MarkAs(NotificationStatus status, long scheduleInfoId, params long[] userIds)
        {
            var userScheduleList = await GetListAsync(o => o.ScheduleInfoId == scheduleInfoId && userIds.Contains(o.UserId), true);
            foreach (var userSchedule in userScheduleList)
            {
                userSchedule.Status = status;
            }
            await SaveAsync();
        }
    }
}
