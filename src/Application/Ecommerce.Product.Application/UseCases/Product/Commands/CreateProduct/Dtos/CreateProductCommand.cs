using MediatR;

namespace Ecommerce.Product.Application.UseCases.Product.Commands.CreateProduct.Dtos;

public class CreateProductCommand:IRequest
{
    public long CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
}