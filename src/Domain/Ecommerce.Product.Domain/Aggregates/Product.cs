using System.Data;
using Ecommerce.Product.Domain.ErrorMessages;
using Ecommerce.Product.Domain.Exception;
using Ecommerce.Product.Domain.SeedWork;

namespace Ecommerce.Product.Domain.Aggregates;

public class Product : Entity
{
    public long CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }

    public virtual Category Category { get; set; }

    public static Product Create(long categoryId, string title, string description, int stockQuantity, int maximumStock,
        int minimumStocks)
    {
        Guard.That<DomainException>(categoryId < 1, DomainErrorMessages.ERRPRODUCTDOM001);
        Guard.That<DomainException>(string.IsNullOrEmpty(description), DomainErrorMessages.ERRPRODUCTDOM002);
        Guard.That<DomainException>(string.IsNullOrEmpty(title), DomainErrorMessages.ERRPRODUCTDOM003);
        Guard.That<DomainException>(title.Length > 200, DomainErrorMessages.ERRPRODUCTDOM004);
        Guard.That<DomainException>(stockQuantity < 1, DomainErrorMessages.ERRPRODUCTDOM005);
        Guard.That<DomainException>(stockQuantity < minimumStocks, DomainErrorMessages.ERRPRODUCTDOM006);
        Guard.That<DomainException>(stockQuantity > maximumStock, DomainErrorMessages.ERRPRODUCTDOM007);

        return new Product
        {
            CategoryId = categoryId,
            Title = title,
            Description = description,
            StockQuantity = stockQuantity,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IsDeleted = false,
        };
    }
    
    public static Product Update(long categoryId, string title, string description, int stockQuantity, int maximumStock,
        int minimumStocks)
    {
        Guard.That<DomainException>(categoryId > 0, "Category must be live");
        Guard.That<DomainException>(string.IsNullOrEmpty(description), "Description can not be null or empty.");
        Guard.That<DomainException>(string.IsNullOrEmpty(title), "Title can not be null or empty.");
        Guard.That<DomainException>(title.Length > 200, "Title length less then 200 character.");
        Guard.That<DomainException>(stockQuantity < 1, "Minimum stock must be greater than 0");
        Guard.That<DomainException>(stockQuantity < minimumStocks, "Stock quantity must be greater then category minimum stock.");
        Guard.That<DomainException>(stockQuantity > maximumStock, "Stock quantity must be less then category maximum stock.");

        return new Product
        {
            CategoryId = categoryId,
            Title = title,
            Description = description,
            StockQuantity = stockQuantity,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}