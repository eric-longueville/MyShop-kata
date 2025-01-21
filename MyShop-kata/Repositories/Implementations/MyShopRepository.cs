using Microsoft.EntityFrameworkCore;
using MyShop_kata.Entity;
using MyShop_kata.Repositories.DbObjects;
using MyShop_kata.Services.Interfaces;

namespace MyShop_kata.Services.Implementations;
public class MyShopRepository : IMyShopRepository
{
    private readonly MyShopDbContext _context;
    public MyShopRepository(MyShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products
            .Include(p => p.Quantity)
            .Include(p => p.Price)
            .ToListAsync();
    }

    public async Task<Product?> GetProductById(int productId)
    {
        return await _context.Products
            .Include(p => p.Quantity)
            .Include(p => p.Price)
            .FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task<Product> AddProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task UpdateProduct(Product product)
    {
        var existingProduct = _context.Products.Find(product.ProductId);
        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }
        existingProduct = product;
        await _context.SaveChangesAsync();
    }
}