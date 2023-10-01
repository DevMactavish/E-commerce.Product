namespace Ecommerce.Product.Infrastructure.Pagination;

public class PaginationResponse
{
    public int Size { get; set; }
    public int Page { get; set; } 
    public int Count { get; set; }
}