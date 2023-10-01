using MediatR;

namespace Ecommerce.Product.Application.UseCases.Category.Commands.CreateCategory.Dtos;

public class CreateCategoryCommand:IRequest
{
    public string Name { get; set; }
    public int MinimumStock { get; set; }
    public int MaximumStock { get; set; } 
}