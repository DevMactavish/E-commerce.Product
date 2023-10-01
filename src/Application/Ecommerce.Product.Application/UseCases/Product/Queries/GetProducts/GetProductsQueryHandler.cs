using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Ecommerce.Product.Application.UseCases.Product.Queries.Dtos;
using Ecommerce.Product.Application.UseCases.Product.Queries.GetProducts.Dtos;
using Ecommerce.Product.Domain.Context;
using Ecommerce.Product.Infrastructure.PredicateBuilder;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Application.UseCases.Product.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsQueryResult>
{
    private readonly ProductQueryDbContext _context;

    public GetProductsQueryHandler(ProductQueryDbContext context)
    {
        _context = context;
    }

    public async Task<GetProductsQueryResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Domain.Aggregates.Product, bool>> predicate = row => !row.IsDeleted;
        if(!string.IsNullOrEmpty(request.Title))
            predicate=predicate.And(row => 
                string.Equals(row.Title.ToLower(), request.Title.ToLower()));
        if(!string.IsNullOrEmpty(request.CategoryName)) 
            predicate =predicate.And(row => 
                string.Equals(row.Category.Name,request.CategoryName));
        if (!string.IsNullOrEmpty(request.Description))
            predicate = predicate.And(row =>
                row.Description.ToLower().Contains(request.Description));
        
        var count = await _context.Products
            .AsNoTracking()
            .CountAsync(predicate,cancellationToken);
        
        var products = await _context.Products
            .AsNoTracking()
            .Include(row => row.Category)
            .Where(predicate)
            .Skip(request.Page-1)
            .Take(request.Size)
            .ToListAsync(cancellationToken);
        
        return new GetProductsQueryResult
        {
            Count = count,
            Page = request.Page,
            Size = request.Size,
            Products = products.Adapt<List<ProductDto>>()
        };
    }
}