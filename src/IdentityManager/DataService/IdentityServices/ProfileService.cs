using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.DataService.IdentityServices
{
    public class ProfileService : IProfileService
    {
        private IUserRepository _userRepo;

        public ProfileService(IUserRepository rep)
        {
            _userRepo = rep;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                User user = await _userRepo.GetAll().Where(x => x.Id == Convert.ToInt32(subjectId)).Include(x => x.Agency).FirstOrDefaultAsync();

                user = new User
                {
                    Id = 2,
                    Role = Role.Admin,
                    Agency = new Agency { Id = 1 }
                };

                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                    new Claim(JwtClaimTypes.Role, user.Role.ToString()),
                    new Claim("AgencyId", user.Agency.Id.ToString())
                };

                context.IssuedClaims = claims;
                return;// Task.FromResult(0);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userRepo.GetAll().Where(x => x.Id == Convert.ToInt32(context.Subject.GetSubjectId())).FirstOrDefaultAsync();

            context.IsActive = (user != null && user.Status == Travely.IdentityManager.Repository.Abstractions.Entities.Status.Active); // && user.Active;
            return;
        }
    }
}
