using Microsoft.EntityFrameworkCore;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.EntityFramework
{
    public class IdentityServerDbContext : DbContext
    {
        public IdentityServerDbContext()
        {
        }

        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersistedGrant> PersistedGrants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Agency> Agency { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    //.IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.JobTitle)
                    //.IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastName)
                    //.IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Agency)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AgencyId)
                    .OnDelete(DeleteBehavior.ClientCascade);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Agency>(entity =>
            {
                entity.ToTable("Agency");

                entity.Property(e => e.Address)
                    //.IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LogoFile)
                    //.IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Owner)
                    .WithOne(p => p.Agency)
                    .HasForeignKey<Agency>(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PersistedGrant>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                modelBuilder.Entity<User>(entity =>
                {
                    entity.ToTable("Users");

                    entity.Property(e => e.Password).IsRequired();

                    entity.Property(e => e.UserName).IsRequired();
                });
            });
        }
    }
}
