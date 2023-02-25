using Microsoft.Extensions.Logging;

using Northwind.Shared.Application.Interfaces;

namespace Northwind.Shared.Application.Events.Handlers;

public class OrderAcceptedEventHandler : IIntegrationEventHandler<OrderAcceptedEvent>
{
    private readonly ILogger<OrderAcceptedEventHandler> _logger;

    public OrderAcceptedEventHandler(ILogger<OrderAcceptedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(OrderAcceptedEvent @event, CancellationToken token = default)
    {
        _logger.LogInformation("Handling integration event {Event}", @event.GetType().Name);

        return Task.CompletedTask;
    }
}
