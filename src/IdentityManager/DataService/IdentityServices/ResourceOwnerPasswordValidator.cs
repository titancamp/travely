using IdentityServer4.Models;
using IdentityServer4.Validation;
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

        public ResourceOwnerPasswordValidator(IUserRepository rep)
        {
            _userRepo = rep;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            User? user = await _userRepo.FindByEmailAsync(context.UserName);
            if (user != null)
            {
                if (context.Password.Equals(user.Password)) // compare with Hashed password 
                {
                    context.Result = new GrantValidationResult(user.Id.ToString(), "password", null, "local", null);
                    return;//https://sinanbir.com/wp-content/uploads/2017/03/postmancore2-3.png
                }
            }            
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return;
        }
    }
}
