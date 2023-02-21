using Northwind.Shared.Application.Interfaces;

namespace Northwind.Basket.Application.Interfaces;

public interface IBasketModule : IApplicationModule
{
    Task<Domain.Entities.Basket> AddAsync(Domain.Entities.Basket basket, CancellationToken token = default);

    Task<Domain.Entities.Basket> CreateAsync(string customerId, CancellationToken token = default);

    Task<Domain.Entities.Basket?> GetByIdAsync(Guid basketId, CancellationToken token = default);

    Task<Domain.Entities.Basket?> GetByCustomerIdAsync(string customerId, CancellationToken token = default);

    Task UpdateAsync(Domain.Entities.Basket basket, CancellationToken token = default);
}
