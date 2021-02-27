﻿using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Abstraction.Interfaces.Repositories
{
    public interface IActivityTypeRepository : IRepository<ActivityType>
    {
        Task<ActivityType> GetActivityTypeByAgencyIdAndTypeName(long agencyId, string activityTypeName);
    }
}
