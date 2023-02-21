using Microsoft.EntityFrameworkCore;

using Northwind.Basket.Domain.Entities;

namespace Northwind.Basket.Infrastructure.Persistance;

public class BasketDbContext : DbContext
{
    public DbSet<Domain.Entities.Basket> Baskets => Set<Domain.Entities.Basket>();
    public DbSet<BasketItem> Items => Set<BasketItem>();

    public BasketDbContext(DbContextOptions<BasketDbContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BasketDbContext).Assembly);
    }
}
