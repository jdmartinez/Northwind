namespace Northwind.Shared.Application.Interfaces;

public interface IIntegrationEvent
{
    Guid Id { get; init; }

    DateTime CreationTime { get; init; }
}
