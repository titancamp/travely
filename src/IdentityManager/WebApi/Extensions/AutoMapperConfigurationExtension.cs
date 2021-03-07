using AutoMapperBuilder.Extensions.DependencyInjection;
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
            services.AddAutoMapper(typeof(PersistGrantProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapperBuilder(builder =>
            {
                builder.Profiles.Add(new UserProfile(services.BuildServiceProvider().GetRequiredService<IPasswordHasher<User>>()));
            });

            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new PersistGrantProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
        }
    }
}
