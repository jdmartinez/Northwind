using System.Runtime.CompilerServices;

using Northwind.Basket.Application.Interfaces;
using Northwind.Basket.Application.Repositories;

namespace Northwind.Basket.Application.Modules;

public class BasketModule : IBasketModule
{
    private readonly IBasketRepository _repository;

    public BasketModule(IBasketRepository repository) => _repository = repository;

    public async Task<Domain.Entities.Basket> AddAsync(Domain.Entities.Basket basket, CancellationToken token = default)
        => await _repository.AddAsync(basket, token);        

    public async Task<Domain.Entities.Basket> CreateAsync(string customerId, CancellationToken token = default)
    {
        if (string.IsNullOrEmpty(customerId)) throw new ArgumentNullException(nameof(customerId));

        var basket = new Domain.Entities.Basket(customerId);

        basket = await _repository.AddAsync(basket, token);

        await _repository.SaveChangesAsync(token);

        return basket;
    }

    public async Task<Domain.Entities.Basket?> GetByIdAsync(Guid basketId, CancellationToken token = default)
        => await _repository.GetAsync(basketId, token);

    public async Task<Domain.Entities.Basket?> GetByCustomerIdAsync(string customerId, CancellationToken token = default)
        => await _repository.GetByCustomerIdAsync(customerId, token);

    public async Task UpdateAsync(Domain.Entities.Basket basket, CancellationToken token = default)
    {
        _repository.Update(basket);

        await _repository.SaveChangesAsync(token);
    }
    
}
