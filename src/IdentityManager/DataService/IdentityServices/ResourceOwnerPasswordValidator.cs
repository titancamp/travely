using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.DataService.IdentityServices
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        IUserRepository _userRepo;
        IPasswordHasher<User> _passHasher;
        ILogger<ResourceOwnerPasswordValidator> _logger;
        public ResourceOwnerPasswordValidator(ILogger<ResourceOwnerPasswordValidator> logger,IUserRepository rep, IPasswordHasher<User> passHasher)
        {
            _userRepo = rep;
            _passHasher = passHasher;
            _logger = logger;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await _userRepo.FindByEmailAsync(context.UserName);
                user = new User
                {
                    Id = 1
                };
                if (user != null)
                {
                    PasswordVerificationResult verificationResult = _passHasher.VerifyHashedPassword(user, user.Password, context.Password);
                    if (verificationResult == PasswordVerificationResult.Success)
                    {
                        context.Result = new GrantValidationResult(user.Id.ToString(), "password", null, "local", null);
                        return;//https://sinanbir.com/wp-content/uploads/2017/03/postmancore2-3.png
                    }
                }
                
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
                return;
            }
            catch (Exception ex)
            {
                _logger.LogDebug("Invalid data");
            }
        }
    }
}
