using Northwind.Shared.Application.Interfaces;

namespace Northwind.Basket.Application.Repositories;

public interface IBasketRepository : IRepository<Domain.Entities.Basket>
{
    Task<Domain.Entities.Basket?> GetByCustomerIdAsync(string customerId, CancellationToken token);
}
