using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Travely.ClientManager.Repository.Entity.Client;

namespace Travely.ClientManager.Repository
{
    public class TuristDbContext : DbContext
    {
        private IConfiguration _configuration = null;

        public DbSet<Turist> Clients { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        public TuristDbContext(DbContextOptions<TuristDbContext> options, IConfiguration configuration)
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
