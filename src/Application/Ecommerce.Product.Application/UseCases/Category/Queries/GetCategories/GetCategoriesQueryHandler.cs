using Ecommerce.Product.Application.UseCases.Category.Queries.GetCategories.Dtos;
using Ecommerce.Product.Domain.Context;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Application.UseCases.Category.Queries.GetCategories;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<GetCategoriesQueryResult>>
{
    private readonly ProductQueryDbContext _context;

    public GetCategoriesQueryHandler(ProductQueryDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoriesQueryResult>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _context.Categories
            .AsNoTracking()
            .Where(row => !row.IsDeleted)
            .ToListAsync(cancellationToken);
        return response.Adapt<List<GetCategoriesQueryResult>>();
    }
}