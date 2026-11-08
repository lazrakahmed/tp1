using FTELMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Data;

public class FtelMarketContext : DbContext
{
  public FtelMarketContext(DbContextOptions<FtelMarketContext> options) : base(options) { }

  // Each DbSet becomes a table.
  public DbSet<Product> Products => Set<Product>();
  public DbSet<Category> Categories => Set<Category>();

  // Settings that conventions can't guess.
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Product>(product =>
    {
      // Money: exact decimal, up to 9,999,999,999,999,999.99.
      product.Property(p => p.Price).HasPrecision(18, 2);
      // Same limits as the front's validation rules.
      product.Property(p => p.Name).HasMaxLength(200);
      product.Property(p => p.Description).HasMaxLength(1000);
    });

    // Initial data, inserted by a migration. Ids are explicit and dates fixed
    // so the migration is always the same.
    modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "PlayStation 5" },
      new Category { Id = 2, Name = "Nintendo Switch" },
      new Category { Id = 3, Name = "Xbox Series X" },
      new Category { Id = 4, Name = "PC" });

    modelBuilder.Entity<Product>().HasData(
      new Product { Id = 1, Name = "The Last of Us Part II", Description = "Boîte et notice, disque sans rayure.", Price = 19.9m, Stock = 3, CategoryId = 1, CreatedAt = new DateTime(2026, 9, 2, 9, 15, 0, DateTimeKind.Utc) },
      new Product { Id = 2, Name = "Gran Turismo 7", Description = null, Price = 29.9m, Stock = 1, CategoryId = 1, CreatedAt = new DateTime(2026, 9, 5, 14, 30, 0, DateTimeKind.Utc) },
      new Product { Id = 3, Name = "The Legend of Zelda: Tears of the Kingdom", Description = "Cartouche seule.", Price = 39.9m, Stock = 2, CategoryId = 2, CreatedAt = new DateTime(2026, 9, 8, 10, 0, 0, DateTimeKind.Utc) },
      new Product { Id = 4, Name = "Mario Kart 8 Deluxe", Description = "Complet, très bon état.", Price = 34.9m, Stock = 5, CategoryId = 2, CreatedAt = new DateTime(2026, 9, 10, 16, 45, 0, DateTimeKind.Utc) },
      new Product { Id = 5, Name = "Halo Infinite", Description = null, Price = 14.9m, Stock = 4, CategoryId = 3, CreatedAt = new DateTime(2026, 9, 12, 11, 20, 0, DateTimeKind.Utc) },
      new Product { Id = 6, Name = "Forza Horizon 5", Description = "Édition standard.", Price = 24.9m, Stock = 0, CategoryId = 3, CreatedAt = new DateTime(2026, 9, 15, 8, 5, 0, DateTimeKind.Utc) },
      new Product { Id = 7, Name = "Baldur’s Gate 3", Description = "Clé physique, coffret collector.", Price = 44.9m, Stock = 1, CategoryId = 4, CreatedAt = new DateTime(2026, 9, 18, 17, 40, 0, DateTimeKind.Utc) },
      new Product { Id = 8, Name = "Hades", Description = null, Price = 9.9m, Stock = 6, CategoryId = 4, CreatedAt = new DateTime(2026, 9, 21, 13, 10, 0, DateTimeKind.Utc) });
  }
}
