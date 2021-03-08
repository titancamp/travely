using IdentityManager.WebApi.Filters;
using IdentityManager.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.API.Identity;

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

        public static void AddContextServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserContextService, UserContextService>();
        }
    }

}
