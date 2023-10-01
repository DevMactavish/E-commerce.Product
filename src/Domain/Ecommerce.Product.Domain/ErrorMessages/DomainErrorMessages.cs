namespace Ecommerce.Product.Domain.ErrorMessages;

public static class DomainErrorMessages
{
    public const string ERRPRODUCTDOM001 = "Category can be live.";
    public const string ERRPRODUCTDOM002 = "Description can not be null or empty.";
    public const string ERRPRODUCTDOM003 = "Title can not be null or empty.";
    public const string ERRPRODUCTDOM004 = "Title length less then 200 character.";
    public const string ERRPRODUCTDOM005 = "Minimum stock must be greater than 0";
    public const string ERRPRODUCTDOM006 = "Stock quantity must be greater then category minimum stock.";
    public const string ERRPRODUCTDOM007 = "Stock quantity must be less then category maximum stock.";
    
    
    public const string ERRCATEGORYDOM001 = "Name can not be null or empty.";
    public const string ERRCATEGORYDOM002 = "Minimum stock must be greater than 0.";
    public const string ERRCATEGORYDOM003 = "Maximum stock must be greater than 0.";
    public const string ERRCATEGORYDOM004 = "Maximum stock must be greater than minimum stock.";
}