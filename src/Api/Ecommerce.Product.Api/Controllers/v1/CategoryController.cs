using System.Net;
using Ecommerce.Product.Application.UseCases.Category.Commands.CreateCategory.Dtos;
using Ecommerce.Product.Application.UseCases.Category.Queries.GetCategories.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Product.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/categories")]
public class CategoryController:ControllerBase
{
    private readonly IMediator _mediator;
    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody]CreateCategoryCommand request, CancellationToken  cancellationToken)
    {
        await _mediator.Send(request,cancellationToken);
        return StatusCode((int)HttpStatusCode.Created);
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetCategoriesQuery(),cancellationToken));
    }
}