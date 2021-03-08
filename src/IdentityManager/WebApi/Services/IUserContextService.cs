using IdentityManager.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.WebApi.Services
{
    public interface IUserContextService
    {
        UserContextModel GetUserContext();
    }
}
