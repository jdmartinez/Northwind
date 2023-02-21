using System.Collections.ObjectModel;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Northwind.Customers.Api.DTO;
using Northwind.Customers.Application.Interfaces;

namespace Northwind.Customers.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Tags(new[] { "Customers" })]
public class CustomersController : ControllerBase
{
    private readonly ICustomersModule _finder;
    private readonly ILogger<CustomersController> _logger;
    private readonly IMapper _mapper;

    public CustomersController(ICustomersModule finder, ILogger<CustomersController> logger, IMapper mapper)
    {
        _finder = finder;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{customerId}", Name = "Get customer by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] string customerId, CancellationToken token)
    {
        var product = await _finder.GetByIdAsync(customerId, token);

        return product is null ? NotFound() : Ok(_mapper.Map<CustomerDto>(product));
    }

    [HttpGet(Name = "Get all customers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var products = await _finder.GetAllAsync(token);

        if (products is null) return NoContent();

        return Ok(_mapper.Map<ReadOnlyCollection<CustomerDto>>(products));
    }
}
