using AutoMapper;
using IdentityManager.DataService.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.WebApi.Mappers;

namespace Travely.IdentityManager.WebApi.Extensions
{
    public static class AutoMapperConfigurationExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new UserProfile(provider.GetRequiredService<IPasswordHasher<User>>()));
                cfg.AddProfile(new PersistGrantProfile());
                cfg.AddProfile(new EmployeeProfile());
                cfg.AddProfile(new AgencyProfile());
            }).CreateMapper());

        }
    }
}
