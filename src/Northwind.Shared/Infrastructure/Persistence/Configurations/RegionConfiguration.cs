using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Shared.Domain.Entities;

namespace Northwind.Shared.Infrastructure.Persistence.Configurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regions");

        builder.HasKey(e => e.RegionId)
                .IsClustered(false);

        builder.Property(e => e.RegionId)
            .HasColumnName("RegionID")
            .ValueGeneratedNever();

        builder.Property(e => e.RegionDescription)
            .IsRequired()
            .HasMaxLength(50);
    }
}
