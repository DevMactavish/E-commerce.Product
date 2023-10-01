using Ecommerce.Product.Domain.Exception;

namespace Ecommerce.Product.Test;

public class ProductTest
{
    
    [Fact]
    public void CreateProduct_SuccessFully()
    {
        var product = Domain.Aggregates.Product.Create(
            1, "test", "test", 3, 10, 2);
        Assert.False(product.IsDeleted);
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_Category()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                0, "test", "test", 1, 10, 0));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_Title_Length()
    {
        var s = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eu fermentum sapien. Aliquam a eros non ligula tristique pretium ac quis nibh. Nunc sollicitudin nisi in sapien pulvinar sollicitudin. Donec feugiat, lectus vitae fringilla ullamcorper, nulla odio luctus turpis, sed rutrum sem nulla at risus. Nulla at ipsum rhoncus, accumsan felis id, feugiat lorem. Vivamus consectetur, justo sit amet gravida imperdiet, lectus felis commodo dolor, a condimentum nunc sem in sapien. In et massa fringilla, malesuada eros eu, pharetra nisl.";
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, s, "test", 1, 10, 0));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_Title_As_Null()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, null, "test", 1, 10, 1));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_Title_As_Empty()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, string.Empty, "test", 1, 10, 1));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_Description_As_Null()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, "test", null, 1, 10, 1));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_Description_As_Empty()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, "test", string.Empty, 1, 10, 1));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_StockQuantity_As_Zero()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, "test", "test", 0, 10, 1));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_MinimumStock_Greater_Than_Stock_Quantity()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, "test", "test", 1, 10, 2));
    }
    
    [Fact]
    public void CreateProduct_Fail_When_Invalid_MaximumStock_Less_Than_Stock_Quantity()
    {
        Assert.Throws<DomainException>(() => 
            Domain.Aggregates.Product.Create(
                1, "test", "test", 6, 3, 2));
    }
}