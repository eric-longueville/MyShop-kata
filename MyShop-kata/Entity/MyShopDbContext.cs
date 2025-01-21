using Microsoft.EntityFrameworkCore;
using MyShop_kata.Repositories.DbObjects;

namespace MyShop_kata.Entity;

public class MyShopDbContext(DbContextOptions<MyShopDbContext> options) : DbContext(options)
{
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Price> Prices { get; set; }
    public virtual DbSet<Stock> Stocks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(o => o.ProductId);
        modelBuilder.Entity<Price>().HasKey(o => o.PriceId);
        modelBuilder.Entity<Stock>().HasKey(o => o.StockId);
    }
}