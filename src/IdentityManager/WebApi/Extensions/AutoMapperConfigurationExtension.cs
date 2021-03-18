using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using AutoMapper;

using IdentityManager.DataService.Mappers;
using IdentityManager.WebApi.Mappers;

using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.WebApi.Extensions
{
    public static class AutoMapperConfigurationExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new UserProfile(provider.GetService<IPasswordHasher<User>>()));
                cfg.AddProfile(new PersistGrantProfile());
                cfg.AddProfile(new EmployeeProfile());
            }).CreateMapper());

        }
    }
}
