using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.ClientManager.Domain.Entity.Client;

namespace Travely.ClientManager.Repository.SqlServer
{
    public class ClientDbContext : DbContext
    {
        private IConfiguration _configuration = null;

        public DbSet<Client> Clients { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        public ClientDbContext(DbContextOptions<ClientDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Client

            // modelBuilder.Entity<Client>()
            //.HasIndex(p => new { p.PassportId }).IsUnique();

            #endregion

            #region Preference

            #endregion

            #region ClientPreference

            #endregion



            base.OnModelCreating(modelBuilder);

        }


    }
}
