using MyShop_kata.Repositories.DbObjects;

namespace MyShop_kata.Services.Interfaces;
public interface IMyShopRepository
{
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task<Product?> GetProductById(int productId);
    public Task<Product> AddProduct(Product product);
    public Task UpdateProduct(Product product);
}