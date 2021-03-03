using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityManager.DataService.IdentityServices
{
    public class CustomClientStore : IClientStore
    {
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            Client client = new Client
            {
                ClientId = "resourceOwner",
                ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                AllowOfflineAccess = true,
                AllowedScopes =
                    {
                        "offline_access",
                        "api1"
                    }
            };

            return client;
        }
    }
}
