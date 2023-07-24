using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Northwind.Orders.Api.DTO;
using Northwind.Orders.Application.Interfaces;
using Northwind.Products.Api.Proto;
using static Northwind.Products.Api.Proto.Products;

namespace Northwind.Orders.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Tags(new[] { "Orders" })]
public class OrdersController : ControllerBase
{
    private readonly IOrdersModule _module = default!;
    private readonly ProductsClient _productsClient = default!;
    private readonly ILogger<OrdersController> _logger = default!;
    private readonly IMapper _mapper;

    public OrdersController(IOrdersModule module, ProductsClient productsClient, ILogger<OrdersController> logger, IMapper mapper)
    {
        _module = module;
        _productsClient = productsClient;
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

        if (order is null) return NotFound();

        var dto = _mapper.Map<OrderDto>(order);

        await GetProductInfo(dto);

        return Ok(dto);
    }

    private async Task GetProductInfo(OrderDto order)
    {
        foreach (var detail in order.OrderDetails)
        {
            var response = await _productsClient.GetProductByIdAsync(new ProductItemRequest { Id = detail.ProductId });
            detail.ProductName = response.Name;
        }
    }
}