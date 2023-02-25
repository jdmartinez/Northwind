using System.Text.Json;
using System.Threading.Channels;

using Microsoft.Extensions.Logging;

using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Infrastructure.EventBus.Settings;

using RabbitMQ.Client;

namespace Northwind.Shared.Infrastructure.EventBus.RabbitMq;

public class RabbitMqPublisher : IRabbitMqPublisher
{
    private readonly ILogger<RabbitMqPublisher> _logger;
    private readonly EventBusSettings _settings;
    private readonly IConnectionFactory _connectionFactory;
    private readonly IConnection _connection;

    public RabbitMqPublisher(ILogger<RabbitMqPublisher> logger, EventBusSettings settings)
    {
        _logger = logger;
        _settings = settings;
        _connectionFactory = new ConnectionFactory
        {
            HostName = _settings.Host,
            UserName = _settings.Username,
            Password = _settings.Password,
            DispatchConsumersAsync = true,
        };

        _connection = _connectionFactory.CreateConnection();
    }

    public void Publish<TEvent>(TEvent @event, string queue = "") where TEvent : IIntegrationEvent
    {
        using var channel = _connection.CreateModel();
        channel.ExchangeDeclare(_settings.ExchangeName, ExchangeType.Direct, true, false);

        var payload = JsonSerializer.SerializeToUtf8Bytes(@event);
        var properties = channel.CreateBasicProperties();
        properties.DeliveryMode = 2;               

        channel.BasicPublish(
            exchange: _settings.ExchangeName,
            routingKey: queue,
            basicProperties: properties,
            body: payload);
    }    

    public void Dispose()
    {
        _connection?.Close();
        _connection?.Dispose();
    }
}
