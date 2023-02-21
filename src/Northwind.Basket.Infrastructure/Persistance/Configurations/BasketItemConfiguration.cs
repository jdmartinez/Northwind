using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Northwind.Basket.Domain.Entities;

namespace Northwind.Basket.Infrastructure.Persistance.Configurations;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).IsRequired();        
        builder.Property(p => p.ProductId).IsRequired();        
        builder.Property(p => p.Quantity).IsRequired();        
    }
}
