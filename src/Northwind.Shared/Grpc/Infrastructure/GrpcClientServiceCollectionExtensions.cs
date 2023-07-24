using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Shared.Grpc.Client;

namespace Northwind.Shared.Grpc.Infrastructure
{
    public static class GrpcClientServiceCollectionExtensions
    {
        public static GrpcServiceClientBuilder AddGrpcClients(this IServiceCollection services, IConfiguration configuration = default!)
        {
            services.AddScoped(typeof(IGrpcServiceClient<>), typeof(GrpcServiceClient<>));

            return new(services);
        }
    }
}
