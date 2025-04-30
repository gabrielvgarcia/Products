using Microsoft.EntityFrameworkCore;
using Products.API.Models;

namespace Products.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<ProductSeller>(entity =>
            {
                entity.HasKey(ps => new { ps.Id });

                entity.Property(ps => ps.Price).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(ps => ps.StockQuantity).IsRequired();
                entity.Property(ps => ps.Sku).HasMaxLength(50).IsRequired();

                entity.HasOne(ps => ps.Product)
                      .WithMany(p => p.ProductSellers)
                      .HasForeignKey(ps => ps.ProductId);

                entity.HasOne(ps => ps.Seller)
                      .WithMany(s => s.ProductSellers)
                      .HasForeignKey(ps => ps.SellerId);
            });

            modelBuilder.Entity<Product>().HasData(
                new Product (1, "TV", "42'' TV"),
                new Product (2, "Fridge", "8KG fridge"),
                new Product (3, "Smartphone", "Xiaomi"),
                new Product (4, "Smartphone", "Iphone")
            );

            modelBuilder.Entity<Seller>().HasData(
                new Seller (1, "Tech store"),
                new Seller (2, "House store"),
                new Seller (3, "Big Market")
            );

            modelBuilder.Entity<ProductSeller>().HasData(
                new ProductSeller (1, 1, 1, 1599.00m, 10, Guid.NewGuid().ToString()),
                new ProductSeller (2, 1, 2, 3499.00m, 5, Guid.NewGuid().ToString()),
                new ProductSeller (3, 1, 1, 3999.00m, 20, Guid.NewGuid().ToString()),
                new ProductSeller (4, 2, 3, 3999.00m, 20, Guid.NewGuid().ToString()),
                new ProductSeller (5, 3, 2, 3999.00m, 20, Guid.NewGuid().ToString()),
                new ProductSeller (6, 4, 3, 3999.00m, 20, Guid.NewGuid().ToString())
            );
        }

    }
}
