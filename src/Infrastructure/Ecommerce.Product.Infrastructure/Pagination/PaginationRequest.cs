namespace Ecommerce.Product.Infrastructure.Pagination;

public class PaginationRequest
{
    public int Size { get; set; } = PaginationConstants.DEFAULT_PAGINATION_SIZE;
    public int Page { get; set; } = PaginationConstants.DEFAULT_PAGINATION_PAGE;
}