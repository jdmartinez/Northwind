using Grpc.Net.Client;
using Northwind.Products.Api.Proto;
using static Northwind.Products.Api.Proto.Products;

namespace Northwind.Orders.Infrastructure.Grpc
{
    public static class GrpcClient
    {
        private static GrpcChannel _channel = default!;

        public static async Task<ProductItemResponse> GetProductById(int productId)
        {
            _channel ??= GrpcChannel.ForAddress("https://localhost:7294/");
            var service = new ProductsClient(_channel);

            var request = new ProductItemRequest { Id = productId };
            
            return await service.GetProductByIdAsync(request);
        }
    }
}
