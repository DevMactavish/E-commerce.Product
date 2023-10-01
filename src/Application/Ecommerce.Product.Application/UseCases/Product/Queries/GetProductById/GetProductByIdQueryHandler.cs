using Ecommerce.Product.Application.UseCases.Product.Queries.Dtos;
using Ecommerce.Product.Application.UseCases.Product.Queries.GetProductById.Dtos;
using Ecommerce.Product.Domain.Context;
using Ecommerce.Product.Domain.Exception;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Application.UseCases.Product.Queries.GetProductById;

public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,ProductDto>
{
    private readonly ProductQueryDbContext _context;

    public GetProductByIdQueryHandler(ProductQueryDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.AsNoTracking().Include(row => row.Category)
            .FirstOrDefaultAsync(row => row.Id == request.Id, cancellationToken);
        if (product == null)
            throw new NotFoundException("Product not found.");
        return product.Adapt<ProductDto>();
    }
}