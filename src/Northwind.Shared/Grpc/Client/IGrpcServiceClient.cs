using Grpc.Core;
using Microsoft.IdentityModel.Tokens;

namespace Northwind.Shared.Grpc.Client
{
    public interface IGrpcServiceClient<TClient> where TClient : ClientBase<TClient>
    {
        Task<TResponse> Execute<TRequest, TResponse>(
            Func<TClient, Func<TRequest, CallOptions, Task<TResponse>>> func,
            TRequest request);
    }
}
