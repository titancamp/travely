using Microsoft.EntityFrameworkCore;
using Travely.TourManager.DAL.Configurations;

namespace Travely.TourManager.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TourType> TourTypes { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourStatus> TourStatuses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<GroupLanguage> GroupLanguages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EntityConfigurations());
        }
    }
}
