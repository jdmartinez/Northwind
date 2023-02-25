using System;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Northwind.Shared.Application.Interfaces;
using Northwind.Shared.Infrastructure.EventBus.Settings;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Northwind.Shared.Infrastructure.EventBus.RabbitMq;

public abstract class RabbitMqConsumerService : BackgroundService, IRabbitMqConsumer
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RabbitMqConsumerService> _logger;
    private readonly EventBusSettings _settings;
    private readonly IConnectionFactory _connectionFactory;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqConsumerService(IServiceProvider serviceProvider, ILogger<RabbitMqConsumerService> logger, EventBusSettings settings)
    {
        _serviceProvider = serviceProvider;
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
        _channel = _connection.CreateModel();        
        _channel.ExchangeDeclare(_settings.ExchangeName, ExchangeType.Direct, true, false, null);
    }

    public async Task Consume<TEvent, TEventHandler>(string queue = "")
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>
    {
        if (string.IsNullOrEmpty(queue))
        {
            queue = typeof(TEvent).Name;
        }

        _channel.QueueDeclare(
            queue: queue,
            durable: true,
            exclusive: false,
            autoDelete: false);

        _channel.QueueBind(
            queue: queue,
            exchange: _settings.ExchangeName,
            routingKey: string.Empty);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (sender, args) =>
        {
            _logger.LogInformation("RabbitMQ message received");

            var payload = Encoding.UTF8.GetString(args.Body.Span);
            var integrationEvent = JsonSerializer.Deserialize(payload, typeof(TEvent));            
            var handlerType = typeof(IIntegrationEventHandler<>).MakeGenericType(typeof(TEvent));

            try
            {
                var handler = _serviceProvider.GetRequiredService<TEventHandler>();

                await Task.Yield();

                await (Task)handlerType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent, null });

                await Task.CompletedTask;

                _channel.BasicAck(args.DeliveryTag, false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        };

        _channel.BasicConsume(queue, false, consumer);

        await Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _channel.Dispose();
        _connection.Close();
        _connection.Dispose();
        base.Dispose();
    }
}
