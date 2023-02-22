using Microsoft.EntityFrameworkCore;

using Northwind.Basket.Application.Repositories;
using Northwind.Basket.Infrastructure.Persistance;
using Northwind.Shared.Application;

namespace Northwind.Basket.Infrastructure.Repositories;

public class BasketRepository : RepositoryBase<Domain.Entities.Basket>, IBasketRepository
{
    public BasketRepository(BasketDbContext context) : base(context)
    { }

    public override async Task<Domain.Entities.Basket?> GetAsync<TId>(TId id, CancellationToken token = default)
    {
        var basket = await _context.Set<Domain.Entities.Basket>()
            .Include(b => b.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id.Equals(id), token);

        basket ??= _context.Set<Domain.Entities.Basket>().Local.FirstOrDefault(b => b.Id.Equals(id));

        return basket;
    }

    public override async Task<IReadOnlyList<Domain.Entities.Basket>?> GetAllAsync(CancellationToken token = default)
    {
        var baskets = await _context.Set<Domain.Entities.Basket>()
            .Include(b => b.Items)
            .AsNoTracking()
            .ToListAsync();

        return baskets?.AsReadOnly();
    }

    public async Task<Domain.Entities.Basket?> GetByCustomerIdAsync(string customerId, CancellationToken token)
    {
        var basket = await _context.Set<Domain.Entities.Basket>()
            .Include(b => b.Items)
            .FirstOrDefaultAsync(b => b.CustomerId == customerId, token);

        basket ??= _context.Set<Domain.Entities.Basket>().Local.FirstOrDefault(b => b.CustomerId == customerId);

        return basket;
    }
}
