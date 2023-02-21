using Microsoft.EntityFrameworkCore;

using Northwind.Products.Application.Repositories;
using Northwind.Shared.Application;
using Northwind.Shared.Domain.Entities;
using Northwind.Shared.Infrastructure.Persistence;

namespace Northwind.Products.Infrastructure.Repositories;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(NorthwindContext context) : base(context)
    { }    

    public override async Task<Product?> GetAsync<TId>(TId productId, CancellationToken token = default)
    {
        var product = await _context.Set<Product>()
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductId.Equals(productId), token);

        product ??= _context.Set<Product>().Local.FirstOrDefault(p => p.ProductId.Equals(productId));

        return product;
    }

    public override async Task<IReadOnlyList<Product>?> GetAllAsync(CancellationToken token = default)
    {
        var products = await _context.Set<Product>()
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .AsNoTracking()
            .ToListAsync(token);

        return products?.AsReadOnly();            
    }    
}
