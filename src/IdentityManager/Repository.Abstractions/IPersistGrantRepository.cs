using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.Abstractions
{
    public interface IPersistGrantRepository : IBaseRepository<PersistedGrant>
    {
    }
}
