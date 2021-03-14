using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityManager.DataService.EmailValidationService
{
    interface IEmailValidationTokenService
    {
        Task<string> CreateTokenAsync(string email, CancellationToken cancellationToken = default);

        Task<bool> ValidateTokenAsync(string token, CancellationToken cancellationToken = default);
    }
}
