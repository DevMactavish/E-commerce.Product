using Ecommerce.Product.Infrastructure.Pagination;
using MediatR;

namespace Ecommerce.Product.Application.UseCases.Product.Queries.GetProducts.Dtos;

public class GetProductsQuery:PaginationRequest,IRequest<GetProductsQueryResult>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? CategoryName { get; set; }
}