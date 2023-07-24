using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Northwind.Shared.Grpc.Infrastructure
{
    public class GrpcServiceClientBuilder
    {
        private readonly IServiceCollection _services = default!;

        public GrpcServiceClientBuilder(IServiceCollection services)
        {
            _services = services;
        }

        public GrpcServiceClientBuilder AddClient<TClient>(string host, int port) where TClient : ClientBase<TClient>
        {
            _services.AddGrpcClient<TClient>(options => options.Address = new Uri($"{host}:{port}"));

            return this;
        }
    }
}
