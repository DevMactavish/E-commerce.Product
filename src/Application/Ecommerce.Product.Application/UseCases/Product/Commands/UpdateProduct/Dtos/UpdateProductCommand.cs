using MediatR;

namespace Ecommerce.Product.Application.UseCases.Product.Commands.UpdateProduct.Dtos;

public class UpdateProductCommand:IRequest
{
    private long Id { get; set; }
    public long CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public UpdateProductCommand SetId(long id)
    {
        Id = id;
        return this;
    }
    public long GetId() => Id;
}