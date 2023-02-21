using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Products.Application.Interfaces;

public interface IProductsModule : IApplicationModule
{
    Task<Product?> GetById(int id, CancellationToken token);

    Task<IReadOnlyList<Product>?> GetAll(CancellationToken token);
}