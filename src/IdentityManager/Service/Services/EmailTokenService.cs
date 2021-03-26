using IdentityManager.Service.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityManager.Service.Services
{
    public class EmailTokenService : IEmailTokenService
    {
        public async Task<string> GenerateTokenAsync(string key, CancellationToken cancellationToken = default)
        {
            return Guid.NewGuid().ToString();
        }

        public async Task<bool> ValidateTokenAsync(string key, string token, CancellationToken cancellationToken = default)
        {
            return true;
        }
    }
}
