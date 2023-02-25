using Northwind.Shared.Application.Interfaces;

namespace Northwind.Shared.Infrastructure.EventBus.RabbitMq;

public interface IRabbitMqPublisher : IDisposable
{
    void Publish<TEvent>(TEvent @event, string queue = "") where TEvent : IIntegrationEvent;
}