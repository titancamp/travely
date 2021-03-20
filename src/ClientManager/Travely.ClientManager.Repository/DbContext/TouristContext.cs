using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Travely.ClientManager.Abstraction.Entity;

namespace Travely.ClientManager.Repository
{
    public class TouristContext : DbContext
    {
        public DbSet<Tourist> Clients { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        public TouristContext(DbContextOptions<TouristContext> options)
            : base(options)
        {

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
