using Northwind.Shared.Application.Interfaces;

namespace Northwind.Shared.Application.Events;

public record IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime CreationTime { get; init; } = DateTime.Now;

    public IntegrationEvent() { }

    public IntegrationEvent(Guid id, DateTime creationTime)
    {
        Id = id;
        CreationTime = creationTime;
    }
}
