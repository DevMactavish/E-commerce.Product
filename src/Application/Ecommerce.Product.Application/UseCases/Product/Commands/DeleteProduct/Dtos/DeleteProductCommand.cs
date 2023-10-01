using MediatR;

namespace Ecommerce.Product.Application.UseCases.Product.Commands.DeleteProduct.Dtos;

public class DeleteProductCommand:IRequest
{
    public long Id { get; set; }
}