using Ecommerce.Product.Application.UseCases.Product.Commands.DeleteProduct.Dtos;
using Ecommerce.Product.Domain.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Application.UseCases.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand>
{
    private readonly ProductCommandDbContext _context;
    public DeleteProductCommandHandler(ProductCommandDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(row => row.Id == request.Id, cancellationToken);
        if (product == null)
            return Unit.Value;
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}