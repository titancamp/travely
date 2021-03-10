using AutoMapper;
using IdentityManager.API;
using IdentityManager.DataService.Mappers;
using IdentityManager.WebApi.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.WebApi.Extensions
{
    public static class AutoMapperConfigurationExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(PersistGrantProfile));
            //services.AddAutoMapper(typeof(UserProfile));
            services.AddSingleton(provider => new MapperConfiguration(cfg => 
            {
                cfg.AddProfile(new UserProfile(provider.GetService<IPasswordHasher<User>>()));
                cfg.AddProfile(new PersistGrantProfile());
            }).CreateMapper());

            //services.AddAutoMapperBuilder(builder =>
            //{
            //    builder.Profiles.Add(new UserProfile(services.BuildServiceProvider().GetRequiredService<IPasswordHasher<User>>()));
            //    builder.Profiles.Add(new PersistGrantProfile());
            //});
            
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new PersistGrantProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
        }
    }
}
