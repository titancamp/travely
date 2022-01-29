using System;
using System.Collections.Generic;
using Travely.IdentityClient.Authorization.Entities;

namespace Travely.IdentityClient.Extensions
{
    public static class PermissionExtensions
    {
        public static IEnumerable<Permission> GetFlags(this Permission permission)
        {
            foreach (Permission flag in Enum.GetValues(typeof(Permission)))
                if (permission.HasFlag(flag))
                    yield return flag;
        }
    }
}
