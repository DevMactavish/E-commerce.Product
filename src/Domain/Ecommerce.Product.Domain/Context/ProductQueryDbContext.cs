using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Product.Domain.Context
{
    public class ProductQueryDbContext: DbContext
    {
        public ProductQueryDbContext(DbContextOptions<ProductQueryDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aggregates.Product>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Aggregates.Category>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Aggregates.Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Aggregates.Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

        }

        public virtual DbSet<Aggregates.Product> Products { get; set; }
        public virtual DbSet<Aggregates.Category> Categories { get; set; }
    }
}
