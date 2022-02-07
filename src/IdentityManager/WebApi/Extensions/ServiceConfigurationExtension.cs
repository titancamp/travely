using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Travely.Common.Entities;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models;
using Travely.IdentityManager.Service.Identity;
using Travely.IdentityManager.WebApi.Filters;

namespace Travely.IdentityManager.WebApi.Extensions
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

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }

}
