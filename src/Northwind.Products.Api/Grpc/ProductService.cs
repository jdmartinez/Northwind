using Grpc.Core;
using Northwind.Products.Api.Proto;
using Northwind.Products.Application.Interfaces;
using Northwind.Shared.Infrastructure.Persistence;
using static Northwind.Products.Api.Proto.Products;

namespace Northwind.Products.Api.Grpc
{
    public class ProductService : ProductsBase
    {
        private readonly IProductsModule _module = default!;
        private readonly ILogger _logger = default!;

        public ProductService(IProductsModule module, ILogger<ProductService> logger)
        {
            _module = module;
            _logger = logger;
        }

        public override async Task<ProductItemResponse> GetProductById(ProductItemRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call ProductService.GetProductById for product id {Id}", request.Id);

            if (request.Id <= 0)
            {
                context.Status = new(StatusCode.FailedPrecondition, $"Id must be > 0 (received {request.Id})");
                return default!;
            }

            var item = await _module.GetById(request.Id, CancellationToken.None);

            if (item is not null)
            {
                return new()
                {
                    Id = item.ProductId,
                    Name = item.ProductName,
                    UnitPrice = (double?)item.UnitPrice ?? 0,
                    AvailableStock = (int?)item.UnitsInStock ?? 0,
                    ReservedStock = (int?)item.UnitsOnOrder ?? 0
                };
            }

            context.Status = new(StatusCode.NotFound, $"Product with id {request.Id} do not exist");
            return default!;
        }
    }
}
