using Grpc.Net.Client;
using Northwind.Products.Api.Proto;
using static Northwind.Products.Api.Proto.Products;

namespace Northwind.Orders.Infrastructure.Grpc
{
    public class GrpcClient
    {
        public static async Task<ProductItemResponse> GetProductById(int productId)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7294/");
            var service = new ProductsClient(channel);

            var request = new ProductItemRequest { Id = productId };
            
            return await service.GetProductByIdAsync(request);
        }
    }
}
