using Microsoft.EntityFrameworkCore;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Shared.Application.Interfaces;

public interface INorthwindContext
{
    DbSet<Category> Categories { get; }

    DbSet<Customer> Customers { get; }

    DbSet<Employee> Employees { get; }

    DbSet<EmployeeTerritory> EmployeeTerritories { get; }

    DbSet<OrderDetail> OrderDetails { get; }

    DbSet<Order> Orders { get; }

    DbSet<Product> Products { get; }

    DbSet<Region> Region { get; }

    DbSet<Shipper> Shippers { get; }

    DbSet<Supplier> Suppliers { get; }

    DbSet<Territory> Territories { get; }

    Task<int> SaveChangesAsync(CancellationToken token = default);
}
