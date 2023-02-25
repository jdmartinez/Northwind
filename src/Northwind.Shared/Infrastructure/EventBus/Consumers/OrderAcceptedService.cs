using Microsoft.Extensions.Logging;

using Northwind.Shared.Application.Events;
using Northwind.Shared.Application.Events.Handlers;
using Northwind.Shared.Infrastructure.EventBus.RabbitMq;
using Northwind.Shared.Infrastructure.EventBus.Settings;

namespace Northwind.Shared.Infrastructure.EventBus.Consumers;

public class OrderAcceptedService : RabbitMqConsumerService
{
    public OrderAcceptedService(IServiceProvider serviceProvider, ILogger<RabbitMqConsumerService> logger, EventBusSettings settings) 
        : base(serviceProvider, logger, settings)
    {
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Consume<OrderAcceptedEvent, OrderAcceptedEventHandler>();
    }
}
