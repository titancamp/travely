using IdentityManager.WebApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.WebApi.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private UserContextModel userContext;
        private string language;

        public UserContextService(IHttpContextAccessor contextAccessor)
        {

            _contextAccessor = contextAccessor;
        }

        private HttpContext Context
        {
            get
            {
                return _contextAccessor.HttpContext;
            }
        }

        public UserContextModel GetUserContext()
        {
            if (userContext == null)
            {
                var claims = Context?.User?.Claims;
                userContext = new UserContextModel();
                userContext.Role = (Role)int.Parse(claims.First(p => p.Type.Contains("role")).Value);
                userContext.UserId = int.Parse(claims.First(p => p.Type == "sub").Value);
                userContext.AgencyId = int.Parse(claims.First(p => p.Type == "AgencyId").Value);
            }

            return userContext;
        }
    }
}