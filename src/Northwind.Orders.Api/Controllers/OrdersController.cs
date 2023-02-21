using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Northwind.Orders.Api.DTO;
using Northwind.Orders.Application.Interfaces;

namespace Northwind.Orders.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Tags(new[] { "Orders" })]
public class OrdersController : ControllerBase
{
    private readonly IOrdersModule _module;
    private readonly ILogger<OrdersController> _logger;
    private readonly IMapper _mapper;

    public OrdersController(IOrdersModule module, ILogger<OrdersController> logger, IMapper mapper)
    {
        _module = module;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{orderId}", Name = "Get order by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] int orderId, CancellationToken token)
    {
        var order = await _module.GetByIdAsync(orderId, token);

        return order is null ? NotFound() : Ok(_mapper.Map<OrderDto>(order));
    }
}