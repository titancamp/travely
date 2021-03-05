using FileService.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace FileService.Helpers
{
    public static class FileSystemServiceRegistrator
    {
        /// <summary>
        /// Adds IFileSystemConfigurator and IStorage implementations as scoped services
        /// </summary>
        /// <param name="services"></param>
        public static void AddFileSystemServices(this IServiceCollection services)
        {
            services.AddScoped<IFileSystemConfigurator, FileSystemJsonConfigurator>();
            services.AddScoped<IStorage, FileSystemStorage>();
        }
    }
}
