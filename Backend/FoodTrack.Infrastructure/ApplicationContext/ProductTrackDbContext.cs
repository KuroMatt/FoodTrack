
using FoodTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodTrack.Infrastructure.ApplicationContext
{
    public class ProductTrackDbContext : DbContext
    {
        public ProductTrackDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<StockProduct> StockProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StockProductLocation> ProductLocations { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigureProduct(modelBuilder);

            ConfigureStockProduct(modelBuilder);
        }

        private static void ConfigureProduct(
       ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId);

                entity.Property(x => x.BarCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(x => x.BarCode)
                    .IsUnique();
            });
        }

        private static void ConfigureStockProduct(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockProduct>(entity =>
            {
                entity.HasKey(x => x.StockProductId);

                entity.Property(x => x.Quantity)
                    .IsRequired();

                entity.Property(x => x.PurchaseDate)
                    .IsRequired();

                entity.Property(x => x.ExpirationDate)
                    .IsRequired();

                // Relation StockProduct -> Product
                entity.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Optionnel : même produit + même DLC = unique
                entity.HasIndex(x => new
                {
                    x.ProductId,
                    x.ExpirationDate
                })
                .IsUnique();
            });
        }

        protected ProductTrackDbContext()
        {
        }

    }
}
