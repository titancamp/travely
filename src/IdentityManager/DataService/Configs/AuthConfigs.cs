using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4;
//using Travely.IdentityManager.Repository.Abstractions.Entities;
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
                //new ApiScope(LocalApi.ScopeName)
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

        public static IEnumerable<Client> GetClients()
        {
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
                    }
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
                    }
                }
            };
        }


    }
}
