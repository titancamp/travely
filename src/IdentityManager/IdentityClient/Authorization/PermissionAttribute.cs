﻿using System;
using Travely.Common.Entities;

namespace Travely.IdentityClient.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class PermissionAttribute : Attribute
    {
        public readonly Permission Permission;

        public PermissionAttribute(Permission permission) : base()
        {
            this.Permission = permission;
        }
    }
}
