using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Travely.TourManager.DAL.Configurations
{
    public class EntityConfigurations : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.Preferences)
                .HasConversion(
                x => JsonSerializer.Serialize(x, default),
                x => JsonSerializer.Deserialize<IList<string>>(x, default));
        }
    }
}
