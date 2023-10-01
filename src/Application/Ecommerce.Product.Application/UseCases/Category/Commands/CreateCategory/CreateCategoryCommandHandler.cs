using Ecommerce.Product.Application.UseCases.Category.Commands.CreateCategory.Dtos;
using Ecommerce.Product.Domain.Context;
using MediatR;

namespace Ecommerce.Product.Application.UseCases.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ProductCommandDbContext _context;

    public CreateCategoryCommandHandler(ProductCommandDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Domain.Aggregates.Category.Create(request.Name, request.MaximumStock, request.MinimumStock);
        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}