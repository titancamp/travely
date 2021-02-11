using Microsoft.Extensions.DependencyInjection;
using Travely.PropertyManager.Domain.Contracts.Services;
using Travely.PropertyManager.Domain.Services;

namespace Travely.PropertyManager.Bootstrapper
{
    public static partial class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IPropertyService, PropertyService>();
        }
    }
}
