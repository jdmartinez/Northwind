using Microsoft.EntityFrameworkCore;

using Northwind.Products.Application.Interfaces;
using Northwind.Products.Application.Modules;
using Northwind.Products.Application.Repositories;
using Northwind.Products.Infrastructure.Repositories;
using Northwind.Shared.Infrastructure.Persistence;

namespace Northwind.Products.Api;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, NorthwindContext>();
        services.AddDbContext<NorthwindContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("Database")),
            ServiceLifetime.Transient);

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IProductsModule, ProductsModule>();

        return services;
    }
}
