using Ecommerce.Product.Domain.ErrorMessages;
using Ecommerce.Product.Domain.Exception;
using Ecommerce.Product.Domain.SeedWork;

namespace Ecommerce.Product.Domain.Aggregates;

public class Category:Entity
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    public string Name { get; set; }
    public int MinimumStock { get; set; }
    public int MaximumStock { get; set; }

    public HashSet<Product> Products { get; set; }

    public static Category Create(string name, int maximumStock, int minimumStock)
    {
        Guard.That<DomainException>(string.IsNullOrEmpty(name), DomainErrorMessages.ERRCATEGORYDOM001);
        Guard.That<DomainException>(minimumStock < 1,DomainErrorMessages.ERRCATEGORYDOM002);
        Guard.That<DomainException>(maximumStock < 1,DomainErrorMessages.ERRCATEGORYDOM003);
        Guard.That<DomainException>(minimumStock >= maximumStock,DomainErrorMessages.ERRCATEGORYDOM004);
        
        return new Category
        {
            Name = name,
            MaximumStock = maximumStock,
            MinimumStock = minimumStock,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}