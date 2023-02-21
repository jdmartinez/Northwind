using Northwind.Products.Application.Interfaces;
using Northwind.Products.Application.Repositories;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Products.Application.Modules;

public class ProductsModule : IProductsModule
{
    private readonly IProductRepository _repository;

    public ProductsModule(IProductRepository repository) => _repository = repository;    

    public async Task<Product?> GetById(int id, CancellationToken token) => await _repository.GetAsync(id, token);

    public async Task<IReadOnlyList<Product>?> GetAll(CancellationToken token) => await _repository.GetAllAsync(token);
}
