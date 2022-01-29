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
        private readonly IUserRepository _userRepository;

        public ProfileService(IUserRepository rep)
        {
            _userRepository = rep;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                var userId = Convert.ToInt32(subjectId);
                var userData = await _userRepository.GetAll().Where(x=>x.Id == userId).Select(x=>new
                {
                    x.Id,
                    x.Role,
                    x.AgencyId
                }).FirstOrDefaultAsync();

                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, userData.Id.ToString()),
                    new Claim(JwtClaimTypes.Role, userData.Role.ToString()),
                    new Claim("AgencyId", userData.AgencyId.ToString())
                };

                context.IssuedClaims = claims;
                return;
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userRepository.GetAll().Where(x => x.Id == Convert.ToInt32(context.Subject.GetSubjectId())).FirstOrDefaultAsync();

            context.IsActive = (user != null && user.Status == Status.Active); // && user.Active;
            return;
        }
    }
}
