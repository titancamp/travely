using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Travely.IdentityManager.IdentityService.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class IdentityAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserTypes _userType;

        public IdentityAuthorizeAttribute (UserTypes userType)
        {
            _userType = userType;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            return;
        }
    }
}
