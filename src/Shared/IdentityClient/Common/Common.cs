using System;
using System.ComponentModel;

namespace Travely.Shared.IdentityClient.Authorization
{
    //
    // Summary:
    //     class for user Roles for Authorize attribute
    //
    public static class UserTypes
    {
        public const string User = "User";
        public const string Admin = "Admin";
    }


    //
    // Summary:
    //     class to keep values for the Application configuration
    //
    public static class ApplicationInfo
    {
        public const string Bearer = "Bearer";
        public const string Cookies = "Cookies";
        public const string Oidc = "oidc";
        public const string IdentityServerUrl = "https://localhost:5123"; //IdentityServerApiUrl
    }
}
