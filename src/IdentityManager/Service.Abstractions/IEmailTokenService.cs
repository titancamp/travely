using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityManager.Service.Abstractions
{
    public interface IEmailTokenService
    {
        Task<string> GenerateTokenAsync(string key, CancellationToken cancellationToken = default);
        Task<bool> ValidateTokenAsync(string key, string token, CancellationToken cancellationToken = default);
    }
}
