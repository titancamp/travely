using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.ServiceManager.DAL
{
    public static class DbContextOptionsBuilderExtension
    {
        public static void UseCustomDatabaseServer(this DbContextOptionsBuilder options, IConfiguration configuration)
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options.UseLazyLoadingProxies();
        }
    }
}
