using Northwind.Shared.Application.Interfaces;

namespace Northwind.Shared.Infrastructure.EventBus.RabbitMq;

public interface IRabbitMqConsumer
{
    Task Consume<TEvent, TEventHandler>(string queue = "")
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler<TEvent>;
}
