using Ecommerce.Product.Application.UseCases.Product.Queries.Dtos;
using Ecommerce.Product.Infrastructure.Pagination;

namespace Ecommerce.Product.Application.UseCases.Product.Queries.GetProducts.Dtos;

public class GetProductsQueryResult:PaginationResponse
{
    public List<ProductDto> Products{ get; set; }
}