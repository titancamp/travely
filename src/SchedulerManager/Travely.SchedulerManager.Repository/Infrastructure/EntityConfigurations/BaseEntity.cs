using System;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository.Infrastructure.EntityConfigurations
{
    public class BaseEntity: IIdentity, IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool Active { get; set; }
    }
}