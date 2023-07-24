using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Northwind.Shared.Grpc.Client
{
    public class GrpcServiceClient<TClient> : IGrpcServiceClient<TClient> where TClient : ClientBase<TClient>
    {
        private readonly TClient _client = default!;
        private readonly ILogger<TClient> _logger = default!;

        public GrpcServiceClient(TClient client, ILogger<TClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public Task<TResponse> Execute<TRequest, TResponse>(
            Func<TClient, Func<TRequest, CallOptions, Task<TResponse>>> func,
            TRequest request)
        {
            var callOptions = new CallOptions(new Metadata());
            return func(_client)(request, callOptions);
        }
    }
}
