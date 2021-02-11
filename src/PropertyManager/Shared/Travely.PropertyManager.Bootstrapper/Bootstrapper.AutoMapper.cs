using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Travely.PropertyManager.Domain.MappingProfiles;

namespace Travely.PropertyManager.Bootstrapper
{
    public static partial class Bootstrapper
    {
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(PropertyMappingProfile));
        }
    }
}
