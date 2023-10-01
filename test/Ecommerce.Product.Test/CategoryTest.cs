using Ecommerce.Product.Domain.Aggregates;
using Ecommerce.Product.Domain.Exception;

namespace Ecommerce.Product.Test;

public class CategoryTest
{
    [Fact]
    public void CreateCategory_Successfully()
    {
        var category = Category.Create("Name", 10, 5);
        Assert.False(category.IsDeleted);
    }
    
    [Fact]
    public void CreateCategory_Fail_When_Name_As_Null()
    {
        Assert.Throws<DomainException>(() => 
            Category.Create(null, 10, 5));
    }
    
    [Fact]
    public void CreateCategory_Fail_When_Name_As_Empty()
    {
        Assert.Throws<DomainException>(() => 
            Category.Create(string.Empty, 10, 5));
    }
    
    [Fact]
    public void CreateCategory_Fail_When_MinimumStock_Less_Than_One()
    {
        Assert.Throws<DomainException>(() => 
            Category.Create("test", 10, 0));
    }
    
    [Fact]
    public void CreateCategory_Fail_When_MaximumStock_Less_Than_One()
    {
        Assert.Throws<DomainException>(() => 
            Category.Create("test", 0, 1));
    }
    
    [Fact]
    public void CreateCategory_Fail_When_MaximumStock_Equal_MinimumStock()
    {
        Assert.Throws<DomainException>(() => 
            Category.Create("test", 1, 1));
    }
    
    [Fact]
    public void CreateCategory_Fail_When_MaximumStock_Less_Than_MinimumStock()
    {
        Assert.Throws<DomainException>(() => 
            Category.Create("test", 2, 5));
    }
}