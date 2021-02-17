using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;

namespace IdentityManager.DataService.IdentityServices
{
	public class ProfileService : IProfileService
	{
		private IUserRepository _userReop;

		public ProfileService(IUserRepository rep)
		{
			_userReop = rep;
		}

		public Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			try
			{
				var subjectId = context.Subject.GetSubjectId();
				var user = _userReop.GetByConditionAsync(x=>x.Id == Convert.ToInt32(subjectId));

				var claims = new List<Claim>
				{
					new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
				};

				context.IssuedClaims = claims;
				return Task.FromResult(0);
			}
			catch (Exception x)
			{
				return Task.FromResult(0);
			}
		}

		public Task IsActiveAsync(IsActiveContext context)
		{
			var user = _userReop.GetByConditionAsync(x => x.Id == Convert.ToInt32(context.Subject.GetSubjectId()));
			context.IsActive = (user != null); // && user.Active;
			return Task.FromResult(0);
		}
	}
}
