using IdentityManager.API;
using IdentityManager.DataService.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.WebApi.Extensions
{
    public static class AutoMapperConfigurationExtension
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            
            services.AddAutoMapper(typeof(PersistGrantProfile));
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new PersistGrantProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
        }
    }
}
