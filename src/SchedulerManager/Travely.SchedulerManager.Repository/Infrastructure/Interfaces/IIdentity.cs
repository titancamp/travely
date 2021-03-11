using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Travely.SchedulerManager.Repository.Infrastructure.Interfaces
{
    public interface IIdentity
    {
        long Id { get; set; }
    }
}