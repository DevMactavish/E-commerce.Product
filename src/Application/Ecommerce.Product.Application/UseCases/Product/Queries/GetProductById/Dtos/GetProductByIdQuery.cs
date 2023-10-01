using Ecommerce.Product.Application.UseCases.Product.Queries.Dtos;
using MediatR;

namespace Ecommerce.Product.Application.UseCases.Product.Queries.GetProductById.Dtos;

public class GetProductByIdQuery:IRequest<ProductDto>
{
    public long Id { get; set; }
}