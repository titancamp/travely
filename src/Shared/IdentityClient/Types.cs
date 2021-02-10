using System;

namespace Travely.IdentityManager.IdentityService.Authorization
{
    [Flags]
    public enum UserTypes
    {
        None = 0,

        User = 1,
        Admin = 1 << 1,

        Both = 1 << 2,
    }
}
