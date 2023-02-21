using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Shared.Domain.Entities;

namespace Northwind.Shared.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.ToTable("Categories");

        builder.Property(e => e.CategoryId).HasColumnName("CategoryID");

        builder.Property(e => e.CategoryName)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(e => e.Description).HasColumnType("ntext");

        builder.Property(e => e.Picture).HasColumnType("image");
    }
}
