using System.Net;
using Ecommerce.Product.Application.UseCases.Product.Commands.CreateProduct.Dtos;
using Ecommerce.Product.Application.UseCases.Product.Commands.DeleteProduct.Dtos;
using Ecommerce.Product.Application.UseCases.Product.Commands.UpdateProduct.Dtos;
using Ecommerce.Product.Application.UseCases.Product.Queries.GetProductById.Dtos;
using Ecommerce.Product.Application.UseCases.Product.Queries.GetProducts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Product.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController:ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody]CreateProductCommand request, CancellationToken  cancellationToken)
    {
        await _mediator.Send(request,cancellationToken);
        return StatusCode((int)HttpStatusCode.Created);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute]long id,[FromBody]UpdateProductCommand request, CancellationToken  cancellationToken)
    {
        return Ok(await _mediator.Send(request.SetId(id),cancellationToken));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery]GetProductsQuery request, CancellationToken  cancellationToken)
    {
        return Ok(await _mediator.Send(request,cancellationToken));
    }
    
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProductById([FromRoute]GetProductByIdQuery request, CancellationToken  cancellationToken)
    {
        return Ok(await _mediator.Send(request,cancellationToken));
    }
    
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute]DeleteProductCommand request, CancellationToken  cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}