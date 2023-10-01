namespace Ecommerce.Product.Application.UseCases.Category.Queries.GetCategories.Dtos;

public class GetCategoriesQueryResult
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int MinimumStock { get; set; }
    public int MaximumStock { get; set; }
}