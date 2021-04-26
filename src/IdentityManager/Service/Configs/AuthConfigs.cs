using System.Collections.Generic;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using IdentityServer4;
using IdentityServer4.Models;

using static IdentityServer4.IdentityServerConstants;

namespace IdentityManager.DataService.Configs
{
    public class AuthConfigs
    {
        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>
            {
               // new ApiScope(LocalApi.ScopeName),
                //StandardScopes.OfflineAccess,
                new ApiScope
                {
                    Name = "api1",
                    Description = "My API",
                },
                new ApiScope(LocalApi.ScopeName)
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
               new ApiResource(),
               new ApiResource(LocalApi.ScopeName)
            };
        }

        public static IEnumerable<Client> GetClients(IWebHostEnvironment env)
        {
            List<string> cors = null;
            if (env.IsDevelopment())
            {
                cors = new List<string>();
                cors.Add("http://localhost:5000");
                cors.Add("http://localhost:3000");
            }

            return new List<Client>
            {
                new Client
                {
                    ClientId = "resourceOwner",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess= true,
                    AllowedScopes =
                    {
                        "offline_access",
                        "api1",
                        IdentityServerConstants.LocalApi.ScopeName
                    },
                    AllowedCorsOrigins = cors,
                },
                new Client
                {
                    ClientId = "api1.client",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                
                    AllowedGrantTypes = { "delegation" },
                
                    AllowedScopes = new List<string>
                    {
                        "api2"
                    },
                    AllowedCorsOrigins = cors,
                }
            };
        }


    }
}
