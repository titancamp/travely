using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using IdentityManager.WebApi.Filters;

using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models;
using Travely.IdentityManager.Service.Identity;

namespace IdentityManager.WebApi.Extensions
{
    public static class ServiceConfigurationExtension
    {
        public static void ConfigureFilterServices(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidateModelStateActionFilter());
            });

            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static UserContextModel GetUserContext(this HttpContext context)
        {
            var claims = context?.User?.Claims;
            UserContextModel userContext = new UserContextModel();
            userContext.Role = (Role)int.Parse(claims.First(p => p.Type.Contains("role")).Value);
            userContext.UserId = int.Parse(claims.First(p => p.Type == "sub").Value);
            userContext.AgencyId = int.Parse(claims.First(p => p.Type == "AgencyId").Value);

            return userContext;
        }
    }

}
