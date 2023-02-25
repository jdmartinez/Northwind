namespace Northwind.Shared.Application.Interfaces;

public interface IIntegrationEventHandler
{ }

public interface IIntegrationEventHandler<TEvent> : IIntegrationEventHandler where TEvent : IIntegrationEvent
{
    Task Handle(TEvent @event, CancellationToken token = default);
}
