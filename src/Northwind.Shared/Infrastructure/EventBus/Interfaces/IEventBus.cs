using Northwind.Shared.Application.Interfaces;

namespace Northwind.Shared.Infrastructure.EventBus.Interfaces;

public interface IRabbitMqPublisher
{
    bool IsConnected { get; }

    void Publish(IIntegrationEvent @event);

    void Subscribe<TEvent, TEventHandler>() 
        where TEvent : IIntegrationEvent
        where TEventHandler : IIntegrationEventHandler;    
}
