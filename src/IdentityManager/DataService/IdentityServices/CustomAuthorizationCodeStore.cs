﻿using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManager.DataService.IdentityServices
{
    public class CustomAuthorizationCodeStore : IAuthorizationCodeStore
    {
        public Task<AuthorizationCode> GetAuthorizationCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAuthorizationCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<string> StoreAuthorizationCodeAsync(AuthorizationCode code)
        {
            throw new NotImplementedException();
        }
    }
}
