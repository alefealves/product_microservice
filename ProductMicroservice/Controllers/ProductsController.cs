// Controllers/ProductsController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Features.Products.Commands;
using ProductMicroservice.Features.Products.Queries;

namespace ProductMicroservice.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
  private readonly IMediator _mediator;

  public ProductsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost]
  public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
  {
    var productId = await _mediator.Send(command);
    return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
  }

  [HttpGet]
  public async Task<IActionResult> GetAllProducts()
  {
    var products = await _mediator.Send(new GetAllProductsQuery());
    return Ok(products);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetProductById(int id)
  {
    var product = await _mediator.Send(new GetProductByIdQuery(id));
    if (product == null)
    {
      return NotFound();
    }
    return Ok(product);
  }

}
