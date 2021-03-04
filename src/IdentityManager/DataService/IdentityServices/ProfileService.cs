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
				var user = await _userRepo.GetAll().Where(x=>x.Id == Convert.ToInt32(subjectId)).FirstOrDefaultAsync();

				//user = new Travely.IdentityManager.Repository.Abstractions.Entities.User
				//{
				//	Id = 6,
				//	Role = Travely.IdentityManager.Repository.Abstractions.Entities.Role.User,
				//	Agency = new Travely.IdentityManager.Repository.Abstractions.Entities.Agency
				//	{
				//		Id = 1
				//	}
				//};

				var claims = new List<Claim>
				{
					new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
					new Claim(JwtClaimTypes.Role, user.Role.ToString()),
					new Claim(JwtClaimTypes.ZoneInfo, user.Agency.Id.ToString())
				};

				context.IssuedClaims = claims;
				return;// Task.FromResult(0);
			}
			catch (Exception x)
			{
				return;
			}
		}

		public async Task IsActiveAsync(IsActiveContext context)
		{			
			var user = await _userRepo.GetAll().Where(x=>x.Id == Convert.ToInt32(context.Subject.GetSubjectId())).FirstOrDefaultAsync();

			//user = new Travely.IdentityManager.Repository.Abstractions.Entities.User
			//{
			//	Id = 6,
			//	Status= Travely.IdentityManager.Repository.Abstractions.Entities.Status.Active
			//};

			context.IsActive = (user != null && user.Status == Travely.IdentityManager.Repository.Abstractions.Entities.Status.Active); // && user.Active;
			return;
		}
	}
}
