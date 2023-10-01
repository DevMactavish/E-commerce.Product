using Ecommerce.Product.Application.UseCases.Product.Commands.CreateProduct.Dtos;
using Ecommerce.Product.Domain.Context;
using Ecommerce.Product.Domain.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Application.UseCases.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly ProductCommandDbContext _context;

    public CreateProductCommandHandler(ProductCommandDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.AsNoTracking()
            .FirstOrDefaultAsync(row => row.Id == request.CategoryId, cancellationToken);
        if (category == null)
            throw new NotFoundException("Category not found.");
        
        var product = Domain.Aggregates.Product.Create(category.Id,request.Title, request.Description,
            request.StockQuantity,category.MaximumStock,category.MinimumStock);
        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}