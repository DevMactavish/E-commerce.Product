using Ecommerce.Product.Application.UseCases.Product.Commands.UpdateProduct.Dtos;
using Ecommerce.Product.Domain.Context;
using Ecommerce.Product.Domain.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Application.UseCases.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand>
{
    private readonly ProductCommandDbContext _context;
    public UpdateProductCommandHandler(ProductCommandDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.AsNoTracking()
            .FirstOrDefaultAsync(row => row.Id == request.CategoryId, cancellationToken);
        if (category == null)
            throw new NotFoundException("Category not found.");
        if (await _context.Products.AnyAsync(row => row.Id == request.GetId(), cancellationToken))
            throw new NotFoundException("Product not found");
        
        var product = Domain.Aggregates.Product.Update(category.Id,request.Title, request.Description,
            request.StockQuantity,category.MaximumStock,category.MinimumStock);
        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}