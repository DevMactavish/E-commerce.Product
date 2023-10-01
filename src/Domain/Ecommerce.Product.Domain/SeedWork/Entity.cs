namespace Ecommerce.Product.Domain.SeedWork
{


    public class Entity : IEntity<long>
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get ; set ; }
        public bool IsDeleted { get; set; }

    }
}
