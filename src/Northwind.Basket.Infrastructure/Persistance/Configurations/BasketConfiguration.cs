using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Northwind.Basket.Infrastructure.Persistance.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Domain.Entities.Basket>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Basket> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(p => p.CustomerId)
            .HasColumnName("CustomerId")
            .IsRequired();

        builder.HasMany(b => b.Items);            

        var navigation = builder.Metadata.FindNavigation(nameof(Domain.Entities.Basket.Items));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Property);
    }
}
