using Microsoft.EntityFrameworkCore;
using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Shared.Infrastructure.Persistence
{
    public class NorthwindContext : DbContext, INorthwindContext
    {
        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Customer> Customers => Set<Customer>();

        public DbSet<Employee> Employees => Set<Employee>();

        public DbSet<EmployeeTerritory> EmployeeTerritories => Set<EmployeeTerritory>();

        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        public DbSet<Order> Orders => Set<Order>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Region> Region => Set<Region>();

        public DbSet<Shipper> Shippers => Set<Shipper>();

        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public DbSet<Territory> Territories => Set<Territory>();

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindContext).Assembly);
    }
}