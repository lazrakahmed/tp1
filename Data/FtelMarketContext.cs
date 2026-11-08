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
  }
}
