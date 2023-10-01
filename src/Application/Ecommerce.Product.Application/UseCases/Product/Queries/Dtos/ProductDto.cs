namespace Ecommerce.Product.Application.UseCases.Product.Queries.Dtos;

public class ProductDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }

    public virtual CategoryDto Category { get; set; }
}
