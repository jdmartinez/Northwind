using System.Runtime.CompilerServices;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Northwind.Basket.Api.DTO;
using Northwind.Basket.Application.Interfaces;

namespace Northwind.Basket.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Tags(new[] { "Basket" })]
public class BasketController : ControllerBase
{
    private readonly IBasketModule _module;
    private readonly ILogger<BasketController> _logger;
    private readonly IMapper _mapper;

    public BasketController(IBasketModule module, ILogger<BasketController> logger, IMapper mapper)
    {
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
    public IActionResult Checkout([FromBody] BasketDto basket, CancellationToken token = default)
    {
        return Accepted();
    }
}
