using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Northwind.Basket.Api.DTO;
using Northwind.Basket.Application.Interfaces;
using Northwind.Shared.Application.Events;
using Northwind.Shared.Infrastructure.EventBus.RabbitMq;

namespace Northwind.Basket.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Tags(new[] { "Basket" })]
public class BasketController : ControllerBase
{
    private readonly IRabbitMqPublisher _publisher;
    private readonly IBasketModule _module;
    private readonly ILogger<BasketController> _logger;
    private readonly IMapper _mapper;

    public BasketController(IRabbitMqPublisher publisher, IBasketModule module, ILogger<BasketController> logger, IMapper mapper)
    {
        _publisher = publisher;
        _module = module;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{customerId}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<IActionResult> GetByCustomerId([FromRoute] string customerId, CancellationToken token = default)
    {
        var basket = await _module.GetByCustomerIdAsync(customerId, token);

        basket ??= await _module.CreateAsync(customerId, token);

        return Ok(_mapper.Map<BasketDto>(basket));
    }

    [HttpPost]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<IActionResult> Update([FromBody] BasketDto basketDto, CancellationToken token = default)
    {
        var basket = _mapper.Map<Domain.Entities.Basket>(basketDto);

        await _module.UpdateAsync(basket, token);

        return Ok();
    }

    [Route("checkout")]
    [HttpPost]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public IActionResult Checkout([FromBody] BasketDto basketDto)
    {        
        try
        {
            var eventMessage = new OrderAcceptedEvent
            {
                CustomerId = basketDto.CustomerId,
            };

            foreach (var item in basketDto.Items)
            {
                eventMessage.Items.Add(new OrderAcceptedEvent.OrderAcceptedItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                });
            }

            _logger.LogInformation("Publishing RabbitMQ message {Event}", eventMessage.GetType().Name);
            _publisher.Publish(eventMessage);
        }        
        catch

        {
            _logger.LogError("Error publishing {Event} event", typeof(OrderAcceptedEvent).Name);
        }

        return Accepted();
    }
}
