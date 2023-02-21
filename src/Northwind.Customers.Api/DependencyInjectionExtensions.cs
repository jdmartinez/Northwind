using Microsoft.EntityFrameworkCore;

using Northwind.Customers.Application.Interfaces;
using Northwind.Customers.Application.Modules;
using Northwind.Customers.Application.Repositories;
using Northwind.Customers.Infrastructure.Repositories;
using Northwind.Shared.Infrastructure.Persistence;

namespace Northwind.Customers.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, NorthwindContext>();
        services.AddDbContext<NorthwindContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Database")),
            ServiceLifetime.Transient);

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<ICustomersModule, CustomersModule>();

        return services;
    }
}
