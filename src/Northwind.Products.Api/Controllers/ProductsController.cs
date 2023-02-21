using System.Collections.ObjectModel;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using Northwind.Products.Api.DTO;
using Northwind.Products.Application.Interfaces;

namespace Northwind.Products.Api.Controllers;

[Route("[controller]")]
[ApiController]
[Tags(new[] { "Products" })]
public sealed class ProductsController : ControllerBase
{
    private readonly IProductsModule _finder;
    private readonly ILogger<ProductsController> _logger;
    private readonly IMapper _mapper;

    public ProductsController(IProductsModule finder, ILogger<ProductsController> logger, IMapper mapper)
    {
        _finder = finder;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("{productId}", Name = "Get products by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetById([FromRoute] int productId, CancellationToken token)
    {
        var product = await _finder.GetById(productId, token);

        return product is null ? NotFound() : Ok(_mapper.Map<ProductDto>(product));
    }

    [HttpGet(Name = "Get all products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var products = await _finder.GetAll(token);

        if (products is null) return NoContent();

        return Ok(_mapper.Map<ReadOnlyCollection<ProductDto>>(products));
    }
}
