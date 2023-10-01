namespace Ecommerce.Product.Domain.SeedWork
{
    public interface IEntity<out TKey> where TKey :IEquatable<TKey>
    {
        public TKey Id { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
